using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infra.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Number)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(r => r.PricePerNight)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(r => r.RoomType)
                .HasConversion<string>()
                .IsRequired();

            builder.HasOne(r => r.Hotel)
                .WithMany(r => r.Rooms)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => new { r.HotelId, r.Number })
                   .IsUnique();
        }
    }
}
