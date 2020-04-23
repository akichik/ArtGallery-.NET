using ArtGallery.Domain;
using ArtGallery.Domain.Models;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Contracts
{
    public interface ISketchUpdateService
    {
        Task<Sketch> UpdateAsync(SketchUpdateModel sketch);
    }
}
