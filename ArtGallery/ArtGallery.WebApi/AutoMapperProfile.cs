using ArtGallery.Client.DTO.Read;
using ArtGallery.Client.Requests.Create;
using ArtGallery.Client.Requests.Update;
using ArtGallery.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.WebApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Sketch, Domain.Sketch>();
            this.CreateMap<DataAccess.Entities.Category, Domain.Category>();
            this.CreateMap<Domain.Sketch, SketchDTO>();
            this.CreateMap<Domain.Category, CategoryDTO>();
            this.CreateMap<SketchCreateDTO, SketchUpdateModel>();
            this.CreateMap<SketchUpdateDTO, SketchUpdateModel>();
            this.CreateMap<SketchUpdateModel, DataAccess.Entities.Sketch>();
        }
        
    }
}
