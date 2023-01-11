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
        public DbSet<Client> Clients { get; set; }
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
            modelBuilder.ApplyConfiguration(
                new ClientConfiguration());

            modelBuilder.Entity<Client>().HasData(new List<Client>()
            {
                new Client()
                {
                    ClientId = 1,
                    ClientName = "Client1",
                    ClientSurname = "Client1",
                    ClientCompany = "Company1",
                    ClientEmail = "Email1"
                },
                new Client()
                {
                    ClientId = 2,
                    ClientName = "Client2",
                    ClientSurname = "Client2",
                    ClientCompany = "Company2",
                    ClientEmail = "Email2"
                },
                new Client()
                {
                    ClientId = 3,
                    ClientName = "Client3",
                    ClientSurname = "Client3",
                    ClientCompany = "Company3",
                    ClientEmail = "Email3"
                },
                new Client()
                {
                    ClientId = 4,
                    ClientName = "Client4",
                    ClientSurname = "Client4",
                    ClientCompany = "Company4",
                    ClientEmail = "Email4"
                },
                new Client()
                {
                    ClientId = 5,
                    ClientName = "Client5",
                    ClientSurname = "Client5",
                    ClientCompany = "Company5",
                    ClientEmail = "Email5"
                },
            });

            modelBuilder.Entity<Project>().HasData(new List<Project>()
            {
                new Project()
                {
                    ClientId = 2,
                    Budget = 1,
                    Name = "Project1",
                    StartedDate = DateTime.Now,
                    ProjectId = 1
                },
                new Project()
                {
                    ClientId = 2,
                    Budget = 1,
                    Name = "Project2",
                    StartedDate = DateTime.Now,
                    ProjectId = 2
                },
                new Project()
                {
                    ClientId = 3,
                    Budget = 1,
                    Name = "Project3",
                    StartedDate = DateTime.Now,
                    ProjectId = 3
                },
                new Project()
                {
                    ClientId = 4,
                    Budget = 1,
                    Name = "Project4",
                    StartedDate = DateTime.Now,
                    ProjectId = 4
                },
                new Project()
                {
                    ClientId = 5,
                    Budget = 1,
                    Name = "Project5",
                    StartedDate = DateTime.Now,
                    ProjectId = 5
                },
            });

            modelBuilder.Entity<Title>().HasData(new List<Title>
            {
                new Title() { Name = "Title1", TitleId = 1 },
                new Title() { Name = "Title2A", TitleId = 2 },
                new Title() { Name = "Title3", TitleId = 3 },
                new Title() { Name = "Title4A", TitleId = 4 },
                new Title() { Name = "Title5", TitleId = 5 }
            });
            modelBuilder.Entity<Office>().HasData(new List<Office>
            {
                new Office()
                {
                    Title = "Office1",
                    Location = "Office1",
                    OfficeId = 1
                },
                new Office()
                {
                    Title = "Office2",
                    Location = "Office2",
                    OfficeId = 2
                },
                new Office()
                {
                    Title = "Office3",
                    Location = "Office3",
                    OfficeId = 3
                },
                new Office()
                {
                    Title = "Office4",
                    Location = "Office4",
                    OfficeId = 4
                },
                new Office()
                {
                    Title = "Office5",
                    Location = "Office5",
                    OfficeId = 5
                },
            });
            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                new Employee()
                {
                    EmployeeId = 1,
                    DateOfBirth = DateTime.Now,
                    HiredDate = DateTime.Now,
                    FirstName = "Employee1",
                    LastName = "Employee1",
                    TitleId = 1,
                    OfficeId = 1
                },
                new Employee()
                {
                    EmployeeId = 2,
                    DateOfBirth = DateTime.Now,
                    HiredDate = DateTime.Now,
                    FirstName = "Employee2",
                    LastName = "Employee2",
                    TitleId = 2,
                    OfficeId = 2
                },
                new Employee()
                {
                    EmployeeId = 3,
                    DateOfBirth = DateTime.Now,
                    HiredDate = DateTime.Now,
                    FirstName = "Employee3",
                    LastName = "Employee3",
                    TitleId = 3,
                    OfficeId = 3
                },
                new Employee()
                {
                    EmployeeId = 4,
                    DateOfBirth = DateTime.Now,
                    HiredDate = DateTime.Now,
                    FirstName = "Employee4",
                    LastName = "Employee4",
                    TitleId = 4,
                    OfficeId = 4
                },
                new Employee()
                {
                    EmployeeId = 5,
                    DateOfBirth = DateTime.Now,
                    HiredDate = DateTime.Now,
                    FirstName = "Employee5",
                    LastName = "Employee5",
                    TitleId = 5,
                    OfficeId = 5
                },
            });

            modelBuilder.Entity<EmployeeProject>().HasData(new List<EmployeeProject>
            {
                new EmployeeProject()
                {
                    EmployeeId = 1,
                    EmployeeProjectId = 1,
                    ProjectId = 1,
                    Rate = 1,
                    StartedDate =
                    DateTime.Now
                },
                new EmployeeProject()
                {
                    EmployeeId = 2,
                    EmployeeProjectId = 2,
                    ProjectId = 2,
                    Rate = 1,
                    StartedDate = DateTime.Now
                },
                new EmployeeProject()
                {
                    EmployeeId = 3,
                    EmployeeProjectId = 3,
                    ProjectId = 3,
                    Rate = 1,
                    StartedDate = DateTime.Now
                },
                new EmployeeProject()
                {
                    EmployeeId = 4,
                    EmployeeProjectId = 4,
                    ProjectId = 4,
                    Rate = 1,
                    StartedDate = DateTime.Now
                },
                new EmployeeProject()
                {
                    EmployeeId = 5,
                    EmployeeProjectId = 5,
                    ProjectId = 5,
                    Rate = 1,
                    StartedDate = DateTime.Now
                },
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json")
            .Build();
            optionsBuilder
                 .UseLazyLoadingProxies()
                .UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
