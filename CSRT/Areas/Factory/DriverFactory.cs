using CSRT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;

namespace CSRT.Areas.Factory
{
    public static class DriverFactory
    {
        public static Driver ViewModelToDriverEntity(DriverViewModel model)
        {
            var entity = new Driver()
            {
                Id = model.Id >= 1 ? model.Id : 0,
                Name = model.Name,
                IsAvailable = model.IsAvailable,
                PhoneNumber = model.PhoneNumber
            };
            return entity;
        }

        public static DriverViewModel DriverEntityToViewModel(Driver model)
        {
            var entity = new DriverViewModel()
            {
                Id = model.Id,
                Name = model.Name.ToUpper(),
                IsAvailable = model.IsAvailable,
                PhoneNumber = model.PhoneNumber
            };
            return entity;
        }
    }
}