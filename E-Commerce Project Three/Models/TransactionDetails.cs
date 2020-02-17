using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project_Three.Models
{
    public class TransactionDetails
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("DesktopWallpaper")]
        public int DesktopWallpaperId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        //以下properties在数据库中是不存在的。
        //设置外键时，却可以只设置下面的对象，完全不管上面的外键，系统会自动帮你填充上面外键的值的
        //具体例子参见CartController里的GoToPay这个Action。
        public Transaction Transaction { get; set; }
        public DesktopWallpaper DesktopWallpaper { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}