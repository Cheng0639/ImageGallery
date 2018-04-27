using System.Collections.Generic;
using SimpleImageGallery.Data.Model;
using SimpleImageGallery.Service;

namespace SimpleImageGallery.Service
{
    public class MockupImageService : IImage
    {
        public IEnumerable<GalleryImage> GetAll()
        {
            return new List<GalleryImage>();
        }

        public IEnumerable<GalleryImage> GetWithTag(string tag)
        {
            return new List<GalleryImage>();
        }

        public GalleryImage GetById(int id)
        {
            return null;
        }

    }
}