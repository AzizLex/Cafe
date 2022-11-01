using Cafe.Models;
using Cafe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        public GalleryController(IGalleryService galleryService)
        {
            _galleryService=galleryService;
        }
        public IActionResult Index()
        {
            IList<Gallery> galleries = _galleryService.GetAll();
            return View(galleries);
        }
        public IActionResult Item(int Id)
        {
            Gallery gallery = _galleryService.GetGallery(Id);
            return View(gallery);
        }
    }
}
