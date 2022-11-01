using Cafe.Data;
using Cafe.Models;
using System;

namespace Cafe.Services
{
    //Service CRUD functions for Galley and Extra Services 
    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public GalleryService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _db = context;
            _env = env;
        }
        public Gallery GetGallery(int id)
        {
            Gallery gallery = _db.Galleries.Find(id);

            return gallery;
        }
        public bool AddGallery(Gallery gallery)
        {
            if (gallery != null)
            {
                _db.Galleries.Add(gallery);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool RemoveGallery(int Id)
        {
            Gallery gallery = _db.Galleries.Find(Id);

            if (gallery != null)
            {
                _db.Galleries.Remove(gallery);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateGallery(Gallery gallery)
        {
            Gallery galleryU = _db.Galleries.Find(gallery.Id);
            if (galleryU != null)
            {


                galleryU.Name = gallery.Name;
                galleryU.Description = gallery.Description;
                galleryU.TimeStamp = gallery.TimeStamp;

                if (gallery.Images != null)
                {
                    List<GalleryImage> imageListToRemove = galleryU.Images.Where(i => !gallery.Images.Any(n => n.Id == i.Id)).ToList();
                    _db.GalleryImages.RemoveRange(imageListToRemove);
                    _db.SaveChanges();
                }
                else
                {
                    _db.GalleryImages.RemoveRange(galleryU.Images);
                    _db.SaveChanges();
                }

                if (galleryU.Images != null)
                {
                    foreach (var image in galleryU.Images)
                    {
                        string fullUrl = Path.Combine("image", gallery.Images.Where(i => i.Id == image.Id).First().URL.Remove(0, 7));
                        string fullName = Path.Combine(_env.WebRootPath, fullUrl);
                        if (System.IO.File.Exists(fullName))
                        {
                            image.URL = gallery.Images.Where(i => i.Id == image.Id).First().URL;
                            image.TimeStamp = gallery.Images.Where(i => i.Id == image.Id).First().TimeStamp;
                            image.Description = gallery.Images.Where(i => i.Id == image.Id).First().Description;
                        }
                    }
                }

                if (gallery.Images != null)
                {
                    List<GalleryImage> imageListToAdd = gallery.Images.Where(i => i.Id == 0).Select(i => new GalleryImage()
                    {
                        URL = i.URL,
                        Description = i.Description,
                        TimeStamp = i.TimeStamp,
                        GalleryId = galleryU.Id
                    }).ToList();

                    foreach (var image in imageListToAdd)
                    {
                        string fullUrl = Path.Combine("image", image.URL.Remove(0, 7));
                        string fullName = Path.Combine(_env.WebRootPath, fullUrl);
                        if (System.IO.File.Exists(fullName))
                        {
                            _db.GalleryImages.Add(image);
                        }
                    }
                }

                _db.Update(galleryU);
                _db.SaveChanges();
            }
            else
            {
                galleryU = new Gallery();
                galleryU.Name = gallery.Name;
                galleryU.Description = gallery.Description;
                galleryU.TimeStamp=gallery.TimeStamp;

                if (gallery.Images != null)
                {
                    foreach(var image in gallery.Images)
                    {
                        string fullUrl = Path.Combine("image", image.URL.Remove(0, 7));
                        string fullName = Path.Combine(_env.WebRootPath, fullUrl);
                        if (System.IO.File.Exists(fullName)&&image.Id==0)
                        {
                            galleryU.Images.Add(image);
                        }
                    }
                }

                _db.Galleries.Add(galleryU);
                _db.SaveChanges();
            }
            return true;
        }

        public bool AddGalleryImage(GalleryImage image)
        {
            if (image != null)
            {
                _db.GalleryImages.Add(image);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool RemoveGalleryImage(int Id)
        {
            GalleryImage image = _db.GalleryImages.Find(Id);

            if (image != null)
            {
                _db.GalleryImages.Remove(image);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool UpdateGalleryImage(GalleryImage image)
        {
            GalleryImage imageU = _db.GalleryImages.Find(image.Id);
            if (imageU != null)
            {
                imageU.URL = image.URL;
                imageU.Description = image.Description;

                _db.Update(imageU);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public GalleryImage GetGalleryImage(int imageId)
        {
            GalleryImage image = _db.GalleryImages.Find(imageId);

            return image;
        }

        public IList<GalleryImage> GetGalleryImages(int galleryId)
        {
            IList<GalleryImage> imageList = _db.Galleries.Find(galleryId).Images.ToList();

            return imageList;
        }

        public IList<Gallery> GetAll()
        {
            IList<Gallery> galleries = _db.Galleries.Select(g => new Gallery()
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                TimeStamp = g.TimeStamp,
                Images = g.Images.OrderByDescending(i => i.TimeStamp).ToList(),
            }).OrderByDescending(g => g.Images.FirstOrDefault().TimeStamp).ToList();

            return galleries;
        }
        public bool RemoveUrl(string url)
        {
            List<GalleryImage> images = _db.GalleryImages
               .Where(im => im.URL == url).ToList();
            _db.GalleryImages.RemoveRange(images);
            _db.SaveChanges();
            return true;
        }

    }
}
