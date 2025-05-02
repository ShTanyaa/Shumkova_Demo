using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Partners.xaml
    /// </summary>
    public partial class Partners : Page
    {
        public Partners()
        {
            InitializeComponent();
            LoadPartners();

        }

        private void LoadPartners()
        {
            using (var db = new MasterPolShumkovaContext())
            {
                // Загружаем партнеров с их продажами
                var partnersData = db.Partners
                    .Include(p => p.PartnerProducts)
                    .Select(p => new
                    {
                        Partner = p,
                        TotalSales = p.PartnerProducts.Sum(pp => pp.Product.MinCost * pp.Count)
                    })
                    .ToList();

                // Преобразуем в ViewModel с расчетом скидки
                var partners = partnersData.Select(p =>
                {
                    var discount = CalculateDiscount((decimal)p.TotalSales);
                    return new PartnerViewModel(p.Partner, (decimal)p.TotalSales, (int)discount);
                }).ToList();

                PartnersList.ItemsSource = partners;
            }
        }

        private decimal CalculateDiscount(decimal totalSales)
        {
            if (totalSales < 10000) return 0;
            if (totalSales < 50000) return 5;
            if (totalSales < 300000) return 10;
            return 15;
        }
    }
}
