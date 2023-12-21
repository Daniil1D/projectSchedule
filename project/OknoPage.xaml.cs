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

namespace project
{
    /// <summary>
    /// Логика взаимодействия для OknoPage.xaml
    /// </summary>
    public partial class OknoPage : Window
    {
        public OknoPage()
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
    }
}
