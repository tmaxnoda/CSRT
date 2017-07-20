using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static class VehicleMovementFactory
    {
        //public static 
        public static VehicleMovementViewModel EntityToViewModel(VehicleMovement model)
        {
            var movementmodel = new VehicleMovementViewModel(model);
            return movementmodel;

        }

        public static VehicleMovement ViewModelToEntity(VehicleMovementViewModel model)
        {
            var movementmodel = new VehicleMovement()
            {
               // Id = model.Id,
                MotoId = model.MotoId,
                DepartmentId = model.DepartmentId,
                DriverId = model.DriverId,
                TimeOut = model.GetDateTime(),
                Date = model.GetDateTime(),
                NameOfPeopleGoingOut = model.NameOfPeopleGoingOut,
                NumberOfPeopleGoingOut = model.NumberOfPeopleGoingOut,
                Destination =  model.Destination,
                Purpose = model.Purpose,
                MilageOut =  model.MilageOut


            };
            return movementmodel;

        }
    }
}