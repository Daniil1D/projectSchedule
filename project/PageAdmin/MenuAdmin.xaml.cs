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

namespace project.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Page
    {
        private bool isNavigationPerformed = false;
        public MenuAdmin()
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
            Class.Class2.Frame.Navigate(new RaspisanieAdmin());
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
            Class.Class1.MainFrame.Navigate(new RegistrationForm.Registration(null));
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class.Class2.Frame.Navigate(new AddEditRaspisanie2((sender as Button).DataContext as ScheduleE));
        }
    }
}
