using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp1.Models;

namespace WpfApp1
{
    class PartnerViewModel
    {
        public string TypePartner { get; set; }
        public string Name { get; set; }

        public string Director { get; set; }

        public string Phone { get; set; }

        public int? Rating { get; set; }
        public decimal Sales { get; set; }
        public int DiscountPers { get; set; }
        public string DiscountInf { get; set; }

        public PartnerViewModel(Partner p,decimal sales, int discount)
        {
            TypePartner = p.TypePartner;
            Name = p.Name;
            Director = p.Director;
            Phone = p.Phone;
            Rating = p.Rating;
            Sales = sales;
            DiscountPers = discount;
            DiscountInf = $"{discount}%";


        }
    }
}
