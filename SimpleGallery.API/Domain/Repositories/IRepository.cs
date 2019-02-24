using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Repositories
{
    public interface IRepository<T> 
        where T : class
    {
        Task<IEnumerable<T>> ListAsync();
    }
}