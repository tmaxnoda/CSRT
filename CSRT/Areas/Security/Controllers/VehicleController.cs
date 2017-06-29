using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CSRT.Areas.Factory;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;
using System.Net;

namespace CSRT.Areas.Security.Controllers
{
   
    public class VehicleController :AlertController
    {
        private ApplicationDbContext _dbContext;
        public VehicleController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Security/Vehicle
        public ActionResult Index()
        {
            var vehicles = _dbContext.Vehicles.ToList()
                .Select(g => VehicleFactory.VehicleEntityToViwModel(g));

            return View(vehicles);
        }

        public ActionResult Create()
        {

            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleViewModel model)
        {
            //Check the validity of the model
            if (ModelState.IsValid)
            {
                // call an instance of Driver Class
                var vehicle = VehicleFactory.ViewModelToVehicleEntity(model);

                _dbContext.Vehicles.Add(vehicle);
                await _dbContext.SaveChangesAsync();
                Success(" Vehicle Creted Successfully", true);
                return Json(new { success = true });

            }



            return PartialView("_Create", model); ;
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Vehicle vehicle = await _dbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            VehicleViewModel vehicleViewModel = VehicleFactory.VehicleEntityToViwModel(vehicle);


            return PartialView("_Edit", vehicleViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Vehicle modelVehicle = VehicleFactory.ViewModelToVehicleEntity(model);
                

                _dbContext.Entry(modelVehicle).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                Success("Vehicle Updated Successfully", true);
                return Json(new { success = true });


            }



            return PartialView("_Edit", model);
        }

       
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await _dbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            VehicleViewModel vehicleResult = VehicleFactory.VehicleEntityToViwModel(vehicle);
            

            return PartialView("_Delete", vehicleResult);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            Vehicle vehicle = await _dbContext.Vehicles.FindAsync(id);
            _dbContext.Vehicles.Remove(vehicle);
            await _dbContext.SaveChangesAsync();
            Success("Driver Deleted Successfully", true);
            return Json(new { success = true });

        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           Vehicle vehicle = await _dbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            VehicleViewModel vehicleViewModel = VehicleFactory.VehicleEntityToViwModel(vehicle);
           
            return PartialView("_Details", vehicleViewModel);
        }
    }
}