using SimpleGallery.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Services
{
    public interface IService<T>
        where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task<SaveResponse<T>> SaveAsync(T value);
    }
}
