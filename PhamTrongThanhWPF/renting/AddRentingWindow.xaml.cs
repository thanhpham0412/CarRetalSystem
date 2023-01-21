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
    /// Interaction logic for AddRentingWindow.xaml
    /// </summary>
    public partial class AddRentingWindow : Window
    {
        private const string FIELD_REQUIRED_ERROR = "This field is required";
        private const string WROMG_FORMAT_ERROR = "Invalid input format";

        public AddRentingWindow()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            var cars = new CarRepository().getData();
            var customers = new CustomerRepository().getData();
            cbCar.ItemsSource = cars;
            cbCustomer.ItemsSource = customers;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateData())
            {
                var carRental = new CarRental()
                {
                    CustomerId = cbCustomer.SelectedValue.ToString(),
                    CarId = cbCar.SelectedValue.ToString(),
                    PickupDate = (DateTime)dpPickupDate.SelectedDate,
                    ReturnDate = (DateTime)dpReturnDate.SelectedDate,
                    RentPrice = new CarRepository().getById(cbCar.SelectedValue.ToString()).RentPrice
                };
                new CarRentalRepository().insertData(carRental);
                MessageBox.Show("Insert successfully.");
                this.Close();
            }
        }

        private Boolean validateData()
        {
            Boolean isValid = true;

            if (cbCustomer.SelectedValue == null)
            {
                isValid = false;
                lblCustomerIdError.Content = FIELD_REQUIRED_ERROR;
                lblCustomerIdError.Visibility = Visibility.Visible;
            }
            else
            {
                lblCustomerIdError.Visibility = Visibility.Collapsed;
            }

            DateTime? pickupDate = dpPickupDate.SelectedDate;
            if (pickupDate == null)
            {
                isValid = false;
                lblPickupDateError.Content = FIELD_REQUIRED_ERROR;
                lblPickupDateError.Visibility = Visibility.Visible;
            } else
            {
                lblPickupDateError.Visibility = Visibility.Collapsed;
            }

            DateTime? returnDate = dpReturnDate.SelectedDate;
            if (returnDate == null)
            {
                isValid = false;
                lblReturnDateError.Content = FIELD_REQUIRED_ERROR;
                lblReturnDateError.Visibility = Visibility.Visible;
            } else if (DateTime.Compare((DateTime)pickupDate, (DateTime)returnDate) >= 0)
            {
                isValid = false;
                lblReturnDateError.Content = "Pickup date must be before return date.";
                lblReturnDateError.Visibility = Visibility.Visible;
            } else
            {
                lblReturnDateError.Visibility = Visibility.Collapsed;
            }


            if (cbCar.SelectedValue == null)
            {
                isValid = false;
                lblCarIdError.Content = FIELD_REQUIRED_ERROR;
                lblCarIdError.Visibility = Visibility.Visible;
            }
            else
            {
                lblCarIdError.Visibility = Visibility.Collapsed;
            }

            return isValid;
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? pickupDate = dpPickupDate.SelectedDate;
            DateTime? returnDate = dpReturnDate.SelectedDate;
            if (pickupDate != null && returnDate != null 
                && DateTime.Compare((DateTime)pickupDate, (DateTime)returnDate) < 0)
            {
                lblReturnDateError.Visibility = Visibility.Collapsed;
                var cars = new CarRepository().getCarAvailableByDate((DateTime)pickupDate, (DateTime)returnDate);
                cbCar.ItemsSource = cars;
            } else
            {
                lblReturnDateError.Content = "Pickup date must be before return date.";
                lblReturnDateError.Visibility = Visibility.Visible;
                cbCar.ItemsSource = null;
            }

        }

    }
}
