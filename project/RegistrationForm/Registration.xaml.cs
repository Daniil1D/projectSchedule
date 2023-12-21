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
using static project.App;

namespace project.RegistrationForm
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private User1 _curren = new User1();
        public Registration(User1 selected)
        {
            InitializeComponent();
            if (selected != null)
            {
                _curren = selected;
            }
            DataContext = _curren;

            Role.ItemsSource = SchoolScheduleEntities3.GetContext().Role.ToList();

            login.Text = "Введите логин";
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(login.Text))
            {
                errors.Append("Поле 'Логин' не заполнено.\n");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_curren.IDUser1 == 0)
            {
                SchoolScheduleEntities3.GetContext().User1.Add(_curren);
                try
                {
                    SchoolScheduleEntities3.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Class.Class1.MainFrame.Navigate(new Authorization());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new Authorization());
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (login.Text == "Введите логин")
            {
                login.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login.Text))
            {
                login.Text = "Введите логин";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.GoBack();
        }
    }
}
