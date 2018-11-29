using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce_Project_Three.Models
{
    public class Transaction
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("DesktopWallpaper")]
        public int DId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("ApplicationUser")]
        public string AId { get; set; }

        public string OutTradeNo { get; set; }
        public bool Purchased { get; set; }
        public virtual DesktopWallpaper DesktopWallpaper{ get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string PaymentUrl
        {
            get
            {
                return $"http://178.128.2.120//userpay/{DId}_{OutTradeNo}_{DesktopWallpaper.Price}/";
            }
        }
    }
}