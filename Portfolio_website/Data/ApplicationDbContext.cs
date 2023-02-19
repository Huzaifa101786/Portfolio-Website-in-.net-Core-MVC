using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio_website.Models;

namespace Portfolio_website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Portfolio_Data> Portfolio_Data { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
	    public DbSet<UserDetails> UserDetails { get; set; }
	}
}