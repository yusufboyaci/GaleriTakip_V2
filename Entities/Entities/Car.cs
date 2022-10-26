using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Car : CoreEntity
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? FilePath { get; set; }
        public string? Descripton { get; set; }
        public Guid CarGalleryId { get; set; }//FK

        //Navigation Properties
        public virtual CarGallery? CarGallery { get; set; }
        public virtual List<OrderDetail>? OrderDetails { get; set; }
    }
}
