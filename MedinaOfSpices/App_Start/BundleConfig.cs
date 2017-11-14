namespace MedinaOfSpices
{
	using System.IO;
	using System.Web.Hosting;
	using System.Web.Optimization;

	/// <summary>
	/// Defines the <see cref="BundleConfig" />
	/// </summary>
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		/// <summary>
		/// The RegisterBundles
		/// </summary>
		/// <param name="bundles">The <see cref="BundleCollection"/></param>
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.unobtrusive*",
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
				"~/Scripts/knockout-{version}.js",
				"~/Scripts/knockout.validation.js"));

			bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
				"~/Scripts/DataTables/jquery.dataTables.min.js",
				"~/Scripts/DataTables/dataTables.responsive.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
				"~/Scripts/Custom/wow.min.js",
				"~/Scripts/Custom/viewmodel.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.min.js",
				"~/Scripts/respond.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				 "~/Content/bootstrap.min.css",
				 "~/Content/style.min.css",
				 "~/Content/cm-overlay.min.css",
				 "~/Content/font-awesome.min.css",
				 "~/Content/animate.min.css",
				"~/Content/DataTables/css/jquery.dataTables.min.css"
				 //"~/Content/Site.min.css"
				 ).WithLastModifiedToken());
		}
	}

	/// <summary>
	/// Defines the <see cref="BundleExtensions" />
	/// </summary>
	internal static class BundleExtensions
	{
		/// <summary>
		/// The WithLastModifiedToken
		/// </summary>
		/// <param name="sb">The <see cref="Bundle"/></param>
		/// <returns>The <see cref="Bundle"/></returns>
		public static Bundle WithLastModifiedToken(this Bundle sb)
		{
			sb.Transforms.Add(new LastModifiedBundleTransform());
			return sb;
		}

		/// <summary>
		/// Defines the <see cref="LastModifiedBundleTransform" />
		/// </summary>
		public class LastModifiedBundleTransform : IBundleTransform
		{
			/// <summary>
			/// For cache busting
			/// </summary>
			/// <param name="context"></param>
			/// <param name="response"></param>
			public void Process(BundleContext context, BundleResponse response)
			{
				foreach (var file in response.Files)
				{
					var lastWrite = File.GetLastWriteTime(HostingEnvironment.MapPath(file.IncludedVirtualPath)).Ticks.ToString();
					file.IncludedVirtualPath = string.Concat(file.IncludedVirtualPath, "?v=", lastWrite);
				}
			}
		}
	}
}
