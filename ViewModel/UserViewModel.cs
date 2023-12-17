using System.ComponentModel.DataAnnotations;

namespace blogCSharp.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display (Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
