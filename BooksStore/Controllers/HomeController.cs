﻿using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        //конекст базы данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            //получаем из БД все объекты книг
            IEnumerable<Book> books = db.Books;
            //передаём все объекты в динамическое свойство
            ViewBag.Books = books;
            
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            //EF сохраняем изменения в базе данных
            db.SaveChanges();
            return $"Спасибо {purchase.Person} за покупку";
        }
    }
}