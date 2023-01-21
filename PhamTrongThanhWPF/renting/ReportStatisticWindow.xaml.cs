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
using System.Windows.Shapes;
using Repo;
using BusinessObject;

namespace PhamTrongThanhWPF.renting
{
    /// <summary>
    /// Interaction logic for ReportStatisticWindow.xaml
    /// </summary>
    public partial class ReportStatisticWindow : Window
    {
        class ReportStatistic
        {
            public string CarName { get; set; }
            public int RentingDate { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public ReportStatisticWindow()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            var startDate = (DateTime)dpPickupDate.SelectedDate;
            var endDate = (DateTime)dpReturnDate.SelectedDate;
            var repo = new CarRepository();
            var cars = repo.getData();
            var statictis = new List<ReportStatistic>();
            foreach (var car in cars)
            {
                int days = repo.calculateRentingDateInPeriod(car.CarId, startDate, endDate);
                statictis.Add(new ReportStatistic()
                {
                    CarName = car.CarName,
                    RentingDate = days,
                    TotalPrice = (decimal)car.RentPrice * days
                });
            }
            statictis = statictis.OrderByDescending(x => x.TotalPrice).ToList();
            dgReport.ItemsSource = statictis;

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpPickupDate.SelectedDate == null || dpReturnDate.SelectedDate == null)
            {
                lblReturnDateError.Content = "Input required fields.";
                lblReturnDateError.Visibility = Visibility.Visible;
            } else
            {
                DateTime? pickupDate = dpPickupDate.SelectedDate;
                DateTime? returnDate = dpReturnDate.SelectedDate;
                if (DateTime.Compare((DateTime)pickupDate, (DateTime)returnDate) >= 0)
                {
                    lblReturnDateError.Content = "Pickup date must be before return date.";
                    lblReturnDateError.Visibility = Visibility.Visible;
                } else
                {
                    loadData();
                    lblReturnDateError.Visibility = Visibility.Collapsed;
                }

            }
        }
    }
}
