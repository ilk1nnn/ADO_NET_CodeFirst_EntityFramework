using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfApp1.DataAccess;
using WpfApp1.Entities;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext _context = new LibraryContext();
        public MainWindow()
        {
            InitializeComponent();
            _context.Database.CreateIfNotExists();


            #region Add Category

            GetCategires();

            #endregion


            #region Add Author


            GetAuthors();


            #endregion


            #region Add Book


            GetBooks();


            #endregion




        }

        public async void GetCategires()
        {
            if (_context.Categories.Count() == 0)
                await AddCategories();
            var categories = _context.Categories;
            CategoriesGrid.ItemsSource = await categories.ToListAsync();
        }

        public async void GetAuthors()
        {
            if (_context.Authors.Count() == 0)
                await AddAuthor();
            var authors = _context.Authors;
            AuthorsGrid.ItemsSource = await authors.ToListAsync();
        }
        public async void GetBooks()
        {
            if (_context.Books.Count() == 0)
                await AddBook();
            var books = _context.Books.Include(nameof(Category));
            BooksGrid.ItemsSource = await books.ToListAsync();
        }
        public async Task AddCategories()
        {
            _context.Categories.Add(new Category
            {
                Name = "Adventure"
            });
            _context.Categories.Add(new Category
            {
                Name = "Science - Fiction"
            });

            _context.Categories.Add(new Category
            {
                Name = "Programming"
            });

            await _context.SaveChangesAsync();

        }


        public async Task AddAuthor()
        {
            _context.Authors.Add(new Author
            {
                FirstName = "Linus",
                LastName = "Torvals",
                Age = 35
            });
            _context.Authors.Add(new Author
            {
                FirstName = "Leyla",
                LastName = "Mammadova",
                Age = 35
            });
            _context.Authors.Add(new Author
            {
                FirstName = "Axmed",
                LastName = "Axmedli",
                Age = 35
            });

            await _context.SaveChangesAsync();

        }

        public async Task AddBook()
        {
            _context.Books.Add(new Book
            {
                AuthorId = 1,
                CategoryId = 1,
                Pages = 100,
                Name = "My Best Book"
            });
            await _context.SaveChangesAsync();
        }

    }
}
