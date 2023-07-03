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
    /// Логика взаимодействия для ShowBookInfoWindow.xaml
    /// </summary>
    public partial class ShowBookInfoWindow : Window
    {
        readonly private Service _service;
        private int _id;
        public ShowBookInfoWindow(Service service, int id)
        {
            InitializeComponent();
            _service = service;
            _id = id;
            RefreshAuthors();
            ShowInfo();
        }

        private void ShowInfo()
        {
            Book book = _service.GetBook(_id);
            Title.Text = book.Title;
            YearOfIssue.Text = book.YearOfIssue.ToString();
        }

        private void RefreshAuthors()
        {
            lvAuthors.ItemsSource = _service.ShowAuthorsForBook(_id);
        }

        private void AddAuthorToBookButton_Click(object sender, RoutedEventArgs e)
        {
            new AddAuthorToBookWindow(_service, _id).ShowDialog();
            RefreshAuthors();
        }

        private void DeleteAuthorFromBookButton_Click(object sender, RoutedEventArgs e)
        {
            _service.DeleteBookOrAuthorFromConnection(_id,((Author)lvAuthors.SelectedItem).Id);
            RefreshAuthors();
        }
    }
}
