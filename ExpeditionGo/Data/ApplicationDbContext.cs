using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ExpeditionGo.Models;

namespace ExpeditionGo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<BlogLeft> Blogs { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        
    }
}

