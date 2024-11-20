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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
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
             RouteWindow routeWindow = new RouteWindow();
             Close();
             routeWindow.Show();  
        }

        private void crew_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            CrewWindow crewWindow = new CrewWindow();
            Close();
            crewWindow.Show();


        }
    }
}
