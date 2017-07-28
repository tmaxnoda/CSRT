using CSRT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using CSRT.Areas.Factory;
using CSRT.Areas.Security.ViewModels;
using Microsoft.Ajax.Utilities;

namespace CSRT.Areas.Security.Controllers
{
    public class MilageController : AlertController
    {
        private ApplicationDbContext _context;
        
        public MilageController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Milage mottor = await _context.Milages.FindAsync(id);
            if (mottor == null)
            {
                Danger("Milage cnnot be found", true);
                return Json(new { success = true });
            }
            var model = MilageFactory.EntityToMilageViewModel(mottor);           
            return PartialView("_Edit", model);

        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MilageViewModel model)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    Milage milage = MilageFactory.MilageViewmodelToEntity(model);

                    if (milage == null)
                    {
                        Danger("Milage cannot be found", true);
                        return Json(new { success = true });
                    }
                    _context.Entry (milage).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    // get the vehicle movement through their id
                    var getVehicleMovement =
                        _context.VehicleMovements.SingleOrDefault(x => x.Id.Equals(model.VehicleMovementId));

                    var driver = _context.Drivers.SingleOrDefault(x => x.Id.Equals(getVehicleMovement.DriverId));

                    if (driver == null)
                    {
                        Danger("Driver cannot be found", true);
                        return Json(new { success = true });
                    }

                    driver.IsAvailable = true;
                    await _context.SaveChangesAsync();

                    var getMottor = _context.Mottors.SingleOrDefault(x => x.Id.Equals(getVehicleMovement.MotoId));
                    if (getMottor == null)
                    {
                        Danger("Mottor cannot be found", true);
                        return Json(new { success = true });
                    }

                    getMottor.IsAvailable = true;
                    await _context.SaveChangesAsync();

                    scope.Complete();
                    scope.Dispose();
                    Success("Updated Successfully", true);
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    Danger(e.Message, true);
                    return Json(new { success = true });
                  
                   
                }
            }
          
              

            

           
        }
    }
}