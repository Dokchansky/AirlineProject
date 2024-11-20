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
    /// Логика взаимодействия для CrewAdminWindow.xaml
    /// </summary>
    public partial class CrewAdminWindow : Window
    {
        public CrewAdminWindow()
        {
            InitializeComponent();
            InitializeComponent();
            LoadRoutes();

        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            AdminWindow adminWindow = new AdminWindow();
            Close();
            adminWindow.Show();
        }

        private void LoadRoutes()
        {
            using (var context = new Context())
            {
                var items = context.Crews.ToList();
                CrewGrid.ItemsSource = items;
            }
        }
    }
}
