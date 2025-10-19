using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infra.Data.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.FullName)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(g => g.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(g => g.DocumentNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(g => g.DateOfBirth)
                   .IsRequired()
                   .HasColumnType("date");

            builder.Property(g => g.CreatedAt)
                  .IsRequired()
                  .HasDefaultValueSql("now()");

            builder.HasIndex(g => g.Email).IsUnique();
            builder.HasIndex(g => g.DocumentNumber).IsUnique();
        }
    }
}
