using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(); 
    }
}
