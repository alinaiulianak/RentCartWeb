using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCartWeb.Core.Models;
using RentCartWeb.DataAccess.InMemory;
using RentCartWeb.Core.Contracts;
using System.Configuration;
using System.Data.SqlClient;
using RentCartWeb.DataAccessSQL;

namespace RentCartWeb.WebUI.Controllers
{
    public class CustomerManageController : Controller
    {
        IRepository<Customers> context;

        public CustomerManageController(IRepository<Customers> customerContext)
        {
            context = customerContext;
        }
        // GET: CustomerManage
        public ActionResult Index(Customers c)
        {
      
            List<Customers> customer = context.Collection().ToList();
            return View(customer);
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
                customerToEdit.ZIPCode = customer.ZIPCode;

                context.Commit();
                return RedirectToAction("Index");
                
            }
        }
    }
}