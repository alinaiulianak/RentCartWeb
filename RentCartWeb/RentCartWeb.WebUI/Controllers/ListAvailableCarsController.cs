using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCartWeb.Core.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RentCartWeb.WebUI.Controllers
{
    public class ListAvailableCarsController : Controller
    {
        // GET: ListAvailableCars
        public ActionResult Index(DisplayAvailableCars dr)
        {
            SqlConnection sqlconn;
            SqlDataReader sdr;
            sqlconn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlconn.Open();
            sdr = new SqlCommand("select CarID, Plate, Model,Manufacturer,LocationCar from [dbo].[Cars]", sqlconn).ExecuteReader();

            List<DisplayAvailableCars> objmodel = new List<DisplayAvailableCars>();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new DisplayAvailableCars();
                    details.CarID = sdr["CarID"].ToString();
                    details.Plate = sdr["Plate"].ToString();
                    details.Model = sdr["Model"].ToString();
                    details.Manufacturer = sdr["Manufacturer"].ToString();
                    details.LocationCar = sdr["LocationCar"].ToString();
                    objmodel.Add(details);
                }

                dr.userinfo = objmodel;
                ///*sqlconn*/.Close();
                sqlconn.Close();

            }
            return View("Index", dr);

        }
    }
}
