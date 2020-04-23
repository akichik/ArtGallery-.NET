
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using System.Threading.Tasks;

namespace ArtGallery.DataAccess.Contracts
{
    public interface ICategoryDataAccess
    { 
        Task<Category> GetByAsync(ICategoryContainer category);
    }
}
