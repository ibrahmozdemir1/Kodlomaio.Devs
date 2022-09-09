using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTehcnologies> ProgrammingTehcnologiess { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }



        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
              // base.OnConfiguring(
                //   optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaioDevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.LanguageName).HasColumnName("LanguageName");

                a.HasMany(p => p.ProgrammingTehcnologiess);
            });

            modelBuilder.Entity<ProgrammingTehcnologies>(a =>
            {
                a.ToTable("ProgrammingTechologiess").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.TehcnologyName).HasColumnName("TechnologyName");
                a.Property(p => p.TehcnologyDescription).HasColumnName("TechnologyDescription");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");

                a.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingTehcnologies[] programmingTechonologiesEntitySeeds = { 
            new(1,4,"Web Sitelerinde dinamiklik için kullanılır.","JavaScript"),new(2,3,"Web Sitelerinde dinamiklik için kullanılır.","JavaScript")};
            modelBuilder.Entity<ProgrammingTehcnologies>().HasData(programmingTechonologiesEntitySeeds);
        }
    }
}
