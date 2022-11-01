using Cafe.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Cafe.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Cafe.Models;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingServ;
        private readonly IVenueService _venueService;
        private readonly IExtrasService _extrasService;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(IBookingService BookingService, IVenueService venueService, IExtrasService extrasService, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _bookingServ = BookingService;
            _venueService = venueService;
            _extrasService = extrasService;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        //GET: Booking/Index/
        public IActionResult Index()
        {
            BookingVM bookVM = new BookingVM(_venueService.GetAll(), _extrasService.GetAll());
            return View(bookVM);
        }

        //POST: Booking/Index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(BookingVM bookVM)
        {

            if (bookVM.Captcha != null) { return RedirectToAction("Confirm"); } //Spambot in honeytrap, thanks for effort:)

            if (ModelState.IsValid)
            {
                BookingForm form = _bookingServ.AddBookingForm(bookVM);

                var subject = "You have received a new booking request from Havana Café";

                string venues = String.Join(", ", form.Venues.Select(v => v.Name).ToArray());
                string extras = String.Join(", ", form.Extras.Select(e => e.Name).ToArray());

                var body =
                    $"<b>Request received:</b> {form.TimeStamp} <br/>" +
                    $"<b>Sender:</b> {form.Name} <br/>" +
                    $"<b>Email:<b> <a href='mailto:{form.Email}'>{form.Email}</a> <br/>" +
                    $"<b>Phone:<b> <a href='tel:{form.Phone}'>{form.Phone}</a> <br/>" +
                    $"<hr>" +
                    $"<b>Venues:</b> {venues} <br/>" +
                    $"<b>Guests:</b> {form.Guests} <b>eating guests:</b> {form.Plates}<br/>" +
                    $"<b>Food choice:</b> {form.Cuisine}<br/>" +
                    $"<b>Extra services:</b> {extras} <br/>" +
                    $"<hr>" +
                    $"<b>Message:</b>  <br/>" +
                    $"{form.Comment}";

                await _emailSender.SendEmailAsync("info@Cafe.se", subject, body);
                
                List<ApplicationUser> users = _userManager.Users.ToList();

                foreach (var user in users)
                {
                    if (_userManager.IsInRoleAsync(user, "Administrator").Result)
                    {
                        await _emailSender.SendEmailAsync(user.Email, subject, body);
                    }

                }

                return RedirectToAction("Confirm");
            }
            return View(bookVM);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}