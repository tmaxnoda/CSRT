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
                    // search for plate number
                    var allMottors = _context.Mottors
                        .ToList()
                        .FirstOrDefault(x => x.PlateNumber.ToLower().Trim() == model.PlateNumber.ToLower().Trim());

                    //ValidateRequest plate number
                   bool isPlateNumberExist = MottorFactory.isPlateNumberAlreadyExisting(allMottors, model);
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
                    return View("Error", new HandleErrorInfo(ex, "Motto", "Index"));
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