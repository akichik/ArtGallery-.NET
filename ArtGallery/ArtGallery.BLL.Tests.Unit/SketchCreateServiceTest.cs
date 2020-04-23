using ArtGallery.BLL.Contracts;
using ArtGallery.BLL.Implementation;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Models;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.BLL.Tests.Unit
{
    public class SketchCreateServiceTest
    {
        [Test]
        public async Task CreateAsync_CategoryValidationSucceed_CreateSketch()
        {
            //Arrange
            var sketch = new SketchUpdateModel();
            var expected = new Sketch();

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService.Setup(x => x.ValidateAsync(sketch));

            var sketchDataAccess = new Mock<ISketchDataAccess>();
            sketchDataAccess.Setup(x => x.InsertAsync(sketch)).ReturnsAsync(expected);



            var sketchGetService = new SketchCreateService(sketchDataAccess.Object, categoryGetService.Object);

            //Act
            var result = await sketchGetService.CreateAsync(sketch);

            //Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_CategoryValidationFailed_ThrowsError()
        {
            //Arrange
            var fixture = new Fixture();
            var sketch = new SketchUpdateModel();
            var expected = fixture.Create<string>();

            var categoryGetService = new Mock<ICategoryGetService>();
            categoryGetService.Setup(x => x.ValidateAsync(sketch)).Throws(new InvalidOperationException(expected));

            var sketchDataAccess = new Mock<ISketchDataAccess>();

            var sketchGetService = new SketchCreateService(sketchDataAccess.Object, categoryGetService.Object);

            //Act
            var action = new Func<Task>(() => sketchGetService.CreateAsync(sketch));

            //Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            sketchDataAccess.Verify(x => x.InsertAsync(sketch), Times.Never);
        }
    }
}
