using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CSRT.Areas.Factory;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;
using Microsoft.Ajax.Utilities;

namespace CSRT.Areas.Security.Controllers
{
    public class MottoController : AlertController
    {
        private ApplicationDbContext _context;
        public MottoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Security/Motto
        public ActionResult Index()
        {
            var motto = _context.Mottors
                .Include(x => x.Department)
                .Include(x => x.Vehicle)
                .Include(x => x.MottorModel).ToList().Select(x => MottorFactory.MottoEntityToViewModel(x));
                //.Include("Vehicle")
                //.Include("MottorModel").ToList().Select( x => MottorFactory.MottoEntityToViewModel(x));
            
            return View(motto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new MottorViewModel();
            setModeList(model);
            return PartialView("_Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MottorViewModel model)
        {
            //Check the validity of the model
            if (ModelState.IsValid)
            {
                try
                {
                    bool isPlateNumberExist = false;
                    // search for plate number
                    var allMottors = _context.Mottors
                        .ToList()
                        .FirstOrDefault(x => x.PlateNumber.ToLower().Trim() == model.PlateNumber.ToLower().Trim());
                    if (allMottors != null)
                    {
                         isPlateNumberExist =MottorFactory.isPlateNumberAlreadyExisting(allMottors, model);
                    }
                    //ValidateRequest plate number
                  
                    //redirect to index
                    if (isPlateNumberExist == true)
                    {
                        Warning("Mottor  with plate number " + model.PlateNumber + " is already existing ", true);
                        return Json(new { success = true });

                    }
                    var motto = MottorFactory.ViewModelToMottoEntity(model);
                    
                    _context.Mottors.Add(motto);
                    var i = await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Danger(ex.Message, true);
                    return Json(new { success = true });
                }
                // call an instance of Driver Class
                
                Success("Creted Successfully", true);
                return Json(new { success = true });

            }



            return PartialView("_Create", model); 
        }


        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Mottor mottor = await _context.Mottors.FindAsync(id);
            if (mottor == null)
            {
                return HttpNotFound();
            }

            var model = MottorFactory.MottoEntityToViewModelFOrEdit(mottor);
            setModeList(model);
            return PartialView("_Edit", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MottorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mottor motto = MottorFactory.ViewModelToMottoEntity(model);

                _context.Entry(motto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                Success("Motto with the plate number : " + motto.PlateNumber + "   Updated Successfully", true);
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
            Mottor motto = await _context.Mottors.FindAsync(id);
            if (motto == null)
            {
                return HttpNotFound();

            }

            MottorViewModel mottoViewModel = MottorFactory.MottoEntityToViewModelFOrEdit(motto);

            return PartialView("_Delete", mottoViewModel);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Mottor model = await _context.Mottors.FindAsync(id);
                if (model != null) _context.Mottors.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Danger(e.Message, true);
                return Json(new { success = true });
            }
            
            Success("Model Deleted Successfully", true);
            return Json(new { success = true });

        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //find model
            Mottor model = await _context.Mottors.FindAsync(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            //validate all by including all the vehicle
            var singleOrDefault = _context.Mottors
                .Include(x => x.Department)
                .Include(x => x.Vehicle)
                .Include(x => x.MottorModel)
                .FirstOrDefault(x => x.Id == model.Id);

            // check if such mottor cannot be found.
            if (singleOrDefault == null)
            {
                Warning("Cannot find such mottor", true);
                return Json(new { success = true });
                
                
            }

            model = singleOrDefault;

            

            MottorViewModel mottoViewModel = MottorFactory.MottoEntityToViewModel(model);
            return PartialView("_Details", mottoViewModel);
        }
        // Private function
        private MottorViewModel setModeList(MottorViewModel model)
        {
            var departments = _context.Departments.ToList();
            var models = _context.MottoModels.ToList();
            var vehicles = _context.Vehicles.ToList();
            model.SelectLists(departments,models,vehicles);

            return model;
        }
    }
}