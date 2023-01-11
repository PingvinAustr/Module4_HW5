using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW5.Models;

namespace Module4_HW5.Configurations
{
    public class EmployeeConfiguration
        : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee")
                .HasKey(x => x.EmployeeId);

            builder.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.HiredDate)
                .HasColumnName("HiredDate")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .HasColumnType("date");

            builder.HasOne(d => d.Title)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Office)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.EmployeeProject)
                .WithOne(ep => ep.Employee)
                .HasForeignKey(ep => ep.EmployeeId);
        }
    }
}
