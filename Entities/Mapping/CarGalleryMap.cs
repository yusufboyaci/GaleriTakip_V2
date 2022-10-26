using Core.Mapping;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Mapping
{
    public class CarGalleryMap: CoreMap<CarGallery>
    {
        public override void Configure(EntityTypeBuilder<CarGallery> builder)
        {
            builder.ToTable("cargalleries");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired(false);
            builder.HasMany(x => x.Cars).WithOne(x => x.CarGallery).HasForeignKey(x => x.CarGalleryId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
