using System.ComponentModel.DataAnnotations;

namespace WebApp2.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remeber")]
        public bool RememberMe { get; set; }
    }
}
