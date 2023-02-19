using System.ComponentModel.DataAnnotations;

namespace Portfolio_website.Models
{
    public class Portfolio_Data
    {
        [Key]
        public Guid Id { get; set; }
        public string Proj_Name { get; set; }
        public string Proj_Description { get; set; }
        public string Proj_Type { get; set;}
        public string Proj_Language { get; set; }
        public string Pic_1 { get; set; }
        public string Pic_2 { get; set; }
        public string Pic_3 { get; set; }
        public string video { get; set; }
        public string proj_code { get; set;}
    }
}
