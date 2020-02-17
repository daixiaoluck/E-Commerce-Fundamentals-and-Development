using E_Commerce_Project_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace E_Commerce_Project_Three.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            List<DesktopWallpaper> desktopWallpapers = _context.DesktopWallpapers.ToList();
            List<HomeIndexViewModel> homeIndexViewModels = new List<HomeIndexViewModel>();
            string currentUserId = User.Identity.GetUserId();
            foreach (var desktopWallpaper in desktopWallpapers)
            {
                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel{
                    DesktopWallpaper = desktopWallpaper
                };
                // select子句的内容只是为了方便调试，对业务逻辑没有意义
                var query = from transaction in _context.Transactions
                            join transactionDetails in _context.TransactionDetails
                            on transaction.TransactionId equals transactionDetails.TransactionId
                            where transactionDetails.UserId == currentUserId && transactionDetails.DesktopWallpaperId == desktopWallpaper.DesktopWallpaperId && transaction.Completeness == true
                            select new { transaction.TransactionId, transaction.Completeness, transactionDetails.DesktopWallpaperId, transactionDetails.UserId };
                if(query.Count() > 0)
                {
                    homeIndexViewModel.Purchased = true;
                }
                homeIndexViewModels.Add(homeIndexViewModel);
            }
            return View(homeIndexViewModels);
        }

        [Authorize]
        public ActionResult ShowItem(int desktopWallpaperId)
        {
            string currentUserId = User.Identity.GetUserId();
            // select子句的内容只是为了方便调试，不管select什么，都和业务逻辑无关。业务逻辑只看重聚合函数的结果。
            int criterion = (from transaction in _context.Transactions
                             join transactionDetails in _context.TransactionDetails
                             on transaction.TransactionId equals transactionDetails.TransactionId
                             where transactionDetails.UserId == currentUserId && transactionDetails.DesktopWallpaperId == desktopWallpaperId && transaction.Completeness == true
                             select transactionDetails).Count();
            if(criterion == 0)
            {
                
                return View("Error", new HandleErrorInfo( new Exception("You have not bought this item yet."), 
                    ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString() )
                );
            }
            else
            {
                DesktopWallpaper desktopWallpaper = _context.DesktopWallpapers.Where(d => d.DesktopWallpaperId == desktopWallpaperId).First();
                return View(desktopWallpaper);
            }
        }
    }
}