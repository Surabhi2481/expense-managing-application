using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagingSystem.Models;

namespace ExpenseManagingSystem.Controllers
{
    public class MainController : Controller
    {
        // GET: Main

        private DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.mainClasss.ToList());
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Register");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(mainClass user)
        {
            if (ModelState.IsValid)
            {
                db.mainClasss.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occured!");
            }
            return View(user);

        }
        public ActionResult addExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("expenseList");
            }
            return View();
        }

        public ActionResult expenseAdded()
        {
            return View();
        }

        public ActionResult expenseList()
        {
            return View(db.Expenses.ToList());
        }
    }
}