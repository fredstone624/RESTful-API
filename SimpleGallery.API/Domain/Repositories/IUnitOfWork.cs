using System.Threading.Tasks;

namespace SimpleGallery.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}