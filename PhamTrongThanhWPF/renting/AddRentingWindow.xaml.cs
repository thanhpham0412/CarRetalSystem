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

        }
    }
}
