using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleImageGallery.Data.Model;
using SimpleImageGallery.Models;
using SimpleImageGallery.Service;

namespace SimpleImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        public GalleryController(IImage service)
        {
            this.service = service;
        }

        private readonly IImage service;

        public IActionResult Index()
        {
            var imageList = service.GetAll();

            var model = new GalleryIndexModel
            {
                Images = imageList,
                SearchQuery = string.Empty
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var image = service.GetById(id);

            var model = new GalleryDetailModel
            {
                Id = image.Id,
                Title = image.Title,
                CreatedOn = image.Created,
                Url = image.Url,
                Tags = image.Tags.Select(tag => tag.Description).ToList()
            };

            return View(model);
        }
    }
}