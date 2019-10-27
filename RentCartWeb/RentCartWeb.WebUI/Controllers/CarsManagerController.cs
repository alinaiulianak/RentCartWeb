using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCartWeb.Core.Models;
using RentCartWeb.DataAccess.InMemory;

namespace RentCartWeb.WebUI.Controllers
{
    public class CarsManagerController : Controller
    {
        InMemoryRepository<Cars> context;

        public CarsManagerController()
        {
            context = new InMemoryRepository<Cars>();
        }
        // GET: CustomerManage
        public ActionResult Index()
        {
            List<Cars> cars = context.Collection().ToList();
            return View(cars);
        }
        public ActionResult Create()
        {
            Cars car = new Cars();
            return View(car);
        }
        [HttpPost]
        public ActionResult Create(Cars car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            else
            {
                context.Insert(car);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //public ActionResult Edit(int Id)
        //{
        //    Cars car = context.Find(Id);
        //    if (car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        return View(car);
        //    }
        //}
        //[HttpPost]
        //public ActionResult Edit(Cars car, int Id)
        //{
        //    Customers carsToEdit = context.Find(Id);
        //    if (carsToEdit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(car);

        //        }

        //        carsToEdit.Plate = customer.Name;
        //        carsToEdit. = customer.BirthDate;
        //        carsToEdit.Location = customer.Location;

        //        context.Commit();
        //        return RedirectToAction("Index");

        //    }
        //}

    }
}