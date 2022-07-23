using System.ComponentModel.DataAnnotations;

namespace WebTatIntek.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите Имя")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Введите Фамилию")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Введите логин")]
        [StringLength(20, ErrorMessage = "Поле Логин должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string Login { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(20, ErrorMessage = "Поле Пароль должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

    }

    
}
