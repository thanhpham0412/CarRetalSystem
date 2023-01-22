using System;
using System.Collections.Generic;
//using System.Linq;
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
using System.Collections;
using System.Linq;

namespace PhamTrongThanhWPF.renting
{
    /// <summary>
    /// Interaction logic for ReportStatisticWindow.xaml
    /// </summary>
    public partial class ReportStatisticWindow : Window
    {
        private DateTime? pickupDate;
        private DateTime? returnDate;

        class ReportStatistic
        {
            public string? CarId { get; set; }
            public int RentCount { get; set; }
            public decimal SalesRevenue { get; set; }
        }

        public ReportStatisticWindow()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            var startDate = (DateTime)pickupDate;
            var endDate = (DateTime)returnDate;

            var carRepo = new CarRepository();
            var carRentalRepo = new CarRentalRepository();

            var cars = carRepo.getData();
            var carRentals = carRentalRepo.getData();

            var reports = from carRental in carRentals
                          where carRental.PickupDate >= startDate && carRental.PickupDate <= endDate
                          group carRental by carRental.CarId into grouped
                          select new ReportStatistic()
                          {
                              CarId = grouped.Key,
                              RentCount = grouped.Count(),
                              SalesRevenue = (decimal)grouped.Sum(item => item.RentPrice)
                          };

            List<ReportStatistic> reportList = reports.ToList();
            reportList.OrderByDescending(r => r.SalesRevenue);

            for (var i = 0; i < reportList.Count; i++)
            {
                var carName = cars.Where(c => c.CarId == reportList[i].CarId).First().CarName;
                reportList[i].CarId = carName;
            }

            dgReport.ItemsSource = reportList;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dpPickupDate.SelectedDate == null || dpReturnDate.SelectedDate == null)
            {
                lblReturnDateError.Content = "Input required fields.";
                lblReturnDateError.Visibility = Visibility.Visible;
            }
            else
            {
                pickupDate = dpPickupDate.SelectedDate;
                returnDate = dpReturnDate.SelectedDate;
                if (DateTime.Compare((DateTime)pickupDate, (DateTime)returnDate) >= 0)
                {
                    lblReturnDateError.Content = "Pickup date must be before return date.";
                    lblReturnDateError.Visibility = Visibility.Visible;
                }
                else
                {
                    loadData();
                    lblReturnDateError.Visibility = Visibility.Collapsed;
                }

            }
        }
    }
}
