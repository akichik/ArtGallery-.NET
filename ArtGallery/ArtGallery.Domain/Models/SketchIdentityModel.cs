using ArtGallery.Domain.Contracts;

namespace ArtGallery.Domain.Models
{
    public class SketchIdentityModel: ISketchIdentity
    {
        public int Id { get; }

        public SketchIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
