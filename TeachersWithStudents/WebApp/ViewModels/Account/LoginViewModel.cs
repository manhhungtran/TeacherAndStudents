using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamatovat")]
        public bool RememberMe { get; set; }
    }
}
