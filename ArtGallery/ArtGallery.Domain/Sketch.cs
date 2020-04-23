using ArtGallery.Domain.Contracts;
using System;

namespace ArtGallery.Domain
{
    public class Sketch: ICategoryContainer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public int year { get; set; }
        public string description { get; set; }
        public Category Category { get; set; }

        int? ICategoryContainer.CategoryId => this.Category.id; 
    }
}
