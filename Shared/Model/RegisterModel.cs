using System.ComponentModel.DataAnnotations;
using Shared.Model.DTO;

namespace Shared.Model
{
    public class RegisterModel
    {
        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
        [Required]
        [StringLength(64)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(64)]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        public static User ConvertToUser(RegisterModel model)
        {
            return new User
            {
                Email = model.Email,
                Login = model.Login,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Password = model.Password
            };
        }
    }
}
