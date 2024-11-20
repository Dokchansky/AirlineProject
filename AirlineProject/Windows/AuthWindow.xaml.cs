using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using MaterialDesignColors;
using MaterialDesignThemes;


namespace AirlineProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string login = loginbox.Text;
            string password = passwordbox.Password;
            

            using (var context = new Context())
            {
                var user = context.Users.FirstOrDefault(l => l.login == login && l.password == password && l.role_id == 1);
                var user2 = context.Users.FirstOrDefault(l => l.login == login && l.password == password && l.role_id == 2);

                if (user != null)
                {

                    MessageBox.Show("Авторизация прошла успешно!");
                    Hide();
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                }
                else if (user2 != null)
                {

                    MessageBox.Show("Авторизация прошла успешно!");
                    Hide();
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                    return;
                }
            }
        }
    }
}
