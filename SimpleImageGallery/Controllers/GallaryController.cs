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
    }
}