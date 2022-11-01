using Cafe.Models;
using Cafe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;
        private readonly IAboutService _aboutService;

        public VenueController(IVenueService venueService, IAboutService aboutService)
        {
            _venueService = venueService;
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            IList<Venue> venues = _venueService.GetAll();
            string[] venuelides = _aboutService.ReadOption("venueSlide").Select(o => o.Value).ToArray();
            ViewBag.VenueSlides = venuelides;
            return View(venues);
        }
        public IActionResult Item(int Id)
        {
            Venue venue = _venueService.GetVenue(Id);
            return View(venue);
        }
    }
}
