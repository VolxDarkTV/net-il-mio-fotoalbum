﻿using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject
{
    public class ImageContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ImageClass> ImagesClass { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FinalProjectDBMulti;Integrated Security=True;TrustServerCertificate=true");
        }
    }
}
