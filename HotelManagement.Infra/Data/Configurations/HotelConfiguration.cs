using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infra.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(h => h.Address)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(h => h.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(h => h.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(h => h.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("now()");

            builder.HasMany(r => r.Rooms)
                   .WithOne(r => r.Hotel)
                   .HasForeignKey(r => r.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Employees)
                   .WithOne(e => e.Hotel)
                   .HasForeignKey(e => e.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(h => h.Name);
            builder.HasIndex(h => h.Email).IsUnique();
        }
    }
}
