using System.ComponentModel.DataAnnotations;

namespace HaafaiAssetTrackingApp.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        public string NicNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; } //IT,Support,HR

        public List<Asset> Assets { get; set; }

    }
}
