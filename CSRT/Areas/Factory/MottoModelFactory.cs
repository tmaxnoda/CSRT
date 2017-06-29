using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public class MottoModelFactory
    {
        public static MottorModel ViewModelToMottoEntity(MottorModelViewModel model)
        {
            var entity = new MottorModel()
            {
                Id = model.Id >= 1 ? model.Id : 0,
                Name = model.Name.ToUpper(),
                Date = DateTime.UtcNow,
                Make = model.Make.ToUpper(),
                Total = model.Total
              
            };
            return entity;
        }

        public static MottorModelViewModel MottoEntityToViewModel(MottorModel model)
        {
            var entity = new MottorModelViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Total = model.Total,
                Date =  model.Date,
                Make = model.Make

            };
            return entity;
        }
    }
}