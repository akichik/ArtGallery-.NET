
using ArtGallery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArtGallery.DataAccess.Context
{
    public partial class SketchDirectoryContext: DbContext
    {
        public SketchDirectoryContext() { }

        public SketchDirectoryContext(DbContextOptions<SketchDirectoryContext> options)
        : base(options) { }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Sketch> Sketch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);


                entity.HasOne(d => d.Parent)
                     .WithMany(p => p.InverseParent)
                     .HasForeignKey(d => d.parentId);
            });

            modelBuilder.Entity<Sketch>(entity =>
            {
                entity.Property(e => e.id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property(e => e.name).IsRequired();
                

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sketch)
                    .HasForeignKey(d => d.CategoryId);
            });

            this.OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
