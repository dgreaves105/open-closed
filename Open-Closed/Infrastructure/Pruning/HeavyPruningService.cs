﻿using Application.Abstractions;
using Domain;
using Domain.Pruning;
using System.Threading.Tasks;

namespace Infrastructure.Pruning
{
    public class HeavyPruningService : IPruningService<HeavyPruning>
    {
        public Task<string> PrunePlant(Plant plant)
        {
            //Do all your processing stuff here

            return Task.FromResult($"Pruned {plant.PlantName} heavily");
        }
    }
}
