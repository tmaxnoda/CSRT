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

        public static Milage MilageViewmodelToEntity(MilageViewModel model)
        {
            int milagein = Int32.Parse(model.MilageIn);
            int milageout = Int32.Parse(model.MilageOut);
            var milage = new Milage()
            {
                Id = model.Id,
                TimeOut = Convert.ToDateTime(model.TimeOut),
                MilageOut = model.MilageOut,
                VehicleMovementId = model.VehicleMovementId,
                TimeIn = Convert.ToDateTime(model.TimeIn),
                MilageIn = model.MilageIn,
                MilageCovered = Convert.ToString(milagein -  milageout)

            };

            return milage;
        }

        public static MilageViewModel EntityToViewModel(Milage model)
        {
            var milage = new MilageViewModel(model){};

            return milage;
        }


        public static MilageViewModel EntityToMilageViewModel(Milage model)
        {
            var milage = new MilageViewModel() {

                Id = model.Id,
                MilageIn = model.MilageIn,
                MilageOut = model.MilageOut,
                TimeIn = model.TimeIn.HasValue ? model.TimeIn.Value.ToString("HH:mm tt") : null,
                TimeOut = model.TimeOut.Value.ToString("HH:mm tt"),
                MilageCovered = model.MilageCovered ,
                VehicleMovementId = model.VehicleMovementId


        };

            return milage;
        }
    }
}