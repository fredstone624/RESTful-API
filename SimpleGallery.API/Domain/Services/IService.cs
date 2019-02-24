using SimpleGallery.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    public interface IService<Tval, Tkey>
        where Tval : class
    {
        Task<IEnumerable<Tval>> ListAsync();
        Task<SaveResponse<Tval>> SaveAsync(Tval value);
        Task<SaveResponse<Tval>> UpdateAsync(Tkey id, Tval value);
    }
}