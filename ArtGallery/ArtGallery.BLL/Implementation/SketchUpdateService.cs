using ArtGallery.BLL.Contracts;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Models;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Implementation
{
    public class SketchUpdateService : ISketchUpdateService
    {
        private ISketchDataAccess sketchDataAccess { get; }
        private ICategoryGetService categoryGetService { get; }

        public SketchUpdateService(ISketchDataAccess sketchDataAccess, ICategoryGetService categoryGetService)
        {
            this.sketchDataAccess = sketchDataAccess;
            this.categoryGetService = categoryGetService;
        }

        public async Task<Sketch> UpdateAsync(SketchUpdateModel sketch)
        {
            await this.categoryGetService.ValidateAsync(sketch);

            return await this.sketchDataAccess.UpdateAsync(sketch);
        }
    }
}
