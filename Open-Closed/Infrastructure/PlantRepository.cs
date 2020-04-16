using Application.Abstractions;
using Domain;
using Domain.Pruning;
using Domain.Watering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PlantRepository : IRepository<Plant>
    {
        public Task<IEnumerable<Plant>> GetAll()
        {
            return Task.FromResult<IEnumerable<Plant>>(new List<Plant>
            {
                new Plant
                {
                    PlantName = "Rose Bush",
                    WaterRequirement = new LowWaterRequirement(),
                    PruningRequirement = new HeavyPruning(),
                },
                new Plant
                {
                    PlantName = "Lemon Tree",
                    WaterRequirement = new MediumWaterRequirement(),
                    PruningRequirement = new LightPruning()
                }

            });
        }
    }
}
