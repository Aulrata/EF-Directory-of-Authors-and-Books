
using Directory_of_Authors_and_Books.Data;
using Directory_of_Authors_and_Books.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Directory_of_Authors_and_Books.Controller
{
    public class Service
    {
        readonly private DirectoryContext _directoryContext;
        public Service() 
        { 
            _directoryContext= new DirectoryContext();
        }


        public List<Author> ShowAuthors()
        {
            return _directoryContext.Authors.ToList();
        }

        public void AddAuthor( string firstName, string lastName, string middleName, DateTime birthday)
        {
            try
            {
                _directoryContext.Authors.Add(new Author(firstName, lastName, middleName, birthday.Date));
                _directoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteAuthor(int id)
        {
            try
            {
                Author author = _directoryContext.Authors.FirstOrDefault(e => e.Id == id);
                _directoryContext.Authors.Remove(author);
                _directoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateAuthor(int id, string firstName, string lastName, string middleName, DatePicker birthday)
        {
            
            try
            {
                Author author = _directoryContext.Authors.FirstOrDefault(e=>e.Id== id);
                if(author != null) 
                {
                    if (!String.IsNullOrEmpty(firstName))
                        author.FirstName = firstName;
                    if (!String.IsNullOrEmpty(lastName))
                        author.LastName = lastName;
                    if (!String.IsNullOrEmpty(middleName))
                        author.MiddleName = middleName;
                    if (birthday.SelectedDate != null)
                        author.Birthday = (DateTime)birthday.SelectedDate;
                    //_directoryContext.Authors.Update(author);
                    _directoryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Author GetAuthor(int id)
        {
            return _directoryContext.Authors.FirstOrDefault(e => e.Id== id);
        }

        public Book GetBook(int id)
        {
            return _directoryContext.Books.FirstOrDefault(e => e.Id== id);
        }

        public void AddBookToAuthor(int id, string ids)
        {
            string[] idsArray = ids.Split(' ');
            
            foreach (Book book in _directoryContext.Books.ToList())
            {
                for (int i = 0; i < idsArray.Length; i++)
                {
                    if (book.Id == int.Parse(idsArray[i]))
                    {
                        _directoryContext.Connections.Add(new Connection
                        {
                            AuthorId = id,
                            BookId = book.Id,
                        });
                        _directoryContext.SaveChanges();
                    }
                }
            }
        }

        public List<Book> ShowBooks()
        {
            return _directoryContext.Books.ToList();
        }

        public void AddBook(string title, int yearOfIssue)
        {
            try
            {
                _directoryContext.Books.Add(new Book 
                { 
                  Title = title, 
                  YearOfIssue = yearOfIssue,
                });
                _directoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                Book book = _directoryContext.Books.FirstOrDefault(x => x.Id == id);
                _directoryContext.Books.Remove(book);
                _directoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateBook(int id, string title, string yearOfIssue)
        {
            try
            {
                Book book = _directoryContext.Books.FirstOrDefault(e => e.Id == id);
                if (book != null)
                {
                    if(!String.IsNullOrEmpty(title))
                        book.Title = title;
                    if(!String.IsNullOrEmpty(yearOfIssue) && int.TryParse(yearOfIssue, out _))
                        book.YearOfIssue = int.Parse(yearOfIssue);
                    _directoryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Book> ShowAuthorsBooks(int authorId)
        {
            List<Book> books = new();

            foreach (Connection connection in _directoryContext.Connections.ToList())
            {
                if (connection.AuthorId == authorId)
                {
                    books.Add(_directoryContext.Books.FirstOrDefault(e => e.Id == connection.BookId));
                }
            }

            return books;
        }

        public void DeleteBookOrAuthorFromConnection(int bookId, int authorId)
        {
            try
            {
                Connection connection = _directoryContext.Connections.FirstOrDefault(e => e.BookId == bookId && e.AuthorId == authorId);
                if (connection != null)
                {
                    _directoryContext.Remove(connection);
                    _directoryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }




        public List<Author> ShowAuthorsForBook(int bookId)
        {
            List<Author> authors = new();

            foreach (Connection connection in _directoryContext.Connections.ToList())
            {
                if (connection.BookId == bookId)
                {
                    authors.Add(_directoryContext.Authors.FirstOrDefault(e => e.Id == connection.AuthorId));
                }
            }

            return authors;
        }


        public void AddAuthorToBook(int bookId, string idOfAuthors)
        {
            string[] idArray = idOfAuthors.Split(' ');

            foreach (Author author in _directoryContext.Authors.ToList())
            {
                for (int i = 0; i < idArray.Length; i++)
                {
                    if (author.Id == int.Parse(idArray[i]))
                    {
                        _directoryContext.Connections.Add(new Connection
                        {
                            AuthorId = author.Id,
                            BookId =bookId,
                        });
                        _directoryContext.SaveChanges();
                    }
                }
            }
        }
    }
    
}
