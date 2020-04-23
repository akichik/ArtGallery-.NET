using ArtGallery.Domain;
using ArtGallery.Domain.Models;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Contracts
{
    public interface ISketchCreateService
    {
        Task<Sketch> CreateAsync(SketchUpdateModel sketch);
    }
}
