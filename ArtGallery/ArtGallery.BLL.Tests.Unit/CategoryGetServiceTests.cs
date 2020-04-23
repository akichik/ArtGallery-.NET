using ArtGallery.BLL.Implementation;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Tests.Unit
{
    [TestFixture]
    public class CategoryGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CategoryExists_DoesNothing()
        {
            // Arrange
            var categoryContainer = new Mock<ICategoryContainer>();

            var category = new Category();
            var categoryDataAccess = new Mock<ICategoryDataAccess>();
            categoryDataAccess.Setup(x => x.GetByAsync(categoryContainer.Object)).ReturnsAsync(category);

            var categoryGetService = new CategoryGetService(categoryDataAccess.Object);

            // Act
            var action = new Func<Task>(() => categoryGetService.ValidateAsync(categoryContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
    }
}
