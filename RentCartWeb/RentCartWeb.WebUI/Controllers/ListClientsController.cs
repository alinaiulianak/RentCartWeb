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
    public class ListClientsController : Controller
    {
        // GET: User
        public ActionResult Index(DisplayClients dr)
        {

            //string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //string s1 = "select CostumerID, Name, BirthDate, ZIPCode from [dbo].[Customers]";
            //SqlCommand sqlcomm = new SqlCommand(s1);
            //sqlcomm.Connection = sqlconn;
            //sqlconn.Open();
            //SqlDataReader sdr = sqlcomm.ExecuteReader();
            SqlConnection sqlconn;
            
            SqlDataReader sdr;
            sqlconn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlconn.Open();
            sdr = new SqlCommand("select Id, Name, BirthDate, Location from dbo.Customers ", sqlconn).ExecuteReader();

            List<DisplayClients> objmodel = new List<DisplayClients>();
            //List<Customers> customerList = context.Collection().ToList();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new DisplayClients();
                    details.Id = sdr["Id"].ToString();
                    details.Name = sdr["Name"].ToString();
                    details.BirthDate = sdr["BirthDate"].ToString();
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