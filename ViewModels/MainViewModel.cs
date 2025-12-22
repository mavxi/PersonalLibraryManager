using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using static System.Reflection.Metadata.BlobBuilder;

namespace PersonalLibraryManager.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private LibraryDbContext _context = new LibraryDbContext();

        [ObservableProperty]
        private ObservableCollection<Book> _books;

        [ObservableProperty]
        private Book _selectedBook;

        public MainViewModel()
        {
            _context.Database.EnsureCreated();
            LoadBooks();
        }

        private void LoadBooks()
        {
            _context.Books.Load();
            Books = _context.Books.Local.ToObservableCollection();
        }

        [RelayCommand]
        private void AddBook()
        {
            var window = new BookEditWindow();
            var viewModel = new BookEditViewModel(_context);
            window.DataContext = viewModel;

            if (window.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadBooks();
            }
        }

        [RelayCommand]
        private void EditBook()
        {
            if (SelectedBook == null)
            {
                MessageBox.Show("Please select a book to edit.");
                return;
            }

            var window = new BookEditWindow();
            var viewModel = new BookEditViewModel(_context, SelectedBook);
            window.DataContext = viewModel;

            if (window.ShowDialog() == true)
            {
                _context.SaveChanges();
                LoadBooks();
            }
        }

        [RelayCommand]
        private void DeleteBook()
        {
            if (SelectedBook == null)
            {
                MessageBox.Show("Please select a book to delete.");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete '{SelectedBook.Title}'?",
                               "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _context.Books.Remove(SelectedBook);
                _context.SaveChanges();
                LoadBooks();
            }
        }

        [RelayCommand]
        private void About()
        {
            var window = new AboutWindow();
            window.ShowDialog();
        }

        [RelayCommand]
        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}