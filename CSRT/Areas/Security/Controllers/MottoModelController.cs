using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSRT.Areas.Factory;
using CSRT.Models;
using System.Threading.Tasks;
using CSRT.Areas.Security.ViewModels;
using System.Net;

namespace CSRT.Areas.Security.Controllers
{
   
    public class MottoModelController : AlertController
    {
        private ApplicationDbContext _dbContext;

        public MottoModelController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Security/MottoModel
        [HttpGet]
        public ActionResult Index()
        {
            //var driverViewModel =new DriverViewModel();
            var model = _dbContext.MottoModels
                .ToList()
                .Select(g => MottoModelFactory.MottoEntityToViewModel(g));

            return View(model);
            //return Json(new { data = drivers }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MottorModelViewModel model)
        {
            //Check the validity of the model
            if (ModelState.IsValid)
            {
                // call an instance of Driver Class
                var driver = MottoModelFactory.ViewModelToMottoEntity(model);

                _dbContext.MottoModels.Add(driver);
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

            MottorModel driver = await _dbContext.MottoModels.FindAsync(id);
            if (driver == null)
            {
                return HttpNotFound();
            }

            MottorModelViewModel driverViewModel = MottoModelFactory.MottoEntityToViewModel(driver);


            return PartialView("_Edit", driverViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MottorModelViewModel model)
        {
            if (ModelState.IsValid)
            {
                MottorModel modelDriver = MottoModelFactory.ViewModelToMottoEntity(model);

                _dbContext.Entry(modelDriver).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                Success("Model Updated Successfully", true);
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
            MottorModel motto = await _dbContext.MottoModels.FindAsync(id);
            if (motto == null)
            {
                return HttpNotFound();
            }

              MottorModelViewModel mottoModelViewModel = MottoModelFactory.MottoEntityToViewModel(motto);

            return PartialView("_Delete", mottoModelViewModel);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            MottorModel model = await _dbContext.MottoModels.FindAsync(id);
            _dbContext.MottoModels.Remove(model);
            await _dbContext.SaveChangesAsync();
            Success("Model Deleted Successfully", true);
            return Json(new { success = true });

        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MottorModel model = await _dbContext.MottoModels.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            MottorModelViewModel mottoViewModel = MottoModelFactory.MottoEntityToViewModel(model);
            return PartialView("_Details", mottoViewModel);
        }


        
    }
}