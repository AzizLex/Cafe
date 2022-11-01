using Cafe.Models;

namespace Cafe.Services
{
    public interface IVenueService
    {

        Venue GetVenue(int Id);
        IList<Venue> GetAll();    
        Boolean AddVenue(Venue venue);
        Boolean RemoveVenue(int id);

        Boolean UpdateVenue(Venue venue);
        Boolean AddVenueImage(VenueImage venueImage);
        Boolean RemoveVenueImage(int Id);
        Boolean UpdateVenueImage(VenueImage image);
        VenueImage GetVenueImage(int imageId);
        IList<VenueImage> GetVenueImages(int imageId);
        bool RemoveUrl(string url);
    }
}

