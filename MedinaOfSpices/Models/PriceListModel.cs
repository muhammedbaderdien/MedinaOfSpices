namespace MedinaOfSpices.Models
{
	using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// Defines the <see cref="PriceListModel" />
	/// </summary>
	public class PriceListModel
	{
		/// <summary>
		/// Gets or sets the Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the Title
		/// </summary>
		[DataType(DataType.Text), Display(Name = "Title")]
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the Description
		/// </summary>
		[DataType(DataType.Text), Display(Name = "Description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the Weight
		/// </summary>
		[DataType(DataType.Text), Display(Name = "Weight")]
		[Required]
		public string Weight { get; set; }

		/// <summary>
		/// Gets or sets the Price
		/// </summary>
		[DataType(DataType.Currency), Display(Name = "Price")]
		[Required]
		public string Price { get; set; }
	}
}
