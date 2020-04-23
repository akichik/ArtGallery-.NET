using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Contracts
{
    public interface ISketchGetService
    {
        Task<IEnumerable<Sketch>> GetAsync();
        Task<Sketch> GetAsync(ISketchIdentity sketch);
    }
}
