using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Yucca.ViewModels.Identity
{
    public class RoleViewModel
    {
        // Change the Id type from string to int:
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "وظیفه و نقش")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        // Change the Id Type from string to int:
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

}