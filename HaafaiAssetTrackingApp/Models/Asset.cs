using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaafaiAssetTrackingApp.Models
{
    public class Asset
    {
        [Key]
        public int AssetNo { get; set; }
        public string AssetType {  get; set; } //Monitor,CPU,Keyboard,Mouse,Printer
        public string AssetStatus { get; set; } //Asssigned,Not Assigned,Discarded

        public DateTime PurchasedDate { get; set; }

        public DateTime? DiscardedDate { get; set; }

        
        public int? staffId { get; set; }
       
        public Staff Staff { get; set; }

        public DateTime? AssignedDate {  get; set; }
        
        public DateTime? LastReturnedDate { get; set; }

 
    }
}
