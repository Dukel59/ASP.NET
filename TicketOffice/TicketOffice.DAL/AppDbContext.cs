using Microsoft.EntityFrameworkCore;
using System;
using TicketOffice.Models;

namespace TicketOffice.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminLogin = "admin";
            string adminPassword = "admin";

            Role adminRole = new Role { Name = adminRoleName };
            Role userRole = new Role { Name = userRoleName };

            User adminUser = new User
            {
                Name = default,
                Age = default,
                Phone = default,
                Email = default,
                Login = adminLogin,
                Password = adminPassword,
                RoleId = adminRole.Id
            };

            string TrainNumber1 = "2B";
            string Destination1 = "Minsk";
            DateTime Departs1 = DateTime.Now;
            int Track1 = 2;

            string TrainNumber2 = "3C";
            string Destination2 = "Kiev";
            DateTime Departs2 = DateTime.Now;
            int Track2 = 8;

            Train train1 = new Train { TrainNumber = TrainNumber1, Destination = Destination1, Departs = Departs1, Track = Track1 };
            Train train2 = new Train { TrainNumber = TrainNumber2, Destination = Destination2, Departs = Departs2, Track = Track2 };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Train>().HasData(new Train[] { train1, train2 });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
