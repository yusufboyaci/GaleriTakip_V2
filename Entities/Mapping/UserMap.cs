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
    public class UserMap: CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired(false);
            builder.HasOne(x => x.Customer).WithOne(x => x.User).HasForeignKey<Customer>(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
