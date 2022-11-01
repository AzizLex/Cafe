using Cafe.Models;

namespace Cafe.Services
{
    public interface IGalleryService
    {
        bool AddGallery(Gallery gallery);
        bool RemoveGallery(int Id);
        bool UpdateGallery(Gallery gallery);
        Gallery GetGallery(int Id);
        IList<Gallery> GetAll();
        bool AddGalleryImage(GalleryImage image);
        bool RemoveGalleryImage(int Id);
        bool UpdateGalleryImage(GalleryImage image);
        GalleryImage GetGalleryImage(int imageId);
        IList<GalleryImage> GetGalleryImages(int galleryId);
        bool RemoveUrl(string url);
    }
}
