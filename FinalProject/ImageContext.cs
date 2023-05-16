using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class ImageContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ImageClass> ImagesClass { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FinalProjectDB;Integrated Security=True;TrustServerCertificate=true");
        }
    }
}
