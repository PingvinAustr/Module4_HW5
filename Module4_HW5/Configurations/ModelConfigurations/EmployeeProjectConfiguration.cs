using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW5.Models;

namespace Module4_HW5.Configurations
{
    public class EmployeeProjectConfiguration
        : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject")
                .HasKey(x => x.EmployeeProjectId);

            builder.Property(x => x.EmployeeProjectId)
                .HasColumnName("EmployeeProjectId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Rate)
                .HasColumnName("Rate")
                .HasColumnType("money")
                .IsRequired();

            builder.Property(x => x.StartedDate)
                .HasColumnName("StartedDate")
                .IsRequired();

            builder.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeId")
                .IsRequired();

            builder.Property(x => x.ProjectId)
                .HasColumnName("ProjectId")
                .IsRequired();

            builder
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProject)
                .HasForeignKey(ep => ep.EmployeeId);

            builder
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(ep => ep.ProjectId);
        }
    }
}
