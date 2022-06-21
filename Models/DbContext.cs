using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


    namespace kolos2proba2.Models {
        public class DbContext : DbContext {
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
                    e.Property(e=>e.MemberName).HasMaxLength(20).IsRequired();
                    e.Property(e=>e.MemberSurname).HasMaxLength(50).IsRequired();
                    e.Property(e=>e.MemberNickName).HasMaxLength(20).IsRequired();
                    e.HasOne(e=>e.Organization).WithMany(e=>e.Members).HasForeignKey(e=>e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);
                    
                });
                modelBuilder.Entity<Team>(e=>{
                    e.ToTable("Team");
                    e.HasKey(e=>e.TeamID);
                    e.Property(e=>e.TeamName).HasMaxLength(50).IsRequired();
                    e.Property(e=>e.TeamDescription).HasMaxLength(500).IsRequired(false);
                    e.HasOne(e=>e.Organization).WithMany(e=>e.Members).HasForeignKey(e=>e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);
                    
                });
                modelBuilder.Entity<Membership>(e=>{
                    e.ToTable("Membership");
                    e.HasKey(e=>new{e.MemberID, e.TeamID});
                    e.Property(e=>e.MembershipDate).IsRequired();
                    e.HasOne(e=>e.Member).WithMany(e=>e.Memberships).HasForeignKey(e=>e.MemberID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasOne(e=>e.Team).WithMany(e=>e.Memberships).HasForeignKey(e=>e.TeamID).OnDelete(DeleteBehavior.ClientCascade);

                });
                modelBuilder.Entity<File>(e=>{
                    e.ToTable("File");
                    e.HasKey(e=>new{e=>FileID, e.TeamID});
                    e.Property(e=>e.FileName).HasMaxLength(100).IsRequired();
                    e.Property(e=>e.FileExtension).HasMaxLength(4).IsRequired();
                    e.Property(e=>e.FileSize).IsRequired();
                    e.HasOne(e=>e.Team).WithMany(e=>e.Files).HasForeignKey(e=>e.TeamID).OnDelete(DeleteBehavior.ClientCascade);
                });
            }
        }
    }