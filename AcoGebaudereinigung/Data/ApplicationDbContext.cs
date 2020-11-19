using System;
using System.Collections.Generic;
using System.Text;
using AcoGebaudereinigung.Models;
using AcoGebaudereinigung.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AcoGebaudereinigung.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Jobs> Jobs {get; set;}
        public DbSet<gallery> Gallery { get; set; }

        public DbSet<EmailSenders> EmailSenders { get; set; }
    }
}
