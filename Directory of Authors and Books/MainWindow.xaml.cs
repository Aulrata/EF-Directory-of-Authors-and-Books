using Directory_of_Authors_and_Books.Controller;
using Directory_of_Authors_and_Books.Models;
using Directory_of_Authors_and_Books.View;
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

namespace Directory_of_Authors_and_Books
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly private Service _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new();
            RefreshAuthorTable();
            RefreshBookTable();
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            new AddAuthorWindow(_service).ShowDialog();
            RefreshAuthorTable();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            new AddBookWindow(_service).ShowDialog();
            RefreshBookTable();
        }

        private void RefreshAuthorTable()
        {
            lvAuthors.ItemsSource = _service.ShowAuthors();
        }

        private void RefreshBookTable()
        {
            lvBooks.ItemsSource = _service.ShowBooks();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (lvAuthors.SelectedItem != null)
            {
                _service.DeleteAuthor(((Author)lvAuthors.SelectedItem).Id);
                RefreshAuthorTable();
                lvAuthors.SelectedItem = null;

            }
            if (lvBooks.SelectedItem != null)
            {
                _service.DeleteBook(((Book)lvBooks.SelectedItem).Id);
                RefreshBookTable();
                lvBooks.SelectedItem = null;

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(lvAuthors.SelectedItem != null)
            {
                new UpdateAuthorWindow(_service,((Author)lvAuthors.SelectedItem).Id).ShowDialog();
                RefreshAuthorTable();
                lvAuthors.SelectedItem = null;

            }
            if (lvBooks.SelectedItem != null)
            {
                new UpdateBookWindow(_service, ((Book)lvBooks.SelectedItem).Id).ShowDialog();
                RefreshBookTable();
                lvBooks.SelectedItem = null;

            }
        }

        private void ShowInformationButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (lvAuthors.SelectedItem != null)
            {
                new ShowAuthorInfoWindow(_service, ((Author)lvAuthors.SelectedItem).Id). ShowDialog();
                RefreshAuthorTable();
                lvAuthors.SelectedItem= null;
            }
            if (lvBooks.SelectedItem != null)
            {
                new ShowBookInfoWindow(_service, ((Book)lvBooks.SelectedItem).Id). ShowDialog();
                RefreshBookTable();
                lvBooks.SelectedItem = null;
            }
        }

    }
}
