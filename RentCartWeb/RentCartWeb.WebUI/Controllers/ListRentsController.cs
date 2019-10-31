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
    public class ListRentsController : Controller
    {
        // GET: ListRents
        public ActionResult Index(DisplayRents dr)
        {
            SqlConnection sqlconn;

            SqlDataReader sdr;
            sqlconn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlconn.Open();
            sdr = new SqlCommand("select CarID,Id,StartDate,EndDate,Location  from Reservations", sqlconn).ExecuteReader();

            List<DisplayRents> objmodel = new List<DisplayRents>();
            //List<Customers> customerList = context.Collection().ToList();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new DisplayRents();
                    details.CarID = sdr["CarID"].ToString();
                    details.Id = sdr["Id"].ToString();
                    details.StartDate = sdr["StartDate"].ToString();
                    details.EndDate = sdr["EndDate"].ToString();
                    details.Location = sdr["Location"].ToString();
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