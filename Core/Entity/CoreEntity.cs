using Core.Enum;
using Core.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        NetworkFuntions networkFuntions = new NetworkFuntions();
        public CoreEntity()
        {

        }
        public Guid Id { get; set; }
        public Guid? MasterId { get; set; } //Üst Id demektir.Yetki vermede kullanılacaktır.
        public Status Status { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
