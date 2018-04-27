using System;
using System.Collections.Generic;
using System.Linq;
using SimpleImageGallery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using SimpleImageGallery.Data.Model;
using System.Threading.Tasks;

namespace SimpleImageGallery.Service
{
    public class ImageService : IImage
    {
        private SimpleImageGalleryContext _context;

        public ImageService(SimpleImageGalleryContext context)
        {
            _context = context;
        }

        private IEnumerable<GalleryImage> GetImageIncludeTags()
        {
            return _context.GalleryImages.Include(image => image.Tags);
        }

        public IEnumerable<GalleryImage> GetAll()
        {
            return GetImageIncludeTags().ToList();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return GetImageIncludeTags()
                .Where(image => image.Tags.Any(t => t.Description == tag))
                .ToList();
        }

        public GalleryImage GetById(int id)
        {
            return GetImageIncludeTags()
                .FirstOrDefault(image => image.Id == id);
        }

    }
}
