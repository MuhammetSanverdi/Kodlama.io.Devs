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
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialMediaType> SocialMediaTypes { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaioDevsConnectionString")));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasMany(p => p.LanguageTechnologies);
            });

            modelBuilder.Entity<LanguageTechnology>(p =>
            {
                p.ToTable("LanguageTechnologies").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.ProgrammingLanguageId).HasColumnName("LanguageId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p=>p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                p.HasMany(p => p.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");

                p.HasMany(p => p.UserOperationClaim);
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<SocialMedia>(p =>
            {
                p.ToTable("SocialMedias").HasKey(k=>k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.SocialMediaTypeId).HasColumnName("TypeId");
                p.Property(p => p.Address).HasColumnName("Address");

                p.HasOne(p => p.SocialMediaType);
                p.HasOne(p => p.User);
            });

            modelBuilder.Entity<SocialMediaType>(p =>
            {
                p.ToTable("SocialMediaTypes").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");

                p.HasMany(p => p.SocialMedias);
            });

            ProgrammingLanguage[] programmingLanguageSeed = { new(1, "C#"), new(2, "Python"), new(3, "JavaScript"), new(4, "Python"), new(5, "C++"), new(6, "C"),new(7,"Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeed);

            LanguageTechnology[] languageTechnology = { new(1, 1, ".NET"), new(2, 1, "ASP.NET"), new(3, 1, "WPF"), new(4, 7, "Spring"), new(5, 7, "JSP"), new(6, 3, "Vue"), new(7, 3, "React"), new(8, 3, "Node") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnology);

            OperationClaim[] operationClaimSeed = { new(1, "admin"), new(2, "moderator"), new(3, "user") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeed);

            UserOperationClaim[] userOperationClaimSeed = { new(1, 1, 1) };
            modelBuilder.Entity<UserOperationClaim>().HasData(userOperationClaimSeed);

            SocialMediaType[] socialMediaTypeSeed = { new(1, "Github"), new(2, "Linkedin"), new(3, "Stack Overflow") };
            modelBuilder.Entity<SocialMediaType>().HasData(socialMediaTypeSeed);

            SocialMedia[] socialMediaSeed = { new(1, 1, 1, "https://github.com/MuhammetSanverdi") };
            modelBuilder.Entity<SocialMedia>().HasData(socialMediaSeed);


        }
    }
}
