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
    public class CarMap : CoreMap<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("cars");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.HasOne(x => x.CarGallery).WithMany(x => x.Cars).HasForeignKey(x => x.CarGalleryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Car).HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
