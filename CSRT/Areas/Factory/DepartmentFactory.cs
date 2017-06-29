using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static class DepartmentFactory
    {
        public static Department ViewModelToDepartmentEntity(DepartmentViewModel model)
        {
            var entity = new Department()
            {
                Id = model.Id >= 1 ? model.Id : 0,
                Name = model.Name
                //Mottors = model.Mottors == null ? new List<Mottor>() : model.Mottors.Select(e => MottorFactory.ViewModelToMottoEntity(e).ToList())
                //Expenses = expenseGroup.Expenses == null ? new List<Expense>() : expenseGroup.Expenses.Select(e => expenseFactory.CreateExpense(e)).ToList()

            };
            return entity;
        }

        public static DepartmentViewModel DepartmentEntityToViewModel(Department model)
        {
            var entity = new DepartmentViewModel()
            {
                Id = model.Id,
                Name = model.Name.ToUpper(),
                //Mottors = model.Mottors.Select(e => MottorFactory.MottoEntityToViewModel(e))
                    

            };
            return entity;
        }
    }
}