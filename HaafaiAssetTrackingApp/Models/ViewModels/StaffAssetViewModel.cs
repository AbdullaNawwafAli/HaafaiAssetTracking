namespace HaafaiAssetTrackingApp.Models.ViewModels
{
    public class StaffAssetViewModel
    {

        //used to get data to the staffindex page
        public Staff staff {  get; set; }

        public List<Asset> assets { get; set; }

        public List<StaffAssetHistoryViewModel> staffHistories { get; set; }
       
    }
}
