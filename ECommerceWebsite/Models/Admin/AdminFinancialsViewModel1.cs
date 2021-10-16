using System.Linq;
using System.Collections.Generic;

namespace ECommerceWebsite.Models.Admin
{
    public class AdminFinancialsViewModel
    {
        public string Month => DailyTakings.FirstOrDefault() == null ? string.Empty : DailyTakings.FirstOrDefault().Date.ToString("MMMM");
        public int MonthylTotal { get; set; }
        public List<AdminFinancialsDetailsItemViewModel> DailyTakings { get; set; }
    }
}