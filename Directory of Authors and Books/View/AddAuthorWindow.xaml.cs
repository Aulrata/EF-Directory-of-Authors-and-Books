using Directory_of_Authors_and_Books.Controller;
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

namespace Directory_of_Authors_and_Books.View
{
    /// <summary>
    /// Логика взаимодействия для AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        readonly private Service _service;
        public AddAuthorWindow(Service service)
        {
            InitializeComponent();
            _service= service;
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(FirstName.Text))
                return;
            if (String.IsNullOrWhiteSpace(LastName.Text))
                return;
            if(Birthday.SelectedDate == null)
                return;
            
            _service.AddAuthor(FirstName.Text, LastName.Text, MiddleName.Text, (DateTime)Birthday.SelectedDate);
            Close();
        }
    }
}
