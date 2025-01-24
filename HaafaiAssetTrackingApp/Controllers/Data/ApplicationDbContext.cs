using HaafaiAssetTrackingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HaafaiAssetTrackingApp.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<StaffAssetHistory> staffAssetHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, NicNo = "n333d3", Name = "Jason David", Department = "IT" },
                new Staff { StaffId = 2, NicNo = "n4f4f4f", Name = "Larry Frank", Department = "Support" },
                new Staff { StaffId = 3, NicNo = "4fin4fn", Name = "Annie Taylor", Department = "HR" }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { AssetNo = 1, AssetType = "Monitor", AssetStatus = "Assigned", PurchasedDate = new DateTime(2023, 1, 3), staffId = 1, AssignedDate = new DateTime(2023, 1, 4), LastReturnedDate = new DateTime(2023, 1, 5) }
                ,
                new Asset { AssetNo = 2, AssetType = "CPU", AssetStatus = "Not Assigned", PurchasedDate = new DateTime(2023, 1, 3), staffId = null, LastReturnedDate = new DateTime(2023, 1, 4) }

                );

            modelBuilder.Entity<StaffAssetHistory>().HasData(
                new StaffAssetHistory { Id = 1, staffId = 1, AssetNo = 1, AssignedDate = new DateTime(2023, 1, 4), LastReturnedDate = new DateTime(2023, 1, 5) },
                new StaffAssetHistory { Id = 2, staffId = 1, AssetNo = 2, AssignedDate = new DateTime(2023, 1, 3), LastReturnedDate = new DateTime(2023, 1, 4) }
                );


        }



    }
}
