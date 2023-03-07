using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Shubham.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using PagedList.Mvc;
using PagedList;
using MVC_Shubham.Models;

namespace MVC_Shubham.Controllers
{
    public class HomeController : Controller
    {
        ServicesContext db = new ServicesContext();
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var products = db.prod.OrderBy(x => x.ProductName).ToPagedList(pageNumber, pageSize);
            return View(products);


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

        public ActionResult Create()
        {
           

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid==true)
            {
                db.prod.Add(p);
                int a=db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved..')</script>");
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Not Saved..')</script>");
                }

            }


            

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.prod.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);

        }


        [HttpPost]
        public ActionResult Edit(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
           int a= db.SaveChanges();

            if (a > 0)
            {
              //  ViewBag.UpdateMessage = ("<script>alert('Data Updated..')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Not Updated..')</script>");
            }


            return View();

        }


       
        public ActionResult Details(int id)
        {
            var row = db.prod.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);


        }

        public ActionResult Delete(int id)
        {
            var StudentIdrow = db.prod.Where(model => model.ProductId == id).FirstOrDefault();
            db.prod.Remove(StudentIdrow);
            db.SaveChanges();

            ViewBag.Message = "Record Deleted Succesfully";
            return RedirectToAction("index");

        }


       
            

             
        




    }
}