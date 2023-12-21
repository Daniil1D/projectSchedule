using MahApps.Metro.Controls;
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
using System.Windows.Threading;

namespace project
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private bool isNavigationPerformed = false;
        public MainPage() // Изменен конструктор, чтобы получить роль пользователя
        {
            InitializeComponent();
            Class.Class2.Frame = Frame;
            // Добавьте обработчик события клика для всего содержимого страницы
            AddHandler(MouseDownEvent, new MouseButtonEventHandler(Page_MouseDown), true);

            // Добавьте обработчик события Navigated при загрузке страницы
            Class.Class2.Frame.Navigated += Frame_Navigated;
        }
        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Получите элемент, на который был сделан клик
            DependencyObject source = (DependencyObject)e.OriginalSource;

            // Проверьте, принадлежит ли этот элемент боковому меню
            bool isMenuElement = false;
            while (source != null)
            {
                if (source == SideMenu)
                {
                    isMenuElement = true;
                    break;
                }
                source = VisualTreeHelper.GetParent(source);
            }

            // Если клик сделан вне бокового меню, скройте его
            if (!isMenuElement)
            {
                SideMenu.Visibility = Visibility.Collapsed;
                // Сбросьте значение Panel.ZIndex обратно на исходное
                Panel.SetZIndex(SideMenu, 0);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class.Class2.Frame.Navigate(new jniwefnewfjwq());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Получите экземпляр главного окна
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

            // Перейдите на новую страницу (замените YourNewPage на имя вашей новой страницы)
            if (mainWindow != null)
            {
                Class.Class2.Frame.Navigate(new Schedule());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SideMenu.Visibility == Visibility.Collapsed)
            {
                SideMenu.Visibility = Visibility.Visible;
                // Установите высокое значение для Panel.ZIndex, чтобы боковое меню было поверх остальных элементов
                Panel.SetZIndex(SideMenu, 999);
            }
            else
            {
                SideMenu.Visibility = Visibility.Collapsed;
                // Сбросьте значение Panel.ZIndex обратно на исходное
                Panel.SetZIndex(SideMenu, 0);
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new RegistrationForm.LoginPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (isNavigationPerformed)
            {
                Class.Class1.MainFrame.GoBack();
            }
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            // Устанавливаем флаг isNavigationPerformed в true при каждой навигации
            isNavigationPerformed = true;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Class.Class1.MainFrame.Navigate(new RegistrationForm.LoginPage());
        }
    }
}
