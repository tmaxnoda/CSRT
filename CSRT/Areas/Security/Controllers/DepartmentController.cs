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

    public class DepartmentController : AlertController
    {
        private ApplicationDbContext _dbContext;

        public DepartmentController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Security/Department
        public ActionResult Index()
        {
            var depatrments = _dbContext.Departments.ToList()
                .Select(g => DepartmentFactory.DepartmentEntityToViewModel(g));

            return View(depatrments);
        }

        public ActionResult Create()
        {

            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DepartmentViewModel model)
        {
            //Check the validity of the model
            if (ModelState.IsValid)
            {
                // call an instance of Driver Class
                var department = DepartmentFactory.ViewModelToDepartmentEntity(model);

                if (department != null) _dbContext.Departments.Add(department);
                await _dbContext.SaveChangesAsync();
                Success("Department Creted Successfully", true);
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

            Department department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            DepartmentViewModel departmentViewModel = DepartmentFactory.DepartmentEntityToViewModel(department);


            return PartialView("_Edit", departmentViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department modeldepartment = DepartmentFactory.ViewModelToDepartmentEntity(model);


                _dbContext.Entry(modeldepartment).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                Success("Department Updated Successfully", true);
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
            Department department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            DepartmentViewModel departmentResult = DepartmentFactory.DepartmentEntityToViewModel(department);

            return PartialView("_Delete", departmentResult);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            Department department = await _dbContext.Departments.FindAsync(id);
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
            Success("Department Deleted Successfully", true);
            return Json(new { success = true });

        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = await _dbContext.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentViewModel departmentViewModel = DepartmentFactory.DepartmentEntityToViewModel(department);

            return PartialView("_Details", departmentViewModel);
        }
    }
}