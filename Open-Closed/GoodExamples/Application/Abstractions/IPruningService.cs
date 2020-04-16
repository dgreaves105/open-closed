using Domain;
using Domain.Pruning;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IPruningService
    {
        Task<string> PrunePlant(Plant plant);
    }

    public interface IPruningService<TPrunable> : IPruningService where TPrunable : IPrunable { }
}
