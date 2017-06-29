using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static  class MottorFactory
    {
        public static Mottor ViewModelToMottoEntity(MottorViewModel model)
        {
            var entity = new Mottor()
            {
                Id = model.Id >= 1 ? model.Id : 0,
                DepartmentId = model.DepartmentId,
                VehicleId = model.VehicleId,
                MottorModelId = model.MottorModelId,
                PlateNumber = model.PlateNumber.ToUpper(),
                IsAvailable = model.IsAvailable,
                DateCreated = DateTime.UtcNow
                // VehicleMovements = 


            };
            return entity;
        }

        public static MottorViewModel MottoEntityToViewModel(Mottor model)
        {
            var entity = new MottorViewModel(model);
            
            return entity;
        }

        
    }
}