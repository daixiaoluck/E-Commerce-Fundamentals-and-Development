using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce_Project_Three.Models
{
    public class CartIndexViewModel
    {
        [Display(Name = "Desktop Wallpaper")]
        public List<DesktopWallpaper> DesktopWallpapers { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}