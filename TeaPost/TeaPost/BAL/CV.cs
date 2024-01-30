namespace TeaPost.BAL
{
    public class CV
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        static CV()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
        }

        public static string? UserName()
        {
            string str = _HttpContextAccessor.HttpContext.Session.GetString("UserName");
            return str;
        }

        public static string FirstName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("FirstName");
        }
    }
}