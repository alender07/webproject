using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            var books = db.Books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase); //добавляем инфу о покупке в БД
            db.SaveChanges(); //сохраняем в БД все изменения
            return "Спасибо за покупку, "+ purchase.Person + "!";
        }

        [HttpGet] //ERROR HERE
        public ActionResult Delet(int id)
        {
            //if (id!=null)
            ViewBag.BookId = id;
            return View();
        }
        
        [HttpPost]
        public string Delet(Purchase purchase ) //удаление из БД
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Remove(purchase);
            db.SaveChanges();
            return "Книга удалена!";
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
    }
}