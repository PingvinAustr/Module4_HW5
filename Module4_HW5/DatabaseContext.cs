using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4_HW5.Configurations;
using Module4_HW5.Models;

namespace Module4_HW5
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(
                new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(
                new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(
                new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(
                new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(
                new TitleConfiguration());

            modelBuilder.Entity<Client>().HasData(new List<Client>()
            {
                new Client()
                {
                    ClientId = 1,
                    ClientName = "Client",
                    ClientSurname = "Client",
                    ClientCompany = "Company",
                    ClientEmail = "Email"
                },
                new Client()
                {
                    ClientId = 2,
                    ClientName = "Client",
                    ClientSurname = "Client",
                    ClientCompany = "Company",
                    ClientEmail = "Email"
                },
                new Client()
                {
                    ClientId = 3,
                    ClientName = "Client",
                    ClientSurname = "Client",
                    ClientCompany = "Company",
                    ClientEmail = "Email"
                },
                new Client()
                {
                    ClientId = 4,
                    ClientName = "Client",
                    ClientSurname = "Client",
                    ClientCompany = "Company",
                    ClientEmail = "Email"
                },
                new Client()
                {
                    ClientId = 5,
                    ClientName = "Client",
                    ClientSurname = "Client",
                    ClientCompany = "Company",
                    ClientEmail = "Email"
                },
            });

            modelBuilder.Entity<Project>().HasData(new List<Project>()
            {
                new Project()
                {
                    ClientId = 2,
                    Budget = 1,
                    Name = "Project",
                    StartedDate = DateTime.Now,
                    ProjectId = 1
                },
                new Project()
                {
                    ClientId = 2,
                    Budget = 1,
                    Name = "Project",
                    StartedDate = DateTime.Now,
                    ProjectId = 2
                },
                new Project()
                {
                    ClientId = 3,
                    Budget = 1,
                    Name = "Project",
                    StartedDate = DateTime.Now,
                    ProjectId = 3
                },
                new Project()
                {
                    ClientId = 4,
                    Budget = 1,
                    Name = "Project",
                    StartedDate = DateTime.Now,
                    ProjectId = 4
                },
                new Project()
                {
                    ClientId = 5,
                    Budget = 1,
                    Name = "Project",
                    StartedDate = DateTime.Now,
                    ProjectId = 5
                },
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json")
            .Build();
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
