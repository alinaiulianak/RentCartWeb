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
    public class ReservationsManageController : Controller
    {


        IReservationRepository context;
        IRepository<Customers> customer;
        ICarRepository car;

        public ReservationsManageController(IReservationRepository contextR,IRepository<Customers> customerContext, ICarRepository carContext)
        {
            context = contextR;
            customer = customerContext;
            car = carContext;
        }
        // GET: ReservationsManage
        public ActionResult Index()
        {
            List<Reservations> reservations= context.Collection().ToList();
            return View(reservations);
        }
        public ActionResult Create()
        {
            Reservations rent = new Reservations();
            return View(rent);
        }

        [HttpPost]
        public ActionResult Create(Reservations rent, int CarID, int Id)
        {
            
          
                if ((!ModelState.IsValid) )
                {

                    return View(rent);
                }
                else
                {
                if (car.Find(CarID) == null)
                {
                    return HttpNotFound("Car Id not exist in database!");
                }
                else if (customer.Find(Id) == null)
                {
                    return HttpNotFound("Customer Id not exist in database!");
                }
                else
                {
                    context.Insert(rent);
                    context.Commit();

                    return RedirectToAction("Index");
                }

                }
            }
           

      
        //public Cars Find(int CarID)
        //{
        //    Cars c = car.Find(p => p.CarID == CarID);

        //    if (c != null)
        //    {
        //        return c;
        //    }
        //    else
        //    {
        //        throw new Exception("Customer not found!");
        //    }
        //}

        public ActionResult Edit(int CarID, int Id, DateTime StartDate)
        {
            //Reservations rent = context.Find(p => (p.CarID == IdCar) && (p.Id == Id) && (p.StartDate == dt));

            Reservations rent = context.Find(CarID, Id, StartDate);
            if (rent == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(rent);
            }
        }

        [HttpPost]
        public ActionResult Edit(Reservations rent, int CarID, int Id, DateTime StartDate)
        {
            //Reservations rentToEdit = context.Find(p => (p.CarID == IdCar) && (p.Id == Id) && (p.StartDate == dt));
            Reservations rentToEdit = context.Find(CarID, Id, StartDate);

            if (rentToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(rent);
                }



                rentToEdit.CarID = rent.CarID;
                rentToEdit.Id = rent.Id;
                rentToEdit.StartDate = rent.StartDate;
                rentToEdit.EndDate= rent.EndDate;
                rentToEdit.Location = rent.Location;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}