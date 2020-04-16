using Domain.Pruning;
using Domain.Watering;

namespace Domain
{
    public class Plant : IWaterable, IPrunable
    {
        public string PlantName { get; set; }
        public IWaterable WaterRequirement { get; set; }
        public IPrunable PruningRequirement { get; set; }

        public string WaterPlant()
        {
            return WaterRequirement.WaterPlant();
        }
    }
}
