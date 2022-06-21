using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


    namespace kolos2proba2.Models {
        public class TeamsDbContext : DbContext {
            public TeamsDbContext(DbContextOptions options) : base (options) { }
    
            public DbSet<File> Files { get; set; }
            public DbSet<Member> Members { get; set; }
            public DbSet<Membership> Memberships { get; set; }
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Team> Teams { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder){
                var organizations = new List<Organization>{
                    new Organization{
                        OrganizationID = 1,
                        OrganizationName = "pjatk",
                        OrganizationDomain = "pjwstk.edu.pl"
                    }
                };
                
                modelBuilder.Entity<Organization>(e=>{
                    e.ToTable("Organization");
                    e.HasKey(e=>e.OrganizationID);
                    e.Property(e=>e.OrganizationName).HasMaxLength(100).IsRequired();
                    e.Property(e=>e.OrganizationDomain).HasMaxLength(50).IsRequired();
                    e.HasData(organizations);
                });
                var members = new List<Member>{
                    new Member{
                        MemberID=1,
                        MemberName ="Jan",
                        MemberSurname = "Pawel",
                        OrganizationID = 1
                    }
                };
                    modelBuilder.Entity<Member>(e=>{
                    e.ToTable("Member");
                    e.HasKey(e=>e.MemberID);
                    e.Property(e=>e.MemberName).HasMaxLength(20).IsRequired();
                    e.Property(e=>e.MemberSurname).HasMaxLength(50).IsRequired();
                    e.Property(e=>e.MemberNickName).HasMaxLength(20).IsRequired(false);
                    e.HasOne(e=>e.Organization).WithMany(e=>e.Members).HasForeignKey(e=>e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasData(members);
                });

                var teams = new List<Team>{
                    new Team{
                        TeamID=1,
                        TeamName="24c",
                        TeamDescription = "wieczna meka",
                        OrganizationID = 1
                    }
                };
                modelBuilder.Entity<Team>(e=>{
                    e.ToTable("Team");
                    e.HasKey(e=>e.TeamID);
                    e.Property(e=>e.TeamName).HasMaxLength(50).IsRequired();
                    e.Property(e=>e.TeamDescription).HasMaxLength(500).IsRequired(false);
                    e.HasOne(e=>e.Organization).WithMany(e=>e.Teams).HasForeignKey(e=>e.OrganizationID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasData(teams);
                });
                var memberships = new List<Membership>{
                    new Membership{
                        MemberID = 1,
                        TeamID = 1,
                        MembershipDate = new System.DateTime(2019,09,09)
                    }
                };
                modelBuilder.Entity<Membership>(e=>{
                    e.ToTable("Membership");
                    e.HasKey(e=>new{e.MemberID, e.TeamID});
                    e.Property(e=>e.MembershipDate).IsRequired();
                    e.HasOne(e=>e.Member).WithMany(e=>e.Memberships).HasForeignKey(e=>e.MemberID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasOne(e=>e.Team).WithMany(e=>e.Memberships).HasForeignKey(e=>e.TeamID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasData(memberships);
                });
                var files = new List<File>{
                    new File{
                        FileID=1,
                        TeamID = 1,
                        FileName = "kolos2",
                        FileExtension = ".jpg",
                        FileSize = 500
                    }
                };
                modelBuilder.Entity<File>(e=>{
                    e.ToTable("File");
                    e.HasKey(e=>new{e.FileID, e.TeamID});
                    e.Property(e=>e.FileName).HasMaxLength(100).IsRequired();
                    e.Property(e=>e.FileExtension).HasMaxLength(4).IsRequired();
                    e.Property(e=>e.FileSize).IsRequired();
                    e.HasOne(e=>e.Team).WithMany(e=>e.Files).HasForeignKey(e=>e.TeamID).OnDelete(DeleteBehavior.ClientCascade);
                    e.HasData(files);
                });
            }
        }
    }