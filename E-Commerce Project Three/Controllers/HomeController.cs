using E_Commerce_Project_Three.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce_Project_Three.Models;
using Microsoft.AspNet.Identity;

namespace E_Commerce_Project_Three.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var desktopWallpapers = context.DesktopWallpapers.ToList();
            string currentUserId = User.Identity.GetUserId();
            var countQuery = (from t in context.Transactions
                              where t.AId == currentUserId
                              select t).Count();

            if(countQuery == 0)
            {
                foreach (var item in desktopWallpapers)
                {
                    var transaction = new Transaction
                    {
                        DId = item.DesktopWallpaperId,
                        AId = currentUserId,
                        OutTradeNo = currentUserId + item.DesktopWallpaperId
                    };
                    context.Transactions.Add(transaction);
                }
                context.SaveChanges();
            }

            var transactionsQuery = from t in context.Transactions
                                    where t.AId == currentUserId
                                    select t;
            return View(transactionsQuery.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult PaymentResult(string out_trade_no)
        {
            string currentUserId = User.Identity.GetUserId();
            Transaction transaction;

            if (out_trade_no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactionQuery = from t in context.Transactions
                              where t.OutTradeNo == out_trade_no && t.AId == currentUserId
                              select t;
            if(transactionQuery.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                transaction = transactionQuery.First();
                transaction.Purchased = true;
                context.SaveChanges();
            }
            return View(transaction.DesktopWallpaper);
        }
    }
}