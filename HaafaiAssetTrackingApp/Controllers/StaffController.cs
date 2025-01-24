using System.Net.NetworkInformation;
using HaafaiAssetTrackingApp.Controllers.Data;
using HaafaiAssetTrackingApp.Models;
using HaafaiAssetTrackingApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;



namespace HaafaiAssetTrackingApp.Controllers
{
    public class StaffController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StaffController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //Creating a list of staff members
            List<Staff> staffs = _db.Staffs.ToList();


            return View(staffs);
        }

        public IActionResult StaffIndex(int  staffId)
        {
            //finding the staff member that was clicked on
            var staffs = _db.Staffs
            .FirstOrDefault(p => p.StaffId == staffId);

            //finding the assets that currently belong to the staff member that was clicked on
            var assets = _db.Assets
           .ToList().FindAll(p => p.staffId == staffId);

            //joining the staffassethistory table and asset table to get more information on the asset
            var staffull = (from staffhistories in _db.staffAssetHistories
                               join assetdetails in _db.Assets
                                                     on staffhistories.AssetNo equals assetdetails.AssetNo
                                                     select new StaffAssetHistoryViewModel
                                                     {
                                                         AssetNo = staffhistories.AssetNo,
                                                         StaffId = staffhistories.staffId,
                                                         AssetType = assetdetails.AssetType,
                                                         AssignedDate = staffhistories.AssignedDate,
                                                         LastReturnedDate = staffhistories.LastReturnedDate
                                                     }).Where(p => p.StaffId == staffId) .ToList();


            // Check if staff record exists
            if (staffs == null)
            {
                return NotFound(); // Return a 404 if staff record is not found
            }

            if (assets == null)
            {
                return NotFound(); // Return a 404 if asset record is not found
            }


            //Creating the  viewModel and populate it
            StaffAssetViewModel savm = new StaffAssetViewModel();
            savm.staff = staffs;
            savm.assets = assets;
            savm.staffHistories = staffull;
   

            // Return viewModel to the view
            return View(savm);

        }
    }
}
