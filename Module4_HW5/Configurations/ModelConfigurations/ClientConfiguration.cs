using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW5.Models;

namespace Module4_HW5.Configurations
{
    public class ClientConfiguration
        : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client")
                .HasKey(x => x.ClientId);

            builder.Property(x => x.ClientId)
                .HasColumnName("ClientId")
                .IsRequired();

            builder.Property(x => x.ClientName)
                .HasColumnName("ClientName")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ClientSurname)
                .HasColumnName("ClientSurname")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ClientCompany)
               .HasColumnName("ClientCompany")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.ClientEmail)
               .HasColumnName("ClientEmail")
               .HasMaxLength(100)
               .IsRequired();
        }
    }
}
