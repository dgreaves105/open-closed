using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Http;
using Application.Commands;

namespace API.Controllers
{
    public class PlantController : ControllerBase
    {
        public IMediator _mediator;

        public PlantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Water")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<string>> WaterAllPlants()
        {
            return (await _mediator.Send(new WaterAllPlants.Command())).WateringResults;
        }

        [HttpPost("Prune")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<string>> PruneAllPlants()
        {
            return (await _mediator.Send(new PruneAllPlants.Command())).PruningResults;
        }
    }
}