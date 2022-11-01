using Cafe.Models;
using Cafe.Models.ViewModels;

namespace Cafe.Services
{
    public interface IBookingService

    {
        //Booking form CRUD - create, read, update, delete

        BookingForm AddBookingForm(BookingVM bookVM);
        BookingForm GetBookingForm(int Id);
        IList<BookingForm> AllBookingForms();
        int BookingFormsCount();
        IList<BookingForm> AllBookingForms(int Id);
        Boolean DeleteBookingForm(int Id);
    }
}
