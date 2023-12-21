using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
    /// Логика взаимодействия для RaspisanieAdmin.xaml
    /// </summary>
    public partial class RaspisanieAdmin : Page
    {
        public RaspisanieAdmin()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                SchoolScheduleEntities3.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGRid.ItemsSource = SchoolScheduleEntities3.GetContext().ScheduleE.ToList();
            }
        }

        private void CalendarDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var BtnDelete = DGRid.SelectedItems.Cast<ScheduleE>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {BtnDelete.Count()} элементы", "Внимание",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    SchoolScheduleEntities3.GetContext().ScheduleE.RemoveRange(BtnDelete);
                    SchoolScheduleEntities3.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGRid.ItemsSource = SchoolScheduleEntities3.GetContext().ScheduleE.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Class.Class2.Frame.Navigate(new AddEditRaspisanie2((sender as Button).DataContext as ScheduleE));
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Получаем контейнер строки DataGrid
                DataGridRow rowContainer = (DataGridRow)DGRid.ItemContainerGenerator.ContainerFromIndex(0);

                // Создаем область рендеринга
                System.Windows.Size printSize = new System.Windows.Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                DGRid.Measure(printSize);
                DGRid.Arrange(new Rect(new System.Windows.Point(0, 0), printSize));

                // Рендерим DataGrid на принтере
                printDialog.PrintVisual(rowContainer, "Печать расписания");
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGRid.ItemsSource = Class.BD.bd.ScheduleE.Where(item => item.Class1.ToString().Contains(txtSearch.Text) ||
            item.Class11.ClassNumber.ToString().Contains(txtSearch.Text)).ToList();
        }
    }
}
