using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Watering
{
    public class LowWaterRequirement : IWaterable
    {
        public string WaterPlant()
        {
            return "Watered a little";
        }
    }
}
