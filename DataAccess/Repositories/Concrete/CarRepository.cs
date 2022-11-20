using DataAccess.Context;
using DataAccess.ViewModels;
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
        /// <summary>
        /// Araba ve Galerileri liste olarak getiren metottur.
        /// </summary>
        /// <param name="galleries">Galeri listesi</param>
        /// <param name="cars">Araba listesi</param>
        /// <returns>Araba ve Galeri listesini döndürür.</returns>
        public List<TableOfTheCarAndGallery> GetCarsAndGaleries(List<CarGallery> galleries, List<Car> cars)
        {
            List<TableOfTheCarAndGallery> list = (
                from g in galleries
                join c in cars
                on g.Id equals c.CarGalleryId
                select new TableOfTheCarAndGallery
                {
                    Id = c.Id,
                    GalleryName = g.Name,
                    GalleryAddress = g.Address,
                    CarName = c.Name,
                    Price = c.Price,
                    Stock = c.Stock,
                    FilePath = c.FilePath,
                    Description = c.Descripton
                }
                ).ToList();
            return list;
        }
    }
}
