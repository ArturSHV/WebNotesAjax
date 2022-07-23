using System.ComponentModel.DataAnnotations;

namespace WebTatIntek.Controllers
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Введите Логин")]
        public string Login { get; set; } = null!;


        [Required(ErrorMessage = "Введите Пароль")]
        public string Password { get; set; } = null!;

    }
}
