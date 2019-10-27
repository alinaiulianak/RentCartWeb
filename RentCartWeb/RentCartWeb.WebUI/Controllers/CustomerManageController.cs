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
        CustomersRepository context;

        public CustomerManageController()
        {
            context = new CustomersRepository();
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

        public ActionResult Edit(int CostumerID)
        {
            Customers customer = context.Find(CostumerID);
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
        public ActionResult Edit(Customers customer, int CostumerID)
        {
            Customers customerToEdit = context.Find(CostumerID);
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