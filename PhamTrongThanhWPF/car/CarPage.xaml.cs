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

namespace PhamTrongThanhWPF.car
{
    /// <summary>
    /// Interaction logic for CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            var cars = new CarRepository().getData();
            dgCarManagement.ItemsSource = cars;
        }

        private void loadDataWithStr(string search)
        {
            var cars = new CarRepository().getDataWithStr(search);
            dgCarManagement.ItemsSource = cars;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addCarWindow = new AddCarWindow();
            addCarWindow.ShowDialog();
            dgCarManagement.ItemsSource = new CarRepository().getData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var car = (Car)dgCarManagement.SelectedItem;
            if (car == null)
            {
                MessageBox.Show("Select a car to update");
            } else
            {
                var updateVarWindow = new UpdateCarWindow(car);
                updateVarWindow.ShowDialog();
                dgCarManagement.ItemsSource = new CarRepository().getData();
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var car = (Car)dgCarManagement.SelectedItem;
            if (car == null)
            {
                MessageBox.Show("Select a car to delete");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure to delete car {car.CarId}?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    new CarRepository().deleteData(car);
                    MessageBox.Show("Delete successfully.");
                    dgCarManagement.ItemsSource = new CarRepository().getData();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            loadDataWithStr(txtSearch.Text);
        }
    }
}
