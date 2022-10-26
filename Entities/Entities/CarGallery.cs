using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class CarGallery : CoreEntity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }

        //Navigation Property
        public virtual List<Car>? Cars { get; set; }
    }
}
