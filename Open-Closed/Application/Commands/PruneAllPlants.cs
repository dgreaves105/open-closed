using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class PruneAllPlants
    {
        public class Command : IRequest<Result>
        {

        }

        public class Result
        {
            public IEnumerable<string> PruningResults { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result>
        {
            private readonly IRepository<Plant> _plantRepository;
            private readonly IServiceProvider _serviceProvider;

            public Handler(IRepository<Plant> plantRepository, IServiceProvider serviceProvider)
            {
                _plantRepository = plantRepository ?? throw new ArgumentNullException(nameof(plantRepository));
                _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var plants = await _plantRepository.GetAll();
                var pruningGroups = plants.GroupBy(plant => plant.PruningRequirement.GetType()).Where(plant => plant.Key != null);

                var pruningTasks = new List<Task<string>>();
                foreach(var pruningGroup in pruningGroups)
                {
                    var pruningService = GetPruningService(pruningGroup.Key);
                    foreach(var plant in pruningGroup)
                    {
                        pruningTasks.Add(pruningService.PrunePlant(plant));
                    }
                }

                var results = await Task.WhenAll(pruningTasks);

                return new Result { PruningResults = results };
            }


            internal IPruningService GetPruningService(Type type)
            {
                var pruningServiceType = GetPruningServiceType(type);
                var pruningSerivce = (IPruningService)_serviceProvider.GetService(pruningServiceType);
                if (pruningSerivce == null) throw new Exception($"Unable to retrieve pruning service for type: {type}");
                return pruningSerivce;
            }

            internal Type GetPruningServiceType(Type prunableType)
            {
                var genericBase = typeof(IPruningService<>);
                return genericBase.MakeGenericType(prunableType);
            }
        }
    }
}
