using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PersonalLibraryManager.ViewModels
{
    public class AuthorViewModel : ViewModelBase
    {
        private LibraryDbContext _context;
        public ObservableCollection<Author> Authors { get; set; }

        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set { _selectedAuthor = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public AuthorViewModel()
        {
            _context = new LibraryDbContext();
            _context.Authors.Load();
            Authors = _context.Authors.Local.ToObservableCollection();

            AddCommand = new RelayCommand(AddAuthor);
            SaveCommand = new RelayCommand(SaveChanges);
            DeleteCommand = new RelayCommand(DeleteAuthor);
        }

        private void AddAuthor()
        {
            var newAuthor = new Author { Name = "New Author" };
            Authors.Add(newAuthor);
            SelectedAuthor = newAuthor;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        private void DeleteAuthor()
        {
            if (SelectedAuthor != null)
            {
                _context.Authors.Remove(SelectedAuthor);
                _context.SaveChanges();
            }
        }
    }
}