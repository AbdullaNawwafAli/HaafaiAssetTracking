using HaafaiAssetTrackingApp.Controllers.Data;
using HaafaiAssetTrackingApp.Models;
using HaafaiAssetTrackingApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HaafaiAssetTrackingApp.Controllers
{
    public class AssetController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AssetController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Asset> assets = _db.Assets.ToList();

            return View(assets);
        }


        public IActionResult Create()
        {

            var status = new List<SelectListItem>
            {
            new SelectListItem {Text = "Assigned" },
            new SelectListItem { Text = "Not Assigned" },
            new SelectListItem { Text = "Discarded" },
            };

            var type = new List<SelectListItem>
            {
            new SelectListItem {Text = "Monitor" },
            new SelectListItem { Text = "CPU" },
            new SelectListItem { Text = "Keyboard" },
            new SelectListItem { Text = "Mouse" },
            new SelectListItem { Text = "Printer" },
            };

            var model = new AssetStaffFormViewModel
            {
                status = status,
                type = type
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AssetStaffFormViewModel model)
        {
               var newasset = new Asset
                {
                    AssetType = model.AssetType,
                    AssetStatus = model.AssetStatus,
                    PurchasedDate = model.PurchasedDate,
                    DiscardedDate = model.DiscardedDate,
                    staffId = model.staffId,
                    AssignedDate = model.AssignedDate,
                    LastReturnedDate = model.LastReturnedDate
                };

            //add new asset to asset table
            _db.Assets.Add(newasset);
            //save new asset to table
            _db.SaveChanges();

            

            //create and add to the staff history list only if the asset is created and assigned at the same time
            if (model.AssetStatus == "Assigned")
            {
                //get the asset number of most recently made asset
                var assetno = _db.Assets.OrderByDescending(p => p.AssetNo).FirstOrDefault().AssetNo;

                var staffassethistory = new StaffAssetHistory
                {
                    staffId = model.staffId.Value,
                    AssetNo = assetno,
                    AssignedDate = model.AssignedDate.Value,
                    LastReturnedDate = model.LastReturnedDate.Value
                };

                //add staffAssetHistory to Db
                _db.staffAssetHistories.Add(staffassethistory);

                //save Db
                _db.SaveChanges();
            }

            model.status = new List<SelectListItem>
            {
                new SelectListItem {Text = "Assigned" },
                new SelectListItem { Text = "Not Assigned" },
                new SelectListItem { Text = "Discarded" },
            };

            model.type = new List<SelectListItem>
            {
            new SelectListItem {Text = "Monitor" },
            new SelectListItem { Text = "CPU" },
            new SelectListItem { Text = "Keyboard" },
            new SelectListItem { Text = "Mouse" },
            new SelectListItem { Text = "Printer" },
            };


            return RedirectToAction("Index");
            

   
        }

        public IActionResult Edit(int? id)
        {
            Asset? newasset = _db.Assets.Find(id);

            var status = new List<SelectListItem>
            {
            new SelectListItem {Text = "Assigned" },
            new SelectListItem { Text = "Not Assigned" },
            new SelectListItem { Text = "Discarded" },
            };

            var type = new List<SelectListItem>
            {
            new SelectListItem {Text = "Monitor" },
            new SelectListItem { Text = "CPU" },
            new SelectListItem { Text = "Keyboard" },
            new SelectListItem { Text = "Mouse" },
            new SelectListItem { Text = "Printer" },
            };

            var model = new AssetStaffFormViewModel
            {
                AssetNo = newasset.AssetNo,
                AssetType = newasset.AssetType,
                AssetStatus = newasset.AssetStatus,
                PurchasedDate = newasset.PurchasedDate,
                DiscardedDate = newasset.DiscardedDate,
                status = status,
                type = type,
                staffId = newasset.staffId,
                AssignedDate = newasset.AssignedDate,
                LastReturnedDate = newasset.LastReturnedDate
            };



            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AssetStaffFormViewModel model, int? id)
        {
            var newasset = new Asset
            {
                AssetNo = id.Value,
                AssetType = model.AssetType,
                AssetStatus = model.AssetStatus,
                PurchasedDate = model.PurchasedDate,
                DiscardedDate = model.DiscardedDate,
                staffId = model.staffId,
                AssignedDate = model.AssignedDate,
                LastReturnedDate = model.LastReturnedDate
            };

            //update asset to asset table
            _db.Assets.Update(newasset);
            //save updated asset to table
            _db.SaveChanges();



            //create and add to the staff history list only if the asset is created and assigned at the same time
            if (model.AssetStatus == "Assigned")
            {
                //get the asset number of most recently made asset

                var staffassethistory = new StaffAssetHistory
                {
                    staffId = model.staffId.Value,
                    AssetNo = id.Value,
                    AssignedDate = model.AssignedDate.Value,
                    LastReturnedDate = model.LastReturnedDate.Value
                };

                //add staffAssetHistory to Db
                _db.staffAssetHistories.Add(staffassethistory);

                //save Db
                _db.SaveChanges();
            }

            model.status = new List<SelectListItem>
            {
                new SelectListItem {Text = "Assigned" },
                new SelectListItem { Text = "Not Assigned" },
                new SelectListItem { Text = "Discarded" },
            };

            model.type = new List<SelectListItem>
            {
            new SelectListItem {Text = "Monitor" },
            new SelectListItem { Text = "CPU" },
            new SelectListItem { Text = "Keyboard" },
            new SelectListItem { Text = "Mouse" },
            new SelectListItem { Text = "Printer" },
            };


            return RedirectToAction("Index");



        }







    }
}
