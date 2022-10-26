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
    public class CustomerMap : CoreMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.Birthdate).HasColumnType("datetime2").IsRequired(false);
            builder.HasOne(x => x.User).WithOne(x => x.Customer);
            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
