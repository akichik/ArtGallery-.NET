
using ArtGallery.DataAccess.Context;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArtGallery.DataAccess.Implementations
{
    public class CategoryDataAccess: ICategoryDataAccess
    {
        private SketchDirectoryContext Context { get; }
        private IMapper Mapper { get; }

        public CategoryDataAccess(SketchDirectoryContext context, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        public async Task<Category> GetByAsync(ICategoryContainer category)
        {
            return category.CategoryId.HasValue ? this.Mapper.Map<Category>(await this.Context.Category.FirstOrDefaultAsync(x => x.id == category.CategoryId)) : null;
        }
    }
}
