using ArtGallery.Domain.Contracts;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Contracts
{
    public interface ICategoryGetService
    {
        Task ValidateAsync(ICategoryContainer categoryContainer);
    }
}
