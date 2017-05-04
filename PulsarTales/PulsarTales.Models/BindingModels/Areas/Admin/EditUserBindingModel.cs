using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PulsarTales.Models.Entities;
using System.Data;

namespace PulsarTales.Models.BindingModels.Areas.Admin
{
    public class EditUserBindingModel
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

        public List<Rule> Roles { get; set; }
    }
}
