using Directory_of_Authors_and_Books.Controller;
using Directory_of_Authors_and_Books.Models;
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
    /// Логика взаимодействия для ShowAuthorInfoWindow.xaml
    /// </summary>
    public partial class ShowAuthorInfoWindow : Window
    {
        readonly private Service _service;
        private int _id;
        public ShowAuthorInfoWindow(Service service, int id)
        {
            InitializeComponent();
            _service = service;
            _id = id;
            RefreshBooks();
            ShowInfo();
        }

        private void RefreshBooks()
        {
            lvBooks.ItemsSource = _service.ShowAuthorsBooks(_id);
        }

        private void ShowInfo()
        {
            Author author = _service.GetAuthor(_id);
            FirstName.Text = author.FirstName;
            LastName.Text = author.LastName;
            MiddleName.Text = author.MiddleName;
            Birthday.Text = author.Birthday.ToString();
        }

        private void AddBookToThisAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            new AddBookToAuthorWindow(_service, _id).ShowDialog();
            RefreshBooks();
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            _service.DeleteBookOrAuthorFromConnection(((Book)lvBooks.SelectedItem).Id, _id);
            RefreshBooks();
        }
    }
}
