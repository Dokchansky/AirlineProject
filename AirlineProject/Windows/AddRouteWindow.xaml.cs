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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace AirlineProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRouteWindow.xaml
    /// </summary>
    public partial class AddRouteWindow : Window
    {
        private readonly Context _context;
        public AddRouteWindow()
        {
            InitializeComponent();
            _context = new Context();
            LoadCrewMembers();


        }

        private void LoadCrewMembers()
        {
            // Загрузка пилотов и стюардессы из базы данных по их post_id
            var firstPilots = _context.Crews.Where(c => c.post_id == 1).ToList();
            var secondPilots = _context.Crews.Where(c => c.post_id == 2).ToList();
            var stewardesses = _context.Crews.Where(c => c.post_id == 3).ToList();

            first_pilot.ItemsSource = firstPilots;
            second_pilot.ItemsSource = secondPilots;
            stew_ardess.ItemsSource = stewardesses;

            // Установка отображаемого свойства для выпадающих списков
            first_pilot.DisplayMemberPath = "fullname";
            second_pilot.DisplayMemberPath = "fullname";
            stew_ardess.DisplayMemberPath = "fullname";
        }



        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(number_Route.Text) ||
                string.IsNullOrWhiteSpace(direction_Route.Text) ||
                first_pilot.SelectedItem == null ||
                second_pilot.SelectedItem == null ||
                stew_ardess.SelectedItem == null ||
                DateTimeDeparture.SelectedTime == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!int.TryParse(number_Route.Text, out int numberRoute))
            {
                MessageBox.Show("Номер рейса должен быть целым числом.");
                return;
            }

            var route = new Route
            {
                numberRoute = numberRoute,
                direction = direction_Route.Text,
                firstPilot = ((Crew)first_pilot.SelectedItem).post_id.ToString(),
                secondPilot = ((Crew)second_pilot.SelectedItem).post_id.ToString(),
                stewardess = ((Crew)stew_ardess.SelectedItem).post_id.ToString(),
                dateTimeDeparture = DateTimeDeparture.SelectedTime.Value
            };

            _context.Routes.Add(route);
            _context.SaveChanges();

            MessageBox.Show("Рейс успешно добавлен!");

            // Очистка полей после добавления
            number_Route.Clear();
            direction_Route.Clear();
            first_pilot.SelectedItem = null;
            second_pilot.SelectedItem = null;
            stew_ardess.SelectedItem = null;
            DateTimeDeparture.SelectedTime = null;



        }
    }
}
