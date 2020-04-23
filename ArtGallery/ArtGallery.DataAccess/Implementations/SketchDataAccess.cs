using ArtGallery.DataAccess.Context;
using ArtGallery.DataAccess.Contracts;
using ArtGallery.Domain;
using ArtGallery.Domain.Contracts;
using ArtGallery.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.DataAccess.Implementations
{
    public class SketchDataAccess: ISketchDataAccess
    {
        private SketchDirectoryContext context { get; }
        private IMapper mapper { get; }

        public SketchDataAccess(SketchDirectoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<Sketch>> GetAsync()
        {
            return this.mapper.Map<IEnumerable<ArtGallery.Domain.Sketch>>(
                await this.context.Sketch.Include(x => x.Category).ToListAsync());
        }

        public async Task<ArtGallery.Domain.Sketch> GetAsync(ISketchIdentity sketch)
        {
            var result = await this.Get(sketch);

            return this.mapper.Map<ArtGallery.Domain.Sketch>(result);
        }

        private async Task<ArtGallery.DataAccess.Entities.Sketch> Get(ISketchIdentity sketch)
        {
            if (sketch == null)
            {
                throw new ArgumentNullException(nameof(sketch));
            }

            return await this.context.Sketch.Include(x => x.Category).FirstOrDefaultAsync(d => d.id == sketch.Id);
        }

        public async Task<Sketch> InsertAsync(SketchUpdateModel sketch)
        {
            var result = await this.context.AddAsync(this.mapper.Map<Sketch>(sketch));

            await this.context.SaveChangesAsync();

            return this.mapper.Map<Sketch>(result.Entity);
        }

        public async Task<ArtGallery.Domain.Sketch> UpdateAsync(SketchUpdateModel sketch)
        {
            var existing = await this.Get(sketch);
            var result = this.mapper.Map(sketch, existing);
            this.context.Update(result);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<ArtGallery.Domain.Sketch>(result);
        }
    }
}
