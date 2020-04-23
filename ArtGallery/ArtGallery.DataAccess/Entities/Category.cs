
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.DataAccess.Entities
{
    public class Category
    {
        public Category(){}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public int? parentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Sketch> Sketch { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
