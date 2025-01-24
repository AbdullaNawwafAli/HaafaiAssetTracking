namespace HaafaiAssetTrackingApp.Models
{
    public class StaffAssetHistory
    {
        public int Id { get; set; }
        public int staffId { get; set; }

        public Staff AssignedStaff { get; set; }

        public int AssetNo { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime LastReturnedDate { get; set; }
    }
}
