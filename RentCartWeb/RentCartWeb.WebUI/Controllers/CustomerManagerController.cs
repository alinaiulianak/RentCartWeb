using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.RentCartWeb.Core;
using System.RentCartWeb.DataAccess.InMemory;


namespace RentCartWeb.WebUI.Controllers
{
    public class CustomerManagerController : Controller
    {
        // GET: CustomerManager
        public ActionResult Index()
        {
            return View();
        }
    }
}