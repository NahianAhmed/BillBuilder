using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CURD.Models;

namespace CURD.Controllers
{
    public class HomeController : Controller
    {
        MyContext myContext;
        public HomeController(MyContext mycon)
        {
          
            myContext = mycon;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult AddUser()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(UserModel data)
        {
            if (ModelState.IsValid)
            {
                data.name = Request.Form["name"];
                data.email = Request.Form["email"];
                myContext.UserModels.Add(data);
                myContext.SaveChanges();
                return RedirectToAction("UserList");
            }
            return View(data);
        }

        public IActionResult Bill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Bill(UserBill data)
        {
            if (ModelState.IsValid)
            {
                myContext.UserBills.Add(data);
                myContext.SaveChanges();
                return RedirectToAction("BillList");

            }
            return View(data);
        }

        public IActionResult BillList()
        {
            return View(myContext.UserBills.ToList());
        }

        public IActionResult UserList()
        {
            return View(myContext.UserModels.ToList());
        }

        

        public IActionResult Editbill(int id)
        {
            var data = myContext.UserBills.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Editbill(UserBill data)
        {
            if (ModelState.IsValid)
            {
                var updata = myContext.UserBills.Where(x => x.id == data.id).FirstOrDefault();
                updata.bill = data.bill;
                updata.userID = data.userID;
                myContext.SaveChanges();
                return RedirectToAction("BillList");


            }
            
            return View(data);
        }

        public IActionResult DetailsBill(int id)
        {
            var data = myContext.UserBills.Where(x => x.id == id).FirstOrDefault();
            return View(data);

        }

        public IActionResult DeleteBill(int id)
        {
            var data = myContext.UserBills.Where(x => x.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult DeleteBill(UserBill billdata)
        {
            var data = myContext.UserBills.Where(x => x.id == billdata.id).FirstOrDefault();
            myContext.UserBills.Remove(data);
            myContext.SaveChanges();
            return RedirectToAction("BillList");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
