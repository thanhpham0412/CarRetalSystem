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

namespace PhamTrongThanhWPF.car
{
    /// <summary>
    /// Interaction logic for UpdateCarWindow.xaml
    /// </summary>
    public partial class UpdateCarWindow : Window
    {
        private const string FIELD_REQUIRED_ERROR = "This field is required";
        private const string WROMG_FORMAT_ERROR = "Invalid input format";

        public UpdateCarWindow(Car car)
        {
            InitializeComponent();
            loadData(car);
        }

        private void loadData(Car car)
        {
            CarProducerRepository carProducerRepository = new CarProducerRepository();
            var producers = carProducerRepository.getData();
            cbProducer.ItemsSource = producers;

            txtCarId.Text = car.CarId;
            txtCarName.Text = car.CarName;
            txtCarModelYear.Text = car.CarModelYear.ToString();
            txtColor.Text = car.Color;
            txtCapacity.Text = car.Capacity.ToString();
            txtDescription.Text = car.Description;
            txtRentPrice.Text = car.RentPrice.ToString();
            dpImportDate.SelectedDate = car.ImportDate;
            cbProducer.SelectedValue = car.ProducerId;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (validateData())
            {
                var car = new Car()
                {
                    CarId = txtCarId.Text,
                    CarName = txtCarName.Text,
                    CarModelYear = Convert.ToInt32(txtCarModelYear.Text),
                    Capacity = Convert.ToInt32(txtCapacity.Text),
                    Description = txtDescription.Text,
                    RentPrice = Convert.ToDecimal(txtRentPrice.Text),
                    ImportDate = dpImportDate.SelectedDate,
                    Color = txtColor.Text,
                    Status = 1,
                    ProducerId = cbProducer.SelectedValue.ToString()
                };
                var carRepo = new CarRepository();
                carRepo.updateData(car);
                MessageBox.Show("Update data successfully.");
                this.Close();
            }
        }

        private Boolean validateData()
        {
            Boolean isValid = true;
            
            if (txtCarName.Text.Trim() == "")
            {
                isValid = false;
                lblCarNameError.Content = FIELD_REQUIRED_ERROR;
                lblCarNameError.Visibility = Visibility.Visible;
            }
            else
            {
                lblCarNameError.Visibility = Visibility.Collapsed;
            }

            if (txtCarModelYear.Text.Trim() == "")
            {
                isValid = false;
                lblCarModelYearError.Content = FIELD_REQUIRED_ERROR;
                lblCarModelYearError.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    int year = Convert.ToInt32(txtCarModelYear.Text);
                    lblCarModelYearError.Visibility = Visibility.Collapsed;
                }
                catch (FormatException e)
                {
                    isValid = false;
                    lblCarModelYearError.Content = WROMG_FORMAT_ERROR;
                    lblCarModelYearError.Visibility = Visibility.Visible;
                }
            }

            if (txtColor.Text.Trim() == "")
            {
                isValid = false;
                lblColorError.Content = FIELD_REQUIRED_ERROR;
                lblColorError.Visibility = Visibility.Visible;
            }
            else
            {
                lblColorError.Visibility = Visibility.Collapsed;
            }

            if (txtCapacity.Text.Trim() == "")
            {
                isValid = false;
                lblCapacityError.Content = FIELD_REQUIRED_ERROR;
                lblCapacityError.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    int capacity = Convert.ToInt32(txtCapacity.Text);
                    lblCapacityError.Visibility = Visibility.Collapsed;
                }
                catch (FormatException e)
                {
                    isValid = false;
                    lblCapacityError.Content = WROMG_FORMAT_ERROR;
                    lblCapacityError.Visibility = Visibility.Visible;
                }
            }

            if (txtDescription.Text.Trim() == "")
            {
                isValid = false;
                lblDescriptionError.Content = FIELD_REQUIRED_ERROR;
                lblDescriptionError.Visibility = Visibility.Visible;
            }
            else
            {
                lblDescriptionError.Visibility = Visibility.Collapsed;
            }

            DateTime? importDate = dpImportDate.SelectedDate;
            if (importDate == null)
            {
                isValid = false;
                lblDatePickerError.Content = FIELD_REQUIRED_ERROR;
                lblDatePickerError.Visibility = Visibility.Visible;
            }
            else if (DateTime.Compare((DateTime)importDate, DateTime.Now) > 0)
            {
                isValid = false;
                lblDatePickerError.Content = "Import date can be after current date.";
                lblDatePickerError.Visibility = Visibility.Visible;
            }
            else
            {
                lblDatePickerError.Visibility = Visibility.Collapsed;
            }

            if (txtRentPrice.Text.Trim() == "")
            {
                isValid = false;
                lblRentPriceError.Content = FIELD_REQUIRED_ERROR;
                lblRentPriceError.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    Decimal rentPrice = Convert.ToDecimal(txtRentPrice.Text);
                    lblRentPriceError.Visibility = Visibility.Collapsed;
                }
                catch (FormatException e)
                {
                    isValid = false;
                    lblRentPriceError.Content = WROMG_FORMAT_ERROR;
                    lblRentPriceError.Visibility = Visibility.Visible;
                }
            }


            if (cbProducer.SelectedValue == null)
            {
                isValid = false;
                lblProducerError.Content = FIELD_REQUIRED_ERROR;
                lblProducerError.Visibility = Visibility.Visible;
            }
            else
            {
                lblProducerError.Visibility = Visibility.Collapsed;
            }
            
            return isValid;
        }
    }
}
