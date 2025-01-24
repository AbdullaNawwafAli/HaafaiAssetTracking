namespace HaafaiAssetTrackingApp.Models.ViewModels
{
    public class StaffAssetHistoryViewModel
    {
        //used to get the Asset Details involving the staffAssethistory table by joing with the asset table
        public int AssetNo { get; set; }

        public int StaffId { get; set; }

        public string AssetType {  get; set; }

        public DateTime AssignedDate { get; set; }
            
        public DateTime LastReturnedDate { get; set; }

    }
}
