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
    /// Логика взаимодействия для RouteAdminWindow.xaml
    /// </summary>
    public partial class RouteAdminWindow : Window
    {
        public RouteAdminWindow()
        {
            InitializeComponent();
            LoadRoutes();
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            return;
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadRoutes()
        {
            using (var context = new Context())
            {
                var items = context.Routes.ToList();
                RouteGrid.ItemsSource = items;
            }
        }
    }
}
