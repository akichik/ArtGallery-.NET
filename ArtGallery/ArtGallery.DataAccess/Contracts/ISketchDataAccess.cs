using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using ArtGallery.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.DataAccess.Contracts
{
    public interface ISketchDataAccess
    {
        Task<Sketch> InsertAsync(SketchUpdateModel mask);
        Task<IEnumerable<Sketch>> GetAsync();
        Task<Sketch> GetAsync(ISketchIdentity mask);
        Task<Sketch> UpdateAsync(SketchUpdateModel mask);
    }
}
