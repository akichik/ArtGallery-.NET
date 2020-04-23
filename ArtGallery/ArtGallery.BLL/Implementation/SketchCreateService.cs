using ArtGallery.BLL.Contracts;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Models;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Implementation
{
    public class SketchCreateService : ISketchCreateService
    {
        private ISketchDataAccess sketchDataAccess { get; }
        private ICategoryGetService categoryGetService { get; }

        public SketchCreateService(ISketchDataAccess sketchDataAccess, ICategoryGetService categoryGetService )
        {
            this.sketchDataAccess = sketchDataAccess;
            this.categoryGetService = categoryGetService;
        }


        public async Task<Sketch> CreateAsync(SketchUpdateModel sketch)
        {
            //await this.categoryGetService.ValidateAsync(sketch);

            return await this.sketchDataAccess.InsertAsync(sketch);
        }
    }
}
