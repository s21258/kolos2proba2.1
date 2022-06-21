using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2proba2.Models
{
    public class DbContext : using Microsoft.EntityFrameworkCore;
    
    namespace kolos2proba2.Models {
        public class DbContext : DbContext {
            public DbContext() { }
            public DbContext(DbContextOptions options) : base (options) { }
    
            public DbSet<File> Files { get; set; }
            public DbSet<Member> Members { get; set; }
            public DbSet<Membership> Memberships { get; set; }
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Team> Teams { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder){
                modelBuilder.Entity<Organization>(e=>{
                    e.ToTable("Organization");
                    e.HasKey(e=>e.OrganizationID);
                    e.Property(e=>e.OrganizationName).HasMaxLength(100).IsRequired();
                    e.Property(e=>e.OrganizationDomain).HasMaxLength(50).IsRequired();
                });
                    modelBuilder.Entity<Member>(e=>{
                    e.ToTable("Member");
                    e.HasKey(e=>e.MemberID);
                    e.Property(e=>e.OrganizationId);
                    e.Property(e=>e.MemberName).HasMaxLength(20).IsRequired();
                    e.Property(e=>e.MemberSurname).HasMaxLength(50).IsRequired();
                    e.Property(e=>e.MemberNickName).HasMaxLength(20).IsRequired();
                    e.HasOne(e=>e.Organization).WithMany(e=>e.Members)
                });
            }
        }
    }
    {
        
    }
}