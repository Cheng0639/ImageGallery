using System.Collections.Generic;
using SimpleImageGallery.Data.Model;

namespace SimpleImageGallery.Service
{
    public interface IImage
    {
        IEnumerable<GalleryImage> GetAll();

        IEnumerable<GalleryImage> GetWithTag(string tag);

        GalleryImage GetById(int id);
    }
}