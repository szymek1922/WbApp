using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WbApp.Models;

namespace WbApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        SqlDataReader dr = null;
        List<Log> userLogs = new List<Log>();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            fetchData();
            return View(userLogs);
        }
        private void fetchData()
        {
            var user = User.Identity.GetUserName();
            var query = "Declare @User NVARCHAR(128) = (select Id from AspNetUsers where Email = '" + user + "') " + "select [Date], [Action] from UserLogs where UserID = @User";
            

            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            dr =sqlCommand.ExecuteReader();
            while(dr.Read())
            {
                userLogs.Add(new Log() { Date = dr["Date"].ToString(), Action = dr["Action"].ToString() });
            }
            sqlConnection.Close();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}