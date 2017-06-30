using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static class MottorFactory
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

        public static MottorViewModel MottoEntityToViewModelFOrEdit(Mottor model)
        {
            var motto = new MottorViewModel()
            {
                Id = model.Id,
                MottorModelId = model.MottorModelId,
               
                PlateNumber = model.PlateNumber,
                IsAvailable = model.IsAvailable,
                VehicleId = model.VehicleId,
                DepartmentId = model.DepartmentId,
               
            };

            return motto;
        }
            
        

        public static  bool isPlateNumberAlreadyExisting(Mottor model, MottorViewModel viewModel)
        {
            if (model.PlateNumber.Trim() == viewModel.PlateNumber.Trim())
            {
                return true;
            }

            return false;

        }
    }
}