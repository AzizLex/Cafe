
using Cafe.Models;
using Cafe.Models.ViewModels;
using Cafe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {

        private readonly IAboutService _aboutService;
        private readonly IVenueService _venueService;
        private readonly IMenuService _menuService;
        private readonly IExtrasService _extraService;
        private readonly IContactService _contactService;
        private readonly IBookingService _bookingService;
        private readonly IGalleryService _galleryService;

        public AdminController(IMenuService menuService,
            IVenueService venueService,
            IAboutService aboutService,
            IContactService contactService,
            IBookingService bookingService,
            IExtrasService extraService,
            IGalleryService galleryService)

        {
            _menuService = menuService;
            _venueService = venueService;
            _aboutService = aboutService;
            _extraService = extraService;
            _contactService = contactService;
            _bookingService = bookingService;
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {

            return View();
        }

        //----------------------------------------------------------
        //--------------------- Menu Actions -----------------------
        //----------------------------------------------------------

        public IActionResult Menu()
        {
            AdminMenuVM Model = new AdminMenuVM();
            Model.Categories = _menuService.GetAll();

            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Menu(MenuCategory newCategory)
        {
            if (ModelState.IsValid)
            {
                _menuService.UpdateMenuCategory(newCategory);
            }
            AdminMenuVM model = new AdminMenuVM();
            model.Categories = _menuService.GetAll();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MenuCategoryDel(string categoryId)
        {
            if (categoryId != "")
            {
                _menuService.RemoveMenuCategory(int.Parse(categoryId));
            }

            return RedirectToAction("Menu");
        }

        public IActionResult MenuSubCat(int id)
        {

            MenuSubCat model = new MenuSubCat();
            model = _menuService.GetMenuSubCat(id);
            if (model == null)
            {
                return RedirectToAction("Menu");
            }
            TempData["SubCatId"] = id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MenuSubCat(int id, string name)
        {
            if (id != 0 && (name != "" || name != null))
            {
                if (_menuService.GetMenuSubCat(id) != null)
                {
                    MenuItem newMenuItem = new MenuItem();
                    newMenuItem.Name = name;
                    newMenuItem.MenuSubCatId = id;
                    _menuService.AddMenuItem(newMenuItem);
                }
            }


            MenuSubCat model = new MenuSubCat();
            model = _menuService.GetMenuSubCat(id);

            if (model == null)
            {
                return RedirectToAction("Menu");
            }
            TempData["SubCatId"] = id;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MenuItemDel(string itemId)
        {
            if (itemId != "")
            {
                _menuService.RemoveMenuItem(int.Parse(itemId));
            }
            int id = (int)TempData["SubCatId"];

            return RedirectToAction("MenuSubCat", new { id = id });
        }

        public IActionResult MenuItemEdit(int id, int iId)
        {
            MenuItem model = _menuService.GetMenuItem(iId);

            if (model == null)
            {
                return RedirectToAction("MenuSubCat", new { id = id });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult MenuItemEdit(MenuItem newItem)
        {
            if (ModelState.IsValid)
            {
                _menuService.UpdateMenuItem(newItem);
                return RedirectToAction("MenuSubCat", new { id = newItem.MenuSubCatId });
            }
            return View(newItem);
        }

        public IActionResult MenuItemAdd(int id)
        {
            MenuItem model = new MenuItem();


            if (id == 0)
            {
                return RedirectToAction("Menu");
            }
            else
            {
                model.MenuSubCatId = id;
            }

            return View("MenuItemEdit", model);
        }

        //----------------------------------------------------------
        //--------------------- Venue Actions ----------------------
        //----------------------------------------------------------

        public IActionResult Venue()
        {
            IList<Venue> venueList = _venueService.GetAll();
            return View(venueList);
        }
        public IActionResult VenueItem(int id)
        {
            Venue venue = _venueService.GetVenue(id);
            return View(venue);
        }
        [HttpPost]
        public IActionResult VenueItem(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _venueService.UpdateVenue(venue);
            }
            return RedirectToAction("Venue");
        }

        public IActionResult VenueItemAdd()
        {
            Venue venue = new Venue();
            venue.Images = new List<VenueImage>();
            return View("VenueItem", venue);
        }

        public IActionResult VenueItemDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _venueService.RemoveVenue(id);
            }
            return RedirectToAction("Venue");
        }

        //----------------------------------------------------------
        //--------------------- Gallery Actions --------------------
        //----------------------------------------------------------

        public IActionResult Gallery()
        {
            IList<Gallery> gallery = _galleryService.GetAll();
            return View(gallery);
        }

        public IActionResult GalleryItem(int id)
        {
            Gallery gallery = _galleryService.GetGallery(id);
            return View(gallery);
        }

        [HttpPost]
        public IActionResult GalleryItem(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                _galleryService.UpdateGallery(gallery);
                return RedirectToAction("Gallery");
            }

            return View(gallery);
        }
        public IActionResult GalleryItemDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _galleryService.RemoveGallery(id);
            }
            return RedirectToAction("Gallery");
        }

        public IActionResult GalleryItemAdd()
        {
            Gallery gallery = new Gallery();

            return View("GalleryItem", gallery);
        }

        //----------------------------------------------------------
        //--------------------- Contact Actions --------------------
        //----------------------------------------------------------

        public IActionResult Contact(int Id) //Id is current page for pagination
        {
            int totalPage = (int)Math.Ceiling(_contactService.ContactFormsCount() / (float)10);
            if (Id > totalPage) Id = totalPage;
            if (Id < 1) Id = 1;
            if (totalPage < 1) totalPage = 1;

            IList<ContactForm> contactForms = _contactService.AllContactForms(Id);
            TempData["CurrentPage"] = Id;
            TempData["TotalPage"] = totalPage;
            HttpContext.Session.SetInt32("CurrentCPage", Id);

            return View(contactForms);
        }
        public IActionResult ContactForm(int Id) //Id is ContactForm.Id to show
        {
            TempData["CurrentPage"] = HttpContext.Session.GetInt32("CurrentCPage");
            ContactForm contactForm = _contactService.GetContactForm(Id);

            return View(contactForm);
        }

        public IActionResult ContactFormDelete(int Id) //Id is ContactForm.Id to delete
        {
            _contactService.DeleteContactForm(Id);

            return RedirectToAction("Contact", new { Id = HttpContext.Session.GetInt32("CurrentCPage") });
        }

        //----------------------------------------------------------
        //--------------------- Booking Actions --------------------
        //----------------------------------------------------------

        public IActionResult Booking(int Id) //Id is current page for pagination
        {
            int totalPage = (int)Math.Ceiling(_bookingService.BookingFormsCount() / (float)10);
            if (Id > totalPage) Id = totalPage;
            if (Id < 1) Id = 1;
            if (totalPage < 1) totalPage = 1;

            IList<BookingForm> bookingForms = _bookingService.AllBookingForms(Id);
            TempData["CurrentPage"] = Id;
            TempData["TotalPage"] = totalPage;
            HttpContext.Session.SetInt32("CurrentBPage", Id);

            return View(bookingForms);
        }
        public IActionResult BookingForm(int Id) //Id is ContactForm.Id to show
        {
            TempData["CurrentPage"] = HttpContext.Session.GetInt32("CurrentBPage");
            BookingForm bookingForm = _bookingService.GetBookingForm(Id);

            return View(bookingForm);
        }

        public IActionResult BookingFormDelete(int Id) //Id is ContactForm.Id to delete
        {
            _bookingService.DeleteBookingForm(Id);

            return RedirectToAction("Booking", new { Id = HttpContext.Session.GetInt32("CurrentBPage") });
        }

        //----------------------------------------------------------
        //--------------------- ExtraService Actions --------------------
        //----------------------------------------------------------

        public IActionResult ExtraService()
        {
            IList<ExtraService> extraServiceList = _extraService.GetAll();
            return View(extraServiceList);
        }

        public IActionResult ExtraServiceItem(int id)
        {
            ExtraService extraService = _extraService.GetExtraService(id);
            return View(extraService);
        }
        [HttpPost]
        public IActionResult ExtraServiceItem(ExtraService extraService)
        {
            if (ModelState.IsValid)
            {
                _extraService.UpdateExtraService(extraService);
            }

            //return View(extraService);
            return RedirectToAction("ExtraService");
        }
        public IActionResult ExtraServiceItemDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _extraService.RemoveExtraService(id);
            }
            return RedirectToAction("ExtraService");
        }

        public IActionResult ExtraServiceItemAdd()
        {
            ExtraService extraservice = new ExtraService();

            return View("ExtraServiceItem", extraservice);
        }

        //----------------------------------------------------------
        //--------------------- About Actions ----------------------
        //----------------------------------------------------------

        public IActionResult About()
        {
            About about = _aboutService.ReadAbout();
            return View(about);
        }
        [HttpPost]
        public IActionResult About(About about)
        {
            if (ModelState.IsValid)
            {
                _aboutService.UpdateAbout(about);
                return RedirectToAction("About");
            }
            return View(about);
        }

        //----------------------------------------------------------
        //--------------------- Policy Actions ---------------------
        //----------------------------------------------------------

        public IActionResult Policy()
        {
            Policy policy = _aboutService.ReadPolicy();
            return View(policy);
        }
        [HttpPost]
        public IActionResult Policy(Policy policy)
        {
            if (ModelState.IsValid)
            {
                _aboutService.UpdatePolicy(policy); 
                return RedirectToAction("Policy");
            }
            return View(policy);
        }

        //----------------------------------------------------------
        //--------------------- Options Actions ---------------------
        //----------------------------------------------------------

        public IActionResult Options()
        {
            List<Option> options = _aboutService.ReadOptions();
            return View(options);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Options(IList<Option> options)
        {
            if (ModelState.IsValid)
            {
                _aboutService.UpdateOptions(options);
                return RedirectToAction("Options");
            }
            return View(options);
        }

    }


}
