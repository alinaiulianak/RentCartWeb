using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCartWeb.Core.Models;
using RentCartWeb.DataAccess.InMemory;

namespace RentCartWeb.WebUI.Controllers
{
    public class CustomerManageController : Controller
    {
        InMemoryRepository<Customers> context;

        public CustomerManageController()
        {
            context = new InMemoryRepository<Customers>();
        }
        // GET: CustomerManage
        public ActionResult Index()
        {
            List<Customers> customers = context.Collection().ToList();
            return View(customers);
        }
        public ActionResult Create()
        {
            Customers customer = new Customers();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            else
            {
                context.Insert(customer);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int Id)
        {
            Customers customer = context.Find(Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
        [HttpPost]
        public ActionResult Edit(Customers customer, int Id)
        {
            Customers customerToEdit = context.Find(Id);
            if (customerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);

                }

                customerToEdit.Name = customer.Name;
                customerToEdit.BirthDate = customer.BirthDate;
                customerToEdit.Location = customer.Location;

                context.Commit();
                return RedirectToAction("Index");
                
            }
        }
    }
}