using System;
using System.Collections.Generic;
using System.Text;

namespace ArtGallery.Domain
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string description { set; get; }
        public Category Parent { get; set; }
    }
}
