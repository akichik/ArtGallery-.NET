namespace ArtGallery.Client.DTO.Read
{
    public class SketchDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public int year { get; set; }
        public string description { get; set; }

        public CategoryDTO Category { set; get; }
    }
}
