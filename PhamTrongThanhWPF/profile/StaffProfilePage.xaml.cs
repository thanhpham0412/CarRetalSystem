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

namespace PhamTrongThanhWPF.profile
{
    /// <summary>
    /// Interaction logic for StaffProfilePage.xaml
    /// </summary>
    public partial class StaffProfilePage : Page
    {
        public StaffProfilePage()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            String id = Application.Current.Properties["Id"].ToString();
            StaffAccountRepository staffAccountRepository = new StaffAccountRepository();
            var acc = staffAccountRepository.getById(id);
            lblId1.Content = acc.StaffId;
            lblName1.Content = acc.FullName;
            lblEmail1.Content = acc.Email;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateStaffProfileWindow = new UpdateStaffProfileWindow();
            updateStaffProfileWindow.ShowDialog();
            loadData();
        }
    }
}
