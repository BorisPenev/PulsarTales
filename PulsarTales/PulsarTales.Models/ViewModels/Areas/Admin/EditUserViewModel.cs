using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PulsarTales.Models.Entities;
using System.Data;

namespace PulsarTales.Models.ViewModels.Areas.Admin
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

        public List<Role> Roles { get; set; }
    }
}
