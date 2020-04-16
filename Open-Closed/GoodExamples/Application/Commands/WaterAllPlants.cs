using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Commands
{
    public class WaterAllPlants 
    {
        public class Command : IRequest<Result>
        {

        }

        public class Result
        {
            public IEnumerable<string> WateringResults { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly IRepository<Plant> _plantRepository;

            public Handler(IRepository<Plant> plantRepository)
            {
                _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var plants = await _plantRepository.GetAll();

                var results = plants.Select(plant => $"{plant.PlantName}: " + plant.WaterPlant());

                return new Result { WateringResults = results };
            }
        }
    }
}
