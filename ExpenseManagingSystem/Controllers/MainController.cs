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

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(db.mainClasss.ToList());
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Home");
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(mainClass real)
        {

            using (DataContext db = new DataContext())
            {
                mainClass obj = db.mainClasss.FirstOrDefault(user => user.userId == real.userId && user.password == real.password);
                if (obj == null)
                    return View("vendorRejected");


                if (obj != null)
                {
                    Session["userid"] = obj.userId;
                    return RedirectToAction("userExpenseList"); ;
                }
            }
            return View(real);
        }

        public ActionResult userExpenseList()
        {
            

            string id = Session["userid"].ToString();
            var a = (from d in db.Expenses
                      where d.userId == id
                      select d).ToList();
            return View(a);
        }


    }
}