using Core.Enum;
using DataAccess.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class OrderRepository : Repository<Order>
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Order> ListUnapprovedOrders()
        {
            return GetDefaults(x => x.Status == Status.Active && x.IsConfirmed == false).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public int ShowNumberOfTheUnapprovedOrders()
        {
            return GetDefaults(x => x.Status == Status.Active && x.IsConfirmed == false).ToList().Count();  
        }
    }
}
