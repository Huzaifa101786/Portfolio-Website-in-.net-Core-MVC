using System.ComponentModel.DataAnnotations;

namespace Portfolio_website.Models
{
    public class Experience
    {
        [Key]
        public Guid Experience_Id { get; set; }
        public string Domain_Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        /*public string Name { get; set; }*/
       /* public string Image { get; set; }*/
        public string Image { get; set; }
        public string Company_Name { get; set; }
        public string Experience_type { get; set; }   /*frontend or backend*/
        public string position { get; set; }

    }
}
