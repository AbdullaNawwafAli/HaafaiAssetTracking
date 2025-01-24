using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaafaiAssetTrackingApp.Models.ViewModels
{
    public class AssetStaffFormViewModel
    {
        //Used to get Data to the create/edit forms and back
        public int? AssetNo { get; set; }
        public List<SelectListItem> type { get; set; }
        public string AssetType { get; set; }

        public List<SelectListItem> status { get; set; }
        public string AssetStatus { get; set; }

        public DateTime PurchasedDate { get; set; }

        public DateTime? DiscardedDate { get; set; }

        public int? staffId { get; set; }

        public DateTime? AssignedDate { get; set; }

        public DateTime? LastReturnedDate { get; set; }



    }
}
