using Cafe.Data;
using Cafe.Models;

namespace Cafe.Services
{
    public class VenueService : IVenueService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public VenueService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _db = context;
            _env = env;
        }
        public Venue GetVenue(int id)
        {
            Venue venue = _db.Venues.Find(id);
            if (venue?.Images is null)
            {
                venue.Images = new List<VenueImage>();
            }

            return venue;
        }
        public Boolean AddVenue(Venue venue)
        {
            if (venue != null)
            {
                _db.Venues.Add(venue);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        // Är RemoveVenue nedan rätt?? Och Boolean-bool?
        public Boolean RemoveVenue(int id)
        {
            Venue venue = _db.Venues.Find(id);

            if (venue != null)
            {
                _db.Venues.Remove(venue);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean UpdateVenue(Venue venue)
        {
            Venue venueU = _db.Venues.Find(venue.Id);
            if (venueU != null)
            {
                venueU.Name = venue.Name;
                venueU.Description = venue.Description;
                venueU.Area = venue.Area;
                venueU.Guests = venue.Guests;
                venueU.Table = venue.Table;
                venueU.Equipment = venue.Equipment;
                venueU.Other = venue.Other;
                venueU.Price = venue.Price;
                if (venue.Images != null)
                {
                    List<VenueImage> imageListToRemove = venueU.Images.Where(i => !venue.Images.Any(n => n.Id == i.Id)).ToList();
                    _db.VenueImages.RemoveRange(imageListToRemove);
                }
                else
                {
                    _db.VenueImages.RemoveRange(venueU.Images);
                }

                if (venue.Images != null)
                {
                    List<VenueImage> imageListToAdd = venue.Images.Where(i => i.Id == 0).Select(i => new VenueImage()
                    {
                        Id = i.Id,
                        URL = i.URL,
                        VenueId = venueU.Id
                    }).ToList();

                    foreach (var image in imageListToAdd)
                    {
                        string fullUrl = Path.Combine("image", image.URL.Remove(0, 7));
                        string fullName = Path.Combine(_env.WebRootPath, fullUrl);
                        if (System.IO.File.Exists(fullName))
                        {
                            _db.VenueImages.Add(image);
                        }
                    }
                }

                _db.Venues.Update(venueU);
                _db.SaveChanges();
            }
            else
            {
                venueU = new Venue();
                venueU.Name = venue.Name;
                venueU.Description = venue.Description;
                venueU.Area = venue.Area;
                venueU.Guests = venue.Guests;
                venueU.Table = venue.Table;
                venueU.Equipment = venue.Equipment;
                venueU.Other = venue.Other;
                venueU.Price = venue.Price;

                if (venue.Images != null) venueU.Images = venue.Images.Where(i => i.Id == 0).Select(i => new VenueImage()
                {
                    Id = i.Id,
                    URL = i.URL,
                }).ToList();

                _db.Venues.Add(venueU);
                _db.SaveChanges();

            }
            return true;
        }
        public Boolean AddVenueImage(VenueImage image)
        {
            if (image != null)
            {
                _db.VenueImages.Add(image);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean RemoveVenueImage(int Id)
        {
            VenueImage image = _db.VenueImages.Find(Id);

            if (image != null)
            {
                _db.VenueImages.Remove(image);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool UpdateVenueImage(VenueImage image)
        {
            //throw new NotImplementedException();
            VenueImage venueImageU = _db.VenueImages.Find(image.Id);
            if (venueImageU != null)
            {
                venueImageU.URL = image.URL;

                _db.VenueImages.Update(venueImageU);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }


        public VenueImage GetVenueImage(int imageId)
        {
            //throw new NotImplementedException();
            VenueImage venueImage = _db.VenueImages.Find(imageId);

            return venueImage;
        }

        public IList<VenueImage> GetVenueImages(int venueId)
        {
            IList<VenueImage> imageList = _db.Venues.Find(venueId).Images.ToList();

            return imageList;

        }

        public IList<Venue> GetAll()
        {
            IList<Venue> venues = _db.Venues.ToList();

            return venues;
        }
        public bool RemoveUrl(string url)
        {
            List<VenueImage> images = _db.VenueImages
                .Where(im => im.URL == url).ToList();
            _db.VenueImages.RemoveRange(images);
            _db.SaveChanges();

            return true;
        }
    }
}
