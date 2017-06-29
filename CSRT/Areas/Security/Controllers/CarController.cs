using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CSRT.Models;
using System.Web.Mvc;
using CSRT.Areas.Security.ViewModels;

namespace CSRT.Areas.Security.Controllers
{
    public class CarController : AlertController
    {
        private ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Security/Car
        //public ActionResult Index()
        //{
        //    var cars = _context.Cars.Include(x => x.Department).ToList();
        //    List<CarViewModel> carModel = new List<CarViewModel>();
        //    foreach (var car in cars)
        //    {
        //        CarViewModel carViewModel = new CarViewModel(car);

        //        carModel.Add(carViewModel);
        //    }
           
        //    return View(carModel);
        //}


        //public ActionResult Create()
        //{
        //    CarViewModel carViewModel = new CarViewModel();

        //    return PartialView("_Create", carViewModel);
        //}

    }
}