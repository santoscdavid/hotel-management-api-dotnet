using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infra.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.TotalPrice)
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(r => r.CheckIn)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(r => r.CheckOut)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Guest)
                .WithMany()
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
               .IsRequired()
               .HasDefaultValueSql("now()");

            builder.HasOne(r => r.Guest)
                   .WithMany()
                   .HasForeignKey(r => r.GuestId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Room)
                   .WithMany()
                   .HasForeignKey(r => r.RoomId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => new { r.GuestId, r.CheckIn });
            builder.HasIndex(r => new { r.RoomId, r.CheckIn });
        }
    }
}
