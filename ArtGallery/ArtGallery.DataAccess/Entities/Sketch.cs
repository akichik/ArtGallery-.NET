
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.DataAccess.Entities
{
    public class Sketch
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }
        public string name { set; get; }
        public int? CategoryId { get; set; }

        public virtual Category Category { set; get; }
    }
}
