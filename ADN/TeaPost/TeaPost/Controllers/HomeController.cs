using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeaPost.Models;
using TeaPost.BAL;
using System.Data.SqlClient;
using System.Data;
using TeaPost.DAL.SEC_User;

namespace TeaPost.Controllers
{
    [CheckAccess]
    public class HomeController : Controller
    {
        SEC_UserDAL dalUser = new SEC_UserDAL();
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            string conn_String = this.Configuration.GetConnectionString("MyConnectionString");
            SqlConnection conn = new SqlConnection(conn_String);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_RecordCount";

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            return View(dt);
        }

        public IActionResult Profile(int UserID)
        {
            DataTable dt = dalUser.dbo_PR_SELECT_BY_PK_MST_USER(UserID);
            return View(dt);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}