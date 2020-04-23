using System.Collections.Generic;
using System.Threading.Tasks;
using ArtGallery.BLL.Contracts;
using ArtGallery.Client.DTO.Read;
using ArtGallery.Client.Requests.Create;
using ArtGallery.Client.Requests.Update;
using ArtGallery.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtGallery.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SketchController : ControllerBase
    {
        private ILogger<SketchController> Logger { get; }
        private ISketchCreateService SketchCreateService { get; }
        private ISketchGetService SketchGetService { get; }
        private ISketchUpdateService SketchUpdateService { get; }
        private IMapper Mapper { get; }

        public SketchController(ILogger<SketchController> logger, IMapper mapper, ISketchCreateService sketchCreateService, ISketchGetService sketchGetService, ISketchUpdateService sketchUpdateService)
        {
            this.Logger = logger;
            this.SketchCreateService = sketchCreateService;
            this.SketchGetService = sketchGetService;
            this.SketchUpdateService = sketchUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<SketchDTO> PutAsync(SketchCreateDTO sketch)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SketchCreateService.CreateAsync(this.Mapper.Map<SketchUpdateModel>(sketch));

            return this.Mapper.Map<SketchDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<SketchDTO> PatchAsync(SketchUpdateDTO sketch)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SketchUpdateService.UpdateAsync(this.Mapper.Map<SketchUpdateModel> (sketch));

            return this.Mapper.Map<SketchDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<SketchDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<SketchDTO>>(await this.SketchGetService.GetAsync());
        }

        [HttpGet]
        [Route("{sketchId}")]
        public async Task<SketchDTO> GetAsync(int sketchId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {sketchId}");

            return this.Mapper.Map<SketchDTO>(await this.SketchGetService.GetAsync(new SketchIdentityModel(sketchId)));
        }
    }
}