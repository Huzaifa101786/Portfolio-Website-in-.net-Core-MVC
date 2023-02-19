using System.ComponentModel.DataAnnotations;

namespace Portfolio_website.Models
{
	public class ContactUs
	{
		[Key]
		public Guid ContactId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }

	}
}
