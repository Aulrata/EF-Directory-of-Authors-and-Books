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
    /// Логика взаимодействия для AddAuthorToBookWindow.xaml
    /// </summary>
    public partial class AddAuthorToBookWindow : Window
    {
        readonly private Service _service;
        private int _id;
        public AddAuthorToBookWindow(Service service, int id)
        {
            InitializeComponent();
            _service = service;
            _id = id;
        }

        private void AddBooksButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(idOfAuthors.Text))
                return;
            _service.AddAuthorToBook(_id, idOfAuthors.Text);
            Close();
        }
    }
}
