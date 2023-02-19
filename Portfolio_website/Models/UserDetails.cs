using System.ComponentModel.DataAnnotations;

namespace Portfolio_website.Models
{
    public class UserDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string AboutMe { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }


    }
}
