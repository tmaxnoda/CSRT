using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static class VehicleFactory
    {
        public static  VehicleViewModel VehicleEntityToViwModel(Vehicle model)
        {
            var  vehicleModel = new VehicleViewModel()
            {
                Id = model.Id,
                Type = model.Type
            };

            return vehicleModel;
        }

        public static Vehicle ViewModelToVehicleEntity(VehicleViewModel model)
        {
            var vehicle = new Vehicle()
            {
                Id = model.Id >= 1? model.Id : 0,
                Type = model.Type.ToUpper()
            };

            return vehicle;
        }
    }
}