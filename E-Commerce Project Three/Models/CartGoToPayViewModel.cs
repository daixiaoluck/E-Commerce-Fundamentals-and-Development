using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Project_Three.Models
{
    public class CartGoToPayViewModel
    {
        public List<DesktopWallpaper> DesktopWallpapers { get; set; }
        public decimal TotalPrice { get; set; }
        public int TransactionId { get; set; }
    }
}