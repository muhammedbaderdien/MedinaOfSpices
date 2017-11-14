namespace MedinaOfSpices.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// Defines the <see cref="EmailModel" />
	/// </summary>
	public class EmailModel
	{
		/// <summary>
		/// Gets or sets the Id
		/// </summary>
		[DatabaseGenerat‌​ed(DatabaseGeneratedOp‌​tion.None)]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the ToEmail
		/// </summary>
		[DataType(DataType.EmailAddress), Display(Name = "To")]
		[Required]
		public string ToEmail { get; set; }

		/// <summary>
		/// Gets or sets the EMailBody
		/// </summary>
		[Display(Name = "Body")]
		[DataType(DataType.MultilineText)]
		public string EMailBody { get; set; }

		/// <summary>
		/// Gets or sets the EmailAddress
		/// </summary>
		[Display(Name = "Email Address")]
		[DataType(DataType.EmailAddress)]
		[Required]
		public string EmailAddress { get; set; }

		/// <summary>
		/// Gets or sets the ContactNo
		/// </summary>
		[Display(Name = "Contact No")]
		[Required]
		[DataType(DataType.Text)]
		public string ContactNo { get; set; }

		/// <summary>
		/// Gets or sets the FullName
		/// </summary>
		[Display(Name = "Full Name")]
		[Required]
		[DataType(DataType.Text)]
		public string FullName { get; set; }

		/// <summary>
		/// Gets or sets the Subject
		/// </summary>
		[Display(Name = "Subject")]
		[DataType(DataType.Text)]
		public string Subject { get; set; }

		/// <summary>
		/// Gets or sets the EmailCC
		/// </summary>
		[DataType(DataType.EmailAddress)]
		[Display(Name = "CC")]
		public string EmailCC { get; set; }

		/// <summary>
		/// Gets or sets the EmailBCC
		/// </summary>
		[DataType(DataType.EmailAddress)]
		[Display(Name = "BCC")]
		public string EmailBCC { get; set; }

		/// <summary>
		/// Gets or sets the CreatedOn
		/// </summary>
		[DataType(DataType.DateTime)]
		[Display(Name = "Created On")]
		public DateTime CreatedOn { get; set; }
	}
}
