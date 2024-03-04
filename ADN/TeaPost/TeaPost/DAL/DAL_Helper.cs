namespace TeaPost.DAL
{
    public class DAL_Helper
    {
        #region Database Connection String

        public static string MyConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");

        #endregion
    }
}
