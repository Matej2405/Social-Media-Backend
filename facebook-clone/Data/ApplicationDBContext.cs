using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_clone.Models;
using Microsoft.EntityFrameworkCore;

namespace facebook_clone.Data
{
    public class ApplicationDBContext : DbContext	// uzimamo DbContext iz EntityFrameworkCore
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) //konstuktor
        : base(dbContextOptions)
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; } //dodajemo DbSet koji ce biti tabela u bazi podataka
        public DbSet<Comment> Comments { get; set; } //dodajemo DbSet koji ce biti tabela u bazi podataka
    }
}