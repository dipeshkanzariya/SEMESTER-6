using Microsoft.AspNetCore.Mvc;

namespace API_Demo.DAL
{
    public class DAL_Helpers:Controller
    {
        public static string ConnString = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            .Build().GetConnectionString("MyConnectionStirng");
    }
}
