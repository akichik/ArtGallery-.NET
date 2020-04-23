using ArtGallery.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtGallery.Domain.Models
{
    public class SketchUpdateModel: ISketchIdentity, ICategoryContainer
    { 
        public int Id => throw new NotImplementedException();

        public int? CategoryId => throw new NotImplementedException();
    }
}
