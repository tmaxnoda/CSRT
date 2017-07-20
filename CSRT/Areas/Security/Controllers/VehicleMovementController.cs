using CSRT.Areas.Factory;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;
using PagedList;

namespace CSRT.Areas.Security.Controllers
{
    public class VehicleMovementController : AlertController
    {
        private ApplicationDbContext _dbcontext;

        public VehicleMovementController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        // GET: Security/VehicleMovement
        public ActionResult Index(int? page)
        {
            var movement = _dbcontext.VehicleMovements
                .Include(x => x.Department)
                .Include(x => x.Driver)
                .Include(x => x.Moto)
                .Include(x => x.Moto.MottorModel)
                .ToList().OrderByDescending(X => X.TimeOut).Select(x => VehicleMovementFactory.EntityToViewModel(x));

            int pageSize = 3;
            int pageNumber = (page ?? 1);
           
            return View(movement.ToPagedList(pageNumber, pageSize));
           
        }

        public async Task<ActionResult> Create()
        {
            var vm = new VehicleMovementViewModel();
            setModeList(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( VehicleMovementViewModel model)
        {
            // define our transaction scope
           

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var mov = VehicleMovementFactory.ViewModelToEntity(model);
                    var result = _dbcontext.VehicleMovements.Add(mov);
                    var i = await _dbcontext.SaveChangesAsync();

                    if (i.Equals(1))
                    {
                        var motto = _dbcontext.Mottors.SingleOrDefault(x => x.Id.Equals(mov.MotoId));
                        if (motto == null)
                        {
                            Danger("Something is wrong Internally, visit the admin");
                            return View("Create");
                        }
                        motto.IsAvailable = false;
                        await _dbcontext.SaveChangesAsync();

                        //var savedMoveent = _dbcontext.VehicleMovements.Select().LastOrDefault();

                        var milage = MilageFactory.ViewmodelToEntity(result);
                        _dbcontext.Milages.Add(milage);
                        await _dbcontext.SaveChangesAsync();

                        var driver = _dbcontext.Drivers.SingleOrDefault(x => x.Id == mov.DriverId);
                        if (driver == null)
                        {
                            Danger("Something is wrong Internally, visit the admin");
                            return View("Create");
                        }

                        driver.IsAvailable = false;
                        await _dbcontext.SaveChangesAsync();
                        scope.Complete();
                        scope.Dispose();
                    }
                }
                catch (DbEntityValidationException e)
                {
                    var outputLines = new List<string>();
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors: ", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            outputLines.Add(string.Format(" Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                    }

                   
                    
                    Danger(outputLines.ToString(), false);
                    System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                    //throw;
                }
            }
            
            
            return RedirectToAction("Index");
        }

        private VehicleMovementViewModel setModeList(VehicleMovementViewModel model)
        {
            var departments = _dbcontext.Departments.ToList();
            var mottors = _dbcontext.Mottors.Where(x => x.IsAvailable == true).ToList();
            var drivers = _dbcontext.Drivers.Where(x => x.IsAvailable == true).ToList();
            model.SelectLists(departments, mottors, drivers);

            return model;
        }
    }
}