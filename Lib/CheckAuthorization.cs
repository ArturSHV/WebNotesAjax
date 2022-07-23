using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WebTatIntek.Controllers
{
    /// <summary>
    /// Класс проверки куки
    /// </summary>
    public class CheckAuthorization
    {
        /// <summary>
        /// проверка наличия информации в куки
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="controller">текущий контроллер</param>
        public static void Check(HttpContext httpContext, Controller controller)
        {
            if (httpContext.Session.Keys.Contains("Login"))
            {
                if (!String.IsNullOrEmpty(httpContext.Session.GetString("Login")))
                {
                    controller.ViewData["Login"] = httpContext.Session.GetString("Login");
                    
                }

            }
        }
    }
}
