using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce_Project_Three.Models
{
    public class DesktopWallpaper
    {
        [Key]
        public int DesktopWallpaperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string DisplayThumbnail
        {
            get
            {
                return $"/Images/{DesktopWallpaperId}/Thumbnail.jpg";
            }
        }
        public string DisplayOriginalImage
        {
            get
            {
                return $"/Images/{DesktopWallpaperId}/Original.jpg";
            }
        }
    }
}