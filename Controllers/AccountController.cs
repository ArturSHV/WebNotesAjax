using Microsoft.AspNetCore.Mvc;
using WebTatIntek.Entity;
using WebTatIntek.Models;

namespace WebTatIntek.Controllers
{
    public class AccountController : Controller
    {

        /// <summary>
        /// окно авторизации
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            CheckAuthorization.Check(HttpContext, this);

            if (ViewData["Login"] != null)
                return Redirect("/");

            ViewData["Title"] = "Авторизация";
            return View();
        }


        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); //очистка куки

            return Redirect("/");
        }

        
        /// <summary>
        /// окно регистрации
        /// </summary>
        /// <returns></returns>
        public IActionResult Registration()
        {
            CheckAuthorization.Check(HttpContext, this);

            if (ViewData["Login"] != null)
                return Redirect("/");

            ViewData["Title"] = "Регистрация";

            return View();
        }


        /// <summary>
        /// окно успешной регистрации
        /// </summary>
        /// <returns></returns>
        public IActionResult Success()
        {
            CheckAuthorization.Check(HttpContext, this);

            if (ViewData["Login"] != null)
                return Redirect("/");

            ViewData["Title"] = "Успешная регистрация";

            return View();
        }


        /// <summary>
        /// получение данных при авторизации
        /// </summary>
        /// <param name="context"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromServices] DataContext context, LoginViewModel loginViewModel) 
        {
            ViewData["Title"] = "Авторизация";

            if (!ModelState.IsValid) //если модель невалидная
            {
                return View(loginViewModel);
            }
            else
            {
                var a = context.Users.FirstOrDefault(i=>(i.Login== loginViewModel.Login && i.Password == loginViewModel.Password));
                
                if (a == null)
                {
                    ViewBag.Message = "Пара логин-пароль не существует!";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("Login", loginViewModel.Login); //установка куки
                    return Redirect("/");
                }
                
            }

        }


        /// <summary>
        /// получение данных при регистрации
        /// </summary>
        /// <param name="context"></param>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Registration([FromServices] DataContext context,RegisterViewModel registerViewModel)
        {
            ViewData["Title"] = "Регистрация";

            if (ModelState.IsValid)
            {
                var a = context.Users.FirstOrDefault(l => l.Login == registerViewModel.Login);

                if (a == null)
                {
                    context.Users.Add(new Users
                    {
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        Login = registerViewModel.Login,
                        Password = registerViewModel.Password
                    });

                    context.SaveChanges();
                    return Redirect("/Account/Success");
                }
                else
                {
                    ViewBag.Message = "Такой логин уже зарегистрирован!";
                    return View();
                }
            }
            else
                return View(registerViewModel);
        }
    }
}
