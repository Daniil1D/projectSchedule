using MahApps.Metro.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Логика взаимодействия для jniwefnewfjwq.xaml
    /// </summary>
    public partial class jniwefnewfjwq : Page
    {
        public jniwefnewfjwq() // Изменен конструктор
        {
            InitializeComponent();
            //if (userRole == 2 || userRole ==3)
            //{
            //    Service.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    Service.Visibility = Visibility.Collapsed;
            //}
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SchoolScheduleEntities3.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGRid.ItemsSource = SchoolScheduleEntities3.GetContext().ScheduleE.ToList();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получите выбранную дату из календаря
            DateTime? selectedDateNullable = CalendarDatePicker.SelectedDate;

            if (selectedDateNullable.HasValue)
            {
                DateTime selectedDate = selectedDateNullable.Value.Date;

                // Фильтруйте записи в вашем источнике данных DataGrid
                List<ScheduleE> filteredData = SchoolScheduleEntities3.GetContext().ScheduleE
                    .Where(item => item.DayOfTheWeek.HasValue &&
                           System.Data.Entity.DbFunctions.TruncateTime(item.DayOfTheWeek.Value) == selectedDate)
                    .ToList();

                // Привяжите отфильтрованные данные к DataGrid
                DGRid.ItemsSource = filteredData;
            }
            else
            {
                // Если дата не выбрана, очистите источник данных DataGrid
                DGRid.ItemsSource = null;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGRid.ItemsSource = Class.BD.bd.ScheduleE.Where(item => item.Class1.ToString().Contains(txtSearch.Text) || 
            item.Class11.ClassNumber.ToString().Contains(txtSearch.Text)).ToList();
        }
    }
}
