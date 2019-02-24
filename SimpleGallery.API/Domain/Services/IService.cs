using SimpleGallery.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    public interface IService<Tval, Tkey>
        where Tval : class
    {
        Task<IEnumerable<Tval>> ListAsync();
        Task<Response<Tval>> SaveAsync(Tval value);
        Task<Response<Tval>> UpdateAsync(Tkey id, Tval value);
        Task<Response<Tval>> DeleteAsync(Tkey id);
    }
}