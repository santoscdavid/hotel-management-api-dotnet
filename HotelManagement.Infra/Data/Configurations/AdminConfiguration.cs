using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelManagement.Domain.Entities;

namespace HotelManagement.Infrastructure.Persistence.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Permissions)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasOne(a => a.Employee)
                   .WithOne()
                   .HasForeignKey<Admin>(a => a.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Username).IsUnique();
        }
    }
}
