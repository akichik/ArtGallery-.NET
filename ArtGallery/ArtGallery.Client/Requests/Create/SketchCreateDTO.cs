using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtGallery.Client.Requests.Create
{
    public class SketchCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short description is required")]
        public string shortDesc { get; set; }

        public int? CategoryId { get; set; }
    }
}

