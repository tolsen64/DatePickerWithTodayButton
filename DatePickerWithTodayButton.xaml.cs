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

namespace BoycoT
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DatePickerWithTodayButtonClass : UserControl
    {
        public DatePickerWithTodayButtonClass()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (e.Parameter as Calendar).SelectedDate = DateTime.Now.Date;
            dp1.IsDropDownOpen = false;
        }

        public static RoutedCommand SelectToday = new RoutedCommand("Today", typeof(DatePickerWithTodayButtonClass));

        // this is how to define a property in c#
        public DatePickerFormat SelectedDateFormat
        {
            get { return dp1.SelectedDateFormat; }
            set { dp1.SelectedDateFormat = value; }
        }

        public DateTime? SelectedDate
        {
            get { return dp1.SelectedDate; }
            set { dp1.SelectedDate = value; }
        }

        public Brush DatePickerTextBoxBackground
        {
            set
            {
                TextBox tb = (TextBox)dp1.Template.FindName("PART_TextBox", dp1);
                if (tb != null)
                {
                    tb.Background = value;
                }
            }
        }

        // this is how to define an event in c#
        public event EventHandler SelectedDateChanged;

        // this is how to raise the event in c#
        private void dp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EventHandler handler = SelectedDateChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

}
