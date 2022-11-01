using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cafe.Models
{
    public class GalleryImage
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public string URL { get; set; }

        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]

        public DateTime TimeStamp { get; set; }
        
        public int GalleryId { get; set; }
        
        public virtual Gallery Gallery { get; set; }
        public GalleryImage()
        {

        }
    }
}
