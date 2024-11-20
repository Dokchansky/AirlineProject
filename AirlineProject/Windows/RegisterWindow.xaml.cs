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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void registerbutton_Click(object sender, RoutedEventArgs e)
        {
            string surname = user_surname.Text;
            string name = user_name.Text;
            string patronymic = user_patronymic.Text;
            string login = loginbox.Text;
            string password = passwordbox.Password;

            if (string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(patronymic) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
                {
                MessageBox.Show("Заполните все поля ввода!");
                return;
                }

            using (var context = new Context())
            {
                var user = new User();
                {
                    user.surname = surname;
                    user.name = name;
                    user.patronymic = patronymic;
                    user.login = login;
                    user.password = password;
                    user.role_id = 1;
                }

                if (context.Users.Any(u => u.login == login))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                    return;
                }
                context.Users.Add(user);
                context.SaveChanges();

                MessageBox.Show("Регистрация успешна!");
                Hide();
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.Show();
            }

        
        }
    }
}
