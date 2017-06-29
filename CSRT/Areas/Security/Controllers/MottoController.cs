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
                // call an instance of Driver Class
                var driver = MottorFactory.ViewModelToMottoEntity(model);

                _context.Mottors.Add(driver);
                var i = await _context.SaveChangesAsync();
                Success("Creted Successfully", true);
                return Json(new { success = true });

            }



            return PartialView("_Create", model); ;
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