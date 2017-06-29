using CSRT.Areas.Security.ViewModels;
using CSRT.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CSRT.Areas.Factory;

namespace CSRT.Areas.Security.Controllers
{
    public class DriverController : AlertController
    {
        private ApplicationDbContext _dbContext;

        public DriverController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Security/Driver
        [HttpGet]
        public ActionResult Index()
        {
            //var driverViewModel =new DriverViewModel();
            var drivers = _dbContext.Drivers
                                            .ToList()
                                            .Select(g => DriverFactory.DriverEntityToViewModel(g));
           
            return View(drivers);
            //return Json(new { data = drivers }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DriverViewModel model)
        {
            //Check the validity of the model
            if (ModelState.IsValid)
            {
                // call an instance of Driver Class
                var driver = DriverFactory.ViewModelToDriverEntity(model);

                _dbContext.Drivers.Add(driver);
                await _dbContext.SaveChangesAsync();
                Success("Creted Successfully", true);
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

            Driver driver = await _dbContext.Drivers.FindAsync(id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            DriverViewModel driverViewModel = DriverFactory.DriverEntityToViewModel(driver);
           

            return PartialView("_Edit", driverViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                Driver modelDriver = DriverFactory.ViewModelToDriverEntity(model);
               
                _dbContext.Entry(modelDriver).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                Success("Driver Updated Successfully", true);
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
            Driver driver = await _dbContext.Drivers.FindAsync(id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            DriverViewModel driverViewModel = DriverFactory.DriverEntityToViewModel(driver);

            return PartialView("_Delete", driverViewModel);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            Driver driver = await _dbContext.Drivers.FindAsync(id);
            _dbContext.Drivers.Remove(driver);
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

            Driver modelDriver = await _dbContext.Drivers.FindAsync(id);
            if (modelDriver == null)
            {
                return HttpNotFound();
            }

            DriverViewModel driverViewModel = DriverFactory.DriverEntityToViewModel(modelDriver);
            return PartialView("_Details", driverViewModel);
        }

    }
}