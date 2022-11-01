using Cafe.Data;
using Cafe.Models;
using Cafe.Models.ViewModels;

namespace Cafe.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _db;
        private readonly IVenueService _venueService;
        private readonly IExtrasService _extrasService;

        public BookingService(ApplicationDbContext context, IVenueService venueService, IExtrasService extrasService)
        {
            _db = context;
            _venueService = venueService;
            _extrasService = extrasService;
        }

        public BookingForm AddBookingForm(BookingVM bookVM)
        {
            BookingForm form = new BookingForm();

            form.Name = bookVM.Name;
            form.Phone = bookVM.Phone;
            form.Email = bookVM.Email;
            form.Guests = bookVM.Guests;
            form.Plates = bookVM.Plates;
            form.Cuisine = bookVM.Cuisine;
            form.Comment = bookVM.Comment;
            form.TimeStamp = DateTime.Now;

            switch (bookVM.VenueId)
            {
                case 0:
                    form.Venues = new List<Venue>();
                    break;
                case -1:
                    break;
                case -2:
                    form.Venues = _venueService.GetAll();
                    break;
                default:
                    form.Venues = new List<Venue>();
                    form.Venues.Add(_venueService.GetVenue(bookVM.VenueId));
                    break;
            }
            form.Extras = new List<ExtraService>();
            foreach (var item in bookVM.Extras)
            {
                if (item.Checked) form.Extras.Add(_extrasService.GetExtraService(item.Id));
            }

            _db.Add(form);
            _db.SaveChanges();

            return form;
        }



        public Boolean DeleteBookingForm(int Id)
        {
            BookingForm DeleteBooking = _db.BookingForms.Find(Id);

            if (DeleteBooking != null)
            {
                _db.Remove(DeleteBooking);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public int BookingFormsCount()
        {
            return _db.BookingForms.Count();
        }

        public BookingForm GetBookingForm(int Id)
        {
            BookingForm bookingForm = _db.BookingForms.Find(Id);
            if (bookingForm != null)
            {
                bookingForm.ReadStatus = true;
                _db.BookingForms.Update(bookingForm);
                _db.SaveChanges();
            }
            return bookingForm;
        }

        public IList<BookingForm> AllBookingForms()
        {
            return _db.BookingForms.ToList();
        }
        public IList<BookingForm> AllBookingForms(int Id)
        {
            return _db.BookingForms.OrderByDescending(c => c.TimeStamp).Skip(10 * (Id - 1)).Take(10).ToList();
        }

    }
}
