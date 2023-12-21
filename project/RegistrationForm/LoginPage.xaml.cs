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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }



        private void TeacherButton_Click(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new AuthorizationTeacher());
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new AdminPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                Class.Class1.MainFrame.GoBack();
            
        }
    }
}
