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
using Repo;
using BusinessObject;

namespace PhamTrongThanhWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initButton();
            
        }

        private void initButton()
        {
            Button btnProfile = new Button();
            btnProfile.Name = "btnProfile";
            btnProfile.Content = "Profile";
            btnProfile.Click += new RoutedEventHandler(btnProfile_Click);

            Button btnCar = new Button();
            btnCar.Name = "btnCar";
            btnCar.Content = "Car";
            btnCar.Click += new RoutedEventHandler(btnCar_Click);


            Button btnCustomer = new Button();
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Content = "Customer";
            btnCustomer.Click += new RoutedEventHandler(btnCustomer_Click);


            Button btnRenting = new Button();
            btnRenting.Name = "btnRenting";
            btnRenting.Content = "Renting";
            btnRenting.Click += new RoutedEventHandler(btnRenting_Click);


            spButton.Children.Add(btnProfile);
            spButton.Children.Add(btnCar);
            spButton.Children.Add(btnCustomer);
            spButton.Children.Add(btnRenting);
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("profile/StaffProfilePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnCar_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("car/CarPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("customer/CustomerPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void btnRenting_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Source = new Uri("renting/RentingPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
