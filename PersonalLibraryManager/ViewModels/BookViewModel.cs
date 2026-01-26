using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PersonalLibraryManager.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private LibraryDbContext _context;

        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public BookViewModel()
        {
            _context = new LibraryDbContext();
            _context.Database.EnsureCreated();

            LoadData();

            AddCommand = new RelayCommand(AddBook);
            SaveCommand = new RelayCommand(SaveChanges);
            DeleteCommand = new RelayCommand(DeleteBook);
        }

        private void LoadData()
        {
            _context.Books.Load();
            _context.Authors.Load();
            _context.Genres.Load();

            Books = _context.Books.Local.ToObservableCollection();
            Authors = _context.Authors.Local.ToObservableCollection();
            Genres = _context.Genres.Local.ToObservableCollection();
        }

        private void AddBook()
        {
            var newBook = new Book { Title = "New Book", Year = DateTime.Now.Year };
            Books.Add(newBook);
            SelectedBook = newBook;
        }

        private void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                _context.Books.Remove(SelectedBook);
                _context.SaveChanges();
            }
        }
    }
}