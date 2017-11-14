namespace MedinaOfSpices.Controllers
{
	using Dapper;
	using MedinaOfSpices.Models;
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data;
	using System.Data.Entity;
	using System.Data.SqlClient;
	using System.Threading.Tasks;
	using System.Web.Helpers;
	using System.Web.Mvc;

	/// <summary>
	/// Defines the <see cref="HomeController" />
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// The Index
		/// </summary>
		/// <returns>The <see cref="ActionResult"/></returns>
		[OutputCache(CacheProfile = "CachePerNoParams")]
		public async Task<ActionResult> Index()
		{
			List<PriceListModel> pricelist = null;
			try
			{
				using (var db = new PriceListDbContext())
				{
					pricelist = await db.PriceListModels.ToListAsync().ConfigureAwait(false);
				}

				return View(new Tuple<List<PriceListModel>, EmailModel>(pricelist, new EmailModel()));
			}
			catch (Exception)
			{
				Response.Cache.SetNoStore();
				Response.Cache.SetNoServerCaching();
				pricelist?.Clear();

				return View(new Tuple<List<PriceListModel>, EmailModel>(pricelist, new EmailModel()));
			}
		}

		/// <summary>
		/// The SendEmail
		/// </summary>
		/// <param name="emailModel">The <see cref="EmailModel"/></param>
		/// <returns>The <see cref="ActionResult"/></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SendEmail([Bind(Prefix = "Item2")] EmailModel emailModel)
		{
			try
			{
				WebMail.SmtpServer = "smtp.gmail.com";
				WebMail.SmtpPort = 587;
				WebMail.SmtpUseDefaultCredentials = true;
				WebMail.EnableSsl = true;

				WebMail.UserName = ConfigurationManager.AppSettings["CCEmail"];
				WebMail.Password = ConfigurationManager.AppSettings["CCEmailPassword"];

				WebMail.From = ConfigurationManager.AppSettings["CCEmail"];
				WebMail.EnableSsl = true;

				WebMail.Send(
					emailModel.ToEmail,
					emailModel.Subject,
					emailModel.FullName + Environment.NewLine + emailModel.EmailAddress + Environment.NewLine + emailModel.ContactNo + Environment.NewLine + emailModel.EMailBody,
					cc: emailModel.EmailCC,
					bcc: emailModel.EmailBCC,
					isBodyHtml: true);

				using (IDbConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["VRS"].ConnectionString))
				{
					var insertQuery = @"INSERT INTO [dbo].[EmailModels]([ToEmail], [Subject], [EMailBody], [FullName], [EmailCC], [EmailBCC], [EmailAddress], [ContactNo])
										   VALUES (@ToEmail, @Subject, @EMailBody, @FullName, @EmailCC, @EmailBCC, @EmailAddress, @ContactNo)";

					dbConn.Execute(insertQuery, new
					{
						emailModel.ToEmail,
						emailModel.Subject,
						emailModel.FullName,
						emailModel.EMailBody,
						emailModel.EmailCC,
						emailModel.EmailBCC,
						emailModel.EmailAddress,
						emailModel.ContactNo
					});
				}

				ViewBag.Status = "Email Sent Successfully.";
			}
			catch (Exception ex)
			{
				ViewBag.Status = "Problem while sending email, Please check details: " + ex.Message;
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
