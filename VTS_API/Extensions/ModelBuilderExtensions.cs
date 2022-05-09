using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VTS_API.Models;

namespace VTS_API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void FluentAPIApply(this ModelBuilder modelBuilder)
        {
            #region User
            var user = modelBuilder.Entity<User>();
            user.ToTable("User");
            user.HasKey(u => u.UserID).HasName("UserID");
            user.Property(u => u.Name).HasMaxLength(100).IsRequired();
            user.HasIndex(u => u.Name).IsUnique();
            user.Property(u => u.MobileNumber).HasMaxLength(10);
            user.Property(u => u.Organization).HasMaxLength(100);
            user.Property(u => u.Address).HasMaxLength(100);
            user.Property(u => u.EmailAddress).HasMaxLength(100);
            user.Property(u => u.Location).HasMaxLength(100);
            ApplyCommonProp<User>(user);
            #endregion

            #region Device
            var device = modelBuilder.Entity<Device>();
            device.ToTable("Device");
            device.HasKey(d => d.DeviceID).HasName("DeviceID");
            device.Property(d => d.DeviceName).HasMaxLength(100).IsRequired();
            device.HasIndex(d => d.DeviceName).IsUnique();
            ApplyCommonProp<Device>(device);
            #endregion

            #region Vehicle
            var vehicle = modelBuilder.Entity<Vehicle>();
            vehicle.ToTable("Vehicle");
            vehicle.HasKey(v => v.VehicleNumber).HasName("VehicleNumber");
            vehicle.Property(v => v.VehicleType).IsRequired().HasMaxLength(100);
            vehicle.Property(v => v.ChassisNumber).IsRequired().HasMaxLength(100);
            vehicle.Property(v => v.EngineNumber).IsRequired().HasMaxLength(100);
            vehicle.Property(v => v.ManufacturingYear).IsRequired();
            vehicle.Property(v => v.LoadCarryingCapacity).IsRequired().HasMaxLength(10);
            vehicle.Property(v => v.MakeOfVehicle).HasMaxLength(100);
            vehicle.Property(v => v.ModelNumber).IsRequired().HasMaxLength(100);
            vehicle.Property(v => v.BodyType).HasMaxLength(100);
            vehicle.Property(v => v.OrganisationName).HasMaxLength(100);

            vehicle.Property(v => v.UserID).IsRequired();

            vehicle.HasOne<User>(u => u.User)
            .WithOne(v => v.Vehicle)
            .HasForeignKey<Vehicle>(i => i.UserID).OnDelete(DeleteBehavior.Restrict);

            vehicle.Property(v => v.DeviceID);

            vehicle.HasOne<Device>(d => d.Device)
            .WithOne(v => v.Vehicle)
            .HasForeignKey<Vehicle>(i => i.DeviceID).OnDelete(DeleteBehavior.Restrict);

            ApplyCommonProp<Vehicle>(vehicle);
            #endregion


        }

        private static void ApplyCommonProp<TEntity>(EntityTypeBuilder<TEntity> entityTypeBuilder) where TEntity : class
        {
            entityTypeBuilder.Property("CreatedOn").HasDefaultValueSql("getDate()").IsRequired();
            entityTypeBuilder.Property("CreatedBy").HasMaxLength(256).IsRequired();
            entityTypeBuilder.Property("ModifiedBy").HasMaxLength(256);
            entityTypeBuilder.Property("ModifiedOn");
        }
    }
}
