using System.ComponentModel.DataAnnotations;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
    public class ConfirmMailModel
    {
        [Required(ErrorMessage ="Boş bırakılamaz")]
        public int ConfirmCode { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        public string Email { get; set; }
    }
}
