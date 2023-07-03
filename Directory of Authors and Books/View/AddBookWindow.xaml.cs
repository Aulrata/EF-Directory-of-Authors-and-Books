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
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        readonly private Service _service;
        public AddBookWindow(Service service)
        {
            InitializeComponent();
            _service =service;
        }

        private void AddBookButton(object sender, RoutedEventArgs e)
        {
            
            if (String.IsNullOrEmpty(Title.Text))
                return;
            if(String.IsNullOrEmpty(YearOfIssue.Text) && int.TryParse(YearOfIssue.Text, out _)) 
                return;
            _service.AddBook(Title.Text, int.Parse(YearOfIssue.Text));
            Close();
        }
    }
}
