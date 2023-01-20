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

namespace PhamTrongThanhWPF.customer
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private const string FIELD_REQUIRED_ERROR = "This field is required";
        private const string WROMG_FORMAT_ERROR = "Invalid input format";

        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validateData())
            {
                var customer = new Customer()
                {
                    CustomerId = txtCustomerId.Text,
                    CustomerName = txtCustomerName.Text,
                    CustomerEmail = txtEmail.Text,
                    CustomerPassword = txtPassword.Text,
                    IdentityCard = txtIdentityCard.Text,
                    LicenceDate = dpLicenceDate.SelectedDate,
                    LicenceNumber = txtLicenceNumber.Text,
                    Mobile = txtMobile.Text
                };
                new CustomerRepository().insertData(customer);
                MessageBox.Show("Insert successfully");
                this.Close();
            }
        }

        private Boolean validateData()
        {
            Boolean isValid = true;
            if (txtCustomerId.Text.Trim() == "")
            {
                isValid = false;
                lblCustomerIdError.Content = FIELD_REQUIRED_ERROR;
                lblCustomerIdError.Visibility = Visibility.Visible;
            } else if (new CustomerRepository().existById(txtCustomerId.Text))
            {
                isValid = false;
                lblCustomerIdError.Content = "Id already exists.";
                lblCustomerIdError.Visibility = Visibility.Visible;
            }
            else
            {
                lblCustomerIdError.Visibility = Visibility.Collapsed;
            }

            if (txtCustomerName.Text.Trim() == "")
            {
                isValid = false;
                lblCustomerNameError.Content = FIELD_REQUIRED_ERROR;
                lblCustomerNameError.Visibility = Visibility.Visible;
            }
            else
            {
                lblCustomerNameError.Visibility = Visibility.Collapsed;
            }

            if (txtMobile.Text.Trim() == "")
            {
                isValid = false;
                lblMobileError.Content = FIELD_REQUIRED_ERROR;
                lblMobileError.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    int year = Convert.ToInt32(txtMobile.Text);
                    lblMobileError.Visibility = Visibility.Collapsed;
                }
                catch (FormatException e)
                {
                    isValid = false;
                    lblMobileError.Content = WROMG_FORMAT_ERROR;
                    lblMobileError.Visibility = Visibility.Visible;
                }
            }

            if (txtEmail.Text.Trim() == "")
            {
                isValid = false;
                lblEmailError.Content = FIELD_REQUIRED_ERROR;
                lblEmailError.Visibility = Visibility.Visible;
            }
            else
            {
                lblEmailError.Visibility = Visibility.Collapsed;
            }

            if (txtPassword.Text.Trim() == "")
            {
                isValid = false;
                lblPasswordError.Content = FIELD_REQUIRED_ERROR;
                lblPasswordError.Visibility = Visibility.Visible;
            }
            else
            {
                lblPasswordError.Visibility = Visibility.Collapsed;
            }

            if (txtIdentityCard.Text.Trim() == "")
            {
                isValid = false;
                lblIdentityCardError.Content = FIELD_REQUIRED_ERROR;
                lblIdentityCardError.Visibility = Visibility.Visible;
            }
            else
            {
                lblIdentityCardError.Visibility = Visibility.Collapsed;
            }

            if (txtLicenceNumber.Text.Trim() == "")
            {
                isValid = false;
                lblLicenceNumberError.Content = FIELD_REQUIRED_ERROR;
                lblLicenceNumberError.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    int lincenceNumber = Convert.ToInt32(txtMobile.Text);
                    lblLicenceNumberError.Visibility = Visibility.Collapsed;
                }
                catch (FormatException e)
                {
                    isValid = false;
                    lblLicenceNumberError.Content = WROMG_FORMAT_ERROR;
                    lblLicenceNumberError.Visibility = Visibility.Visible;
                }
            }

            DateTime? licenceDate = dpLicenceDate.SelectedDate;
            if (licenceDate == null)
            {
                isValid = false;
                lblLicenceDateError.Content = FIELD_REQUIRED_ERROR;
                lblLicenceDateError.Visibility = Visibility.Visible;
            }
            else if (DateTime.Compare((DateTime)licenceDate, DateTime.Now) > 0)
            {
                isValid = false;
                lblLicenceDateError.Content = "Import date can be after current date.";
                lblLicenceDateError.Visibility = Visibility.Visible;
            }
            else
            {
                lblLicenceDateError.Visibility = Visibility.Collapsed;
            }

            return isValid;
        }
    }
}
