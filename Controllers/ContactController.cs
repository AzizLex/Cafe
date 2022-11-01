using Microsoft.AspNetCore.Mvc;
using Cafe.Services;
using Cafe.Models.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Cafe.Models;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactServ;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;


        public ContactController( IContactService ContactService, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _contactServ = ContactService;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        //GET: Contact/Index/
        public IActionResult Index()
        {
            return View();

        }

        //POST: Contact/Index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactFormVM contactForm)
        {
            if (contactForm.Captcha != null) { return RedirectToAction("Confirm"); } //Spambot in honeytrap, thanks for effort:)

            if (ModelState.IsValid)
            {
                _contactServ.AddContactForm(contactForm);
                var subject = "You have received a new message from Havana Café";
                var body = 
                    $"<b>Message received:</b> {contactForm.TimeStamp} <br/>" +
                    $"<b>Sender:</b> {contactForm.Name} <br/>" +
                    $"<b>Email:<b> <a href='mailto:{contactForm.Email}'>{contactForm.Email}</a> <br/>" +
                    $"<b>Phone:<b> <a href='tel:{contactForm.Phone}'>{contactForm.Phone}</a> <br/>" +
                    $"<hr>" +
                    $"<b>Message:</b>  <br/>" +
                    $"{contactForm.Comment}"; 

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
            return View(contactForm);
        }


        public IActionResult Confirm()
        {
            return View();
        }
    }
}