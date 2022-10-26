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
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("orderdetails");
            builder.Property(x => x.Number).IsRequired(false);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Car).WithMany(x => x.OrderDetails).HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
