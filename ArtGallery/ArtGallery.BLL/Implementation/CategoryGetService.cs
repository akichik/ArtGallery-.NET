using ArtGallery.BLL.Contracts;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Implementation
{
    public class CategoryGetService : ICategoryGetService
    {
        private ICategoryDataAccess CategoryDataAccess;

        public CategoryGetService(ICategoryDataAccess CategoryDataAccess)
        {
            this.CategoryDataAccess = CategoryDataAccess;
        }


        public async Task ValidateAsync(ICategoryContainer categoryContainer)
        {
            if(categoryContainer == null)
            {
                throw new ArgumentNullException(nameof(categoryContainer));
            }

            var category = await this.GetBy(categoryContainer);
            
            if(categoryContainer.CategoryId.HasValue && category == null)
            {
                throw new InvalidOperationException($"Category not found by id {categoryContainer.CategoryId}");
            }
        }

        private async Task<Category> GetBy(ICategoryContainer categoryContainer)
        {
            return await this.CategoryDataAccess.GetByAsync(categoryContainer);
        }
    }
}
