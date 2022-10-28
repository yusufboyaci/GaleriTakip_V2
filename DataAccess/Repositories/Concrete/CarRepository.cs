using DataAccess.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class CarRepository : Repository<Car>
    {
        private readonly AppDbContext _context;
        public CarRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
