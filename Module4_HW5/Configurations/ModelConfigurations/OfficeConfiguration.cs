using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW5.Models;

namespace Module4_HW5.Configurations
{
    public class OfficeConfiguration
        : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office")
                .HasKey(x => x.OfficeId);

            builder.Property(x => x.OfficeId)
                .HasColumnName("OfficeId")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Location)
                .HasColumnName("Location")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
