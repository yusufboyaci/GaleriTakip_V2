using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {

        }
        public Guid CustomerId { get; set; }//FK
        public bool OnaylandiMi { get; set; }
        public string? FilePath { get; set; }
    }
}
