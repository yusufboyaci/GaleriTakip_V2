using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class TableOfTheCarAndGallery
    {
        public Guid Id { get; set; }
        public string? GalleryName { get; set; }
        public string? GalleryAddress { get; set; }
        public string? CarName { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
    }
}
