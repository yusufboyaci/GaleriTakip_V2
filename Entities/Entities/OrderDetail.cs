using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class OrderDetail: CoreEntity
    {
        public decimal? UnitPrice { get; set; }
        public int? Number { get; set; }
        public string? FilePath { get; set; }
        public Guid CarId { get; set; }
        public Guid OrderId { get; set; }

        //Navigation Properties
        public virtual Order? Order { get; set; }
        public virtual Car? Car { get; set; }
    }
}
