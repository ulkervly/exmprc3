using System.ComponentModel.DataAnnotations;

namespace Hook.MVC.Areas.manage.ViewModel
{
    public class AdminViewModel
    {
        [Required]
        [MaxLength(100)]
        public string UserName {  get; set; }
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
