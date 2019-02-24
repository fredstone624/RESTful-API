using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Repositories
{
    public interface IRepository<Tval, Tkey> 
        where Tval : class
    {
        Task<IEnumerable<Tval>> ListAsync();
        Task AddAsync(Tval value);
        Task<Tval> FindByIdAsync(Tkey id);
        void Update(Tval value);
    }
}