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

namespace project.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для AddEditRaspisanie.xaml
    /// </summary>
    public partial class AddEditRaspisanie : Window
    {
        private ScheduleE _curren = new ScheduleE();
        public AddEditRaspisanie(ScheduleE selected)
        {
            InitializeComponent();
            if(selected != null)
            {
                _curren = selected;
            }
            DataContext = _curren;
            ComboCountries.ItemsSource = SchoolScheduleEntities3.GetContext().LessonTime.ToList();
            ComboCountries1.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries2.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries3.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries4.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries5.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries6.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries7.ItemsSource = SchoolScheduleEntities3.GetContext().Subject.ToList();
            ComboCountries8.ItemsSource = SchoolScheduleEntities3.GetContext().Class1.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_curren.IDSchedule == 0)
            {
                SchoolScheduleEntities3.GetContext().ScheduleE.Add(_curren);
            }
            try
            {
                SchoolScheduleEntities3.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                Class.Class2.Frame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
