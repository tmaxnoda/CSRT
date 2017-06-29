using System.ComponentModel.DataAnnotations;

namespace CSRT.AccountViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}