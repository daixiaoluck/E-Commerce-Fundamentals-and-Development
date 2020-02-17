using E_Commerce_Project_Three.Data;
using E_Commerce_Project_Three.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace E_Commerce_Project_Three.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            int totalCount = 0;
            decimal totalPrice = 0;
            List<int> desktopWallpaperIds = (List<int>)Session["desktopWallpaperIds"];
            /*因为页面需要metadata，所以不可设为null*/
            List<DesktopWallpaper> desktopWallpapers = new List<DesktopWallpaper> { };

            if(desktopWallpaperIds != null)
            {
                foreach (int desktopWallpaperId in desktopWallpaperIds)
                {
                    DesktopWallpaper desktopWallpaper = _context.DesktopWallpapers.Where(d => d.DesktopWallpaperId == desktopWallpaperId).First();
                    if (desktopWallpaper != null)
                    {
                        desktopWallpapers.Add(desktopWallpaper);
                        totalCount++;
                        totalPrice += desktopWallpaper.Price;
                    }
                }
            }

            CartIndexViewModel cartIndexViewModel = new CartIndexViewModel
            {
                DesktopWallpapers = desktopWallpapers,
                TotalCount = totalCount,
                TotalPrice = totalPrice
            };
            return View(cartIndexViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult GoToPay(decimal totalPrice)
        {
            List<int> desktopWallpaperIds = (List<int>)Session["desktopWallpaperIds"];
            List<DesktopWallpaper> desktopWallpapers = new List<DesktopWallpaper> { };
            foreach (int id in desktopWallpaperIds)
            {
                desktopWallpapers.Add(_context.DesktopWallpapers.Where(d => d.DesktopWallpaperId == id).First());
            }
            Transaction transaction = new Transaction
            {
                TotalPrice = totalPrice
            };
            _context.Transactions.Add(transaction);
            string currentUserId = User.Identity.GetUserId();
            foreach (var d in desktopWallpapers)
            {
                TransactionDetails transactionDetails = new TransactionDetails
                {
                    Transaction = transaction,
                    ApplicationUser = _context.Users.FirstOrDefault(u => u.Id == currentUserId),
                    DesktopWallpaper = d
                };
                _context.TransactionDetails.Add(transactionDetails);
            }
            _context.SaveChanges();
            CartGoToPayViewModel cartGoToPayViewModel = new CartGoToPayViewModel
            {
                DesktopWallpapers = desktopWallpapers,
                TotalPrice = totalPrice,
                TransactionId = transaction.TransactionId
            };
            return View(cartGoToPayViewModel);
        }

        //get method也可以进行model binding
        public ActionResult SessionWithPDT(string tx)
        {
            PDTHttpClient pDTHttpClient = new PDTHttpClient();
            pDTHttpClient.SessionWithPDT(tx);
            Match match = Regex.Match(pDTHttpClient.responseData, @"invoice=(\S)+");
            if(match.Success)
            {
                string originalValue = match.Groups[1].Value;
                int FinalValue = int.Parse(originalValue);
                _context.Transactions.Where(t => t.TransactionId == FinalValue).First().Completeness = true;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Content("Can't find any match.", "text/plain");
            }
        }

        public ActionResult Delete(int id)
        {
            List<int> desktopWallpaperIds = (List<int>)Session["desktopWallpaperIds"];
            int index = desktopWallpaperIds.FindIndex(d => d == id);
            if(index == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                desktopWallpaperIds.RemoveAt(index);
            }
            Session["desktopWallpaperIds"] = desktopWallpaperIds;
            return RedirectToAction("Index");
        }

        //// GET: Cart/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Cart/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Add(int id)
        {
            //避免服务器对错误信息添油加醋，比如返回一个页面
            Response.TrySkipIisCustomErrors = true;
            try
            {
                // TODO: Add insert logic here
                // Session 可以使用 List
                List<int> desktopWallpaperIds = (List<int>)Session["desktopWallpaperIds"];
                if (desktopWallpaperIds == null)
                {
                    //注意不用写括号
                    desktopWallpaperIds = new List<int> { };
                }
                if (!_context.DesktopWallpapers.Any(d => d.DesktopWallpaperId == id) || desktopWallpaperIds.IndexOf(id) != -1)
                {
                    // 不管用户发送了一个不存在的商品，还是已经加入购物车，都做同样的处理
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    desktopWallpaperIds.Add(id);
                    Session["desktopWallpaperIds"] = desktopWallpaperIds;
                    return Json("Succeed in adding.");
                }
            }
            catch(Exception exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        //public ActionResult Confirm(string orderId)
        //{

        //}

        //    // GET: Cart/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Cart/Edit/5
        //    [HttpPost]
        //    public ActionResult Edit(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add update logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: Cart/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: Cart/Delete/5
        //    [HttpPost]
        //    public ActionResult Delete(int id, FormCollection collection)
        //    {
        //        try
        //        {
        //            // TODO: Add delete logic here

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
