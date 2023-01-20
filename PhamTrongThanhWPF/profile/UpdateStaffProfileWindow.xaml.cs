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

namespace PhamTrongThanhWPF.profile
{
    /// <summary>
    /// Interaction logic for UpdateStaffProfileWindow.xaml
    /// </summary>
    public partial class UpdateStaffProfileWindow : Window
    {
        private const string FIELD_REQUIRED_ERROR = "This field is required";

        public UpdateStaffProfileWindow()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            String id = Application.Current.Properties["Id"].ToString();
            StaffAccountRepository staffAccountRepository = new StaffAccountRepository();
            var acc = staffAccountRepository.getById(id);
            txtStaffId.Text = acc.StaffId;
            txtName.Text = acc.FullName;
            txtEmail.Text = acc.Email;
            txtPassword.Text = acc.Password;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (validateData())
            {
                var staff = new StaffAccount()
                {
                    StaffId = txtStaffId.Text,
                    FullName = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };
                new StaffAccountRepository().updateData(staff);
                MessageBox.Show("Update successfully");
                this.Close();
            }
        }

        private Boolean validateData()
        {
            Boolean isValid = true;
            if (txtName.Text.Trim() == "")
            {
                isValid = false;
                lblNameError.Content = FIELD_REQUIRED_ERROR;
                lblNameError.Visibility = Visibility.Visible;
            }
            else
            {
                lblNameError.Visibility = Visibility.Collapsed;
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

            return isValid;
        }
    }
}
