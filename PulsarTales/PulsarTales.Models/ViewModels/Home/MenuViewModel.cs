using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsarTales.Models.ViewModels.Home
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            this.OriginalTales = new List<TaleViewModel>();
            this.TranslatedTales = new List<TaleViewModel>();
            this.OtherTales = new List<TaleViewModel>();
        }
        public List<TaleViewModel> TranslatedTales { get; set; }
        public List<TaleViewModel> OriginalTales { get; set; }
        public List<TaleViewModel> OtherTales { get; set; }
    }
}
