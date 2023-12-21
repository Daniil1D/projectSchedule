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

namespace project.RegistrationForm
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            login.Text = "Введите логин";
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var user = Class.BD.bd.User1.FirstOrDefault(u => u.Login == login.Text && u.Password == password.Password);
            if (user != null)
            {
                if (user.Role == 1)
                {
                    MessageBox.Show("Ошибка.");
                }
                else if (user.Role == 2)
                {
                    int userRole = (int)user.Role; // Получаем роль пользователя из объекта user
                    NavigationService.Navigate(new PageAdmin.MenuAdmin());
                }
                else
                {
                    MessageBox.Show("Неизвестная роль пользователя.");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new Registration(null));
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.GoBack();
        }
    }
}
