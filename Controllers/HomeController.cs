using Cafe.Models;
using Cafe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGalleryService _galleryService;
        private readonly IAboutService _aboutService;

        public HomeController(ILogger<HomeController> logger, IGalleryService galleryService, IAboutService aboutService)
        {
            _logger = logger;
            _galleryService = galleryService;
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            IList<Gallery> galleryList = _galleryService.GetAll();
            galleryList = galleryList.Take(5).ToList();
            string[] homeslides = _aboutService.ReadOption("homeSlide").Select(o => o.Value).ToArray();
            ViewBag.HomeSlides=homeslides;

            return View(galleryList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            About modelAbout=_aboutService.ReadAbout();
            return View(modelAbout);
        }

        public IActionResult Policy()
        {
            Policy modelPolicy = _aboutService.ReadPolicy();
            return View(modelPolicy);
        }

        public IActionResult Confirm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        class Credentials
        {
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Opening1 { get; set; }
            public string Opening2 { get; set; }
            public string Opening3 { get; set; }
        }

        public IActionResult AjaxAddress() //Get Menu Item
        {
            Credentials cred = new Credentials();
            cred.Address = _aboutService.ReadOption("_address").FirstOrDefault()?.Value;
            cred.Phone = _aboutService.ReadOption("_phone").FirstOrDefault()?.Value;
            cred.Email = _aboutService.ReadOption("_email").FirstOrDefault()?.Value;
            cred.Opening1 = _aboutService.ReadOption("_opening1").FirstOrDefault()?.Value;
            cred.Opening2 = _aboutService.ReadOption("_opening2").FirstOrDefault()?.Value;
            cred.Opening3 = _aboutService.ReadOption("_opening3").FirstOrDefault()?.Value;

            return Json(cred);
        }
        public IActionResult AjaxSlide() //Get Menu Item
        {
            string[] homeslides=_aboutService.ReadOption("homeSlide").Select(o=>o.Value).ToArray();
            return Json(homeslides);
        }
    }
}