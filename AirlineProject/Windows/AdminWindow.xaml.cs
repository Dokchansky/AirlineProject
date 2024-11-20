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

namespace AirlineProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void flight_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RouteAdminWindow routeAdminWindow = new RouteAdminWindow();
            Close();
            routeAdminWindow.Show();
        }

        private void crew_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CrewAdminWindow crewAdminWindow = new CrewAdminWindow();
            crewAdminWindow.Show();


        }
    }
}
