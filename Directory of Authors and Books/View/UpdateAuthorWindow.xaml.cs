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
    /// Логика взаимодействия для UpdateAuthor.xaml
    /// </summary>
    public partial class UpdateAuthorWindow : Window
    {
        readonly private Service _service;
        private int _authorId;
        public UpdateAuthorWindow(Service service,int id)
        {
            InitializeComponent();
            _service = service;
            _authorId= id;
        }

        private void UpdateAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            
            _service.UpdateAuthor(_authorId,FirstName.Text,LastName.Text,MiddleName.Text, Birthday);
            Close();
        }
    }
}
