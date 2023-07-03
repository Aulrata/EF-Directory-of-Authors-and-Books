using Directory_of_Authors_and_Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Directory_of_Authors_and_Books.Data
{
    public class DirectoryContext : DbContext
    {
        //Data Source=LAPTOP-HB9PP5FR;Initial Catalog=""EF Directory of Authors and Books"";Integrated Security=True;TrustServerCertificate=true
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Connection> Connections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionsString = GetConnectionStrung();
            optionsBuilder.UseSqlServer(@$"Data Source=LAPTOP-HB9PP5FR;Initial Catalog=""EF Directory of Authors and Books"";Integrated Security=True;TrustServerCertificate=true");
        }
        private string GetConnectionStrung()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Connection string.txt");
            if (!File.Exists(path))
                MessageBox.Show("Не найдена строка подключения");
            using (StreamReader sr = new(path))
            {
                return sr.ReadToEnd().Replace('\\"', '"');
            }
            
        }
    }
}
