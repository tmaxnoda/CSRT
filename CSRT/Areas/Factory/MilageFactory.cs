using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRT.Areas.Security.ViewModels;
using CSRT.Models;

namespace CSRT.Areas.Factory
{
    public static class MilageFactory
    {
        public static Milage ViewmodelToEntity(VehicleMovement model)
        {
            var milage = new Milage()
            {
               // Id = model.Id,
                MilageCovered = null,
                MilageIn =null,
                MilageOut = model.MilageOut,
                VehicleMovementId = model.Id,
                TimeOut = model.TimeOut,
                
            };

            return milage;
        }
    }
}