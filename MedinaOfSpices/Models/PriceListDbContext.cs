namespace MedinaOfSpices.Models
{
	using System.Data.Entity;

	/// <summary>
	/// Defines the <see cref="PriceListDbContext" />
	/// </summary>
	public class PriceListDbContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PriceListDbContext"/> class.
		/// </summary>
		public PriceListDbContext()
			: base("name=VRS")
		{
		}

		/// <summary>
		/// The Create
		/// </summary>
		/// <returns>The <see cref="PriceListDbContext"/></returns>
		public static PriceListDbContext Create()
		{
			return new PriceListDbContext();
		}

		/// <summary>
		/// Gets or sets the PriceListModels
		/// </summary>
		public DbSet<PriceListModel> PriceListModels { get; set; }

		/// <summary>
		/// Gets or sets the EmailModel
		/// </summary>
		public DbSet<EmailModel> EmailModel { get; set; }
	}
}
