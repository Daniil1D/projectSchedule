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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        
        public Schedule()
        {
            InitializeComponent();
           
            Frame.Navigate(new jniwefnewfjwq());
        }
      


        private void Card_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Примените эффект к карточке, когда курсор входит в нее
                border.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 5,
                    Opacity = 0.5
                };
            }
        }

        private void Card_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Удалите эффект с карточки, когда курсор покидает ее
                border.Effect = null;
            }
        }

        private void border2_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Примените эффект к карточке, когда курсор входит в нее
                border.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 5,
                    Opacity = 0.5
                };
            }
        }

        private void border2_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Удалите эффект с карточки, когда курсор покидает ее
                border.Effect = null;
            }
        }

        private void border3_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Примените эффект к карточке, когда курсор входит в нее
                border.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 5,
                    Opacity = 0.5
                };
            }
        }

        private void border3_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Удалите эффект с карточки, когда курсор покидает ее
                border.Effect = null;
            }
        }

        private void border13_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Примените эффект к карточке, когда курсор входит в нее
                border.Effect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    Direction = 315,
                    ShadowDepth = 5,
                    Opacity = 0.5
                };
            }
        }

        private void border13_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                // Удалите эффект с карточки, когда курсор покидает ее
                border.Effect = null;
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Создаем экземпляр второго окна
            OknoPage oknoPage = new OknoPage();

            // Устанавливаем главное окно приложения как его владельца
            oknoPage.Owner = Application.Current.MainWindow;

            // Устанавливаем положение окна по центру владельца
            oknoPage.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // Блокируем главное окно
            Application.Current.MainWindow.IsEnabled = false;

            // Подписываемся на событие закрытия второго окна
            oknoPage.Closed += (s, args) =>
            {
                // Разблокируем главное окно при закрытии второго окна
                Application.Current.MainWindow.IsEnabled = true;
            };

            // Отображаем второе окно модально
            oknoPage.ShowDialog();
        }
    }
}
