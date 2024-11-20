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
        private Context _context;
        public RouteAdminWindow()
        {
            InitializeComponent();
            LoadRoutes();
            _context = new Context();
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AdminWindow adminWindow = new AdminWindow();
            Close();
            adminWindow.Show();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AddRouteWindow addRouteWindow = new AddRouteWindow();
            Close();
            addRouteWindow.Show();
        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoute = RouteGrid.SelectedItem as Route;

            if (selectedRoute != null)
            {
                
                var routeToDelete = _context.Routes.FirstOrDefault(r => r.numberRoute == selectedRoute.numberRoute);

                if (routeToDelete != null)
                {
                    _context.Routes.Remove(routeToDelete); 
                    MessageBox.Show("Маршрут удален!");
                    _context.SaveChanges(); 
                    LoadRoutes(); 
                }
                else
                {
                    MessageBox.Show("Маршрут не найден в базе данных.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите маршрут для удаления.");
            }
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
