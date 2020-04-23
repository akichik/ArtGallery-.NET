using ArtGallery.BLL.Contracts;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Implementation
{
    public class SketchGetService : ISketchGetService
    {
        private ISketchDataAccess sketchDataAccess { get; }

        public SketchGetService(ISketchDataAccess sketchDataAccess)
        {
            this.sketchDataAccess = sketchDataAccess;
        }

        public Task<IEnumerable<Sketch>> GetAsync()
        {
            return this.sketchDataAccess.GetAsync();
        }

        public Task<Sketch> GetAsync(ISketchIdentity sketch)
        {
            return this.sketchDataAccess.GetAsync(sketch);
        }
    }
}
