using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Views;

namespace PersonalLibraryManager.ViewModels
{
    public partial class BookEditViewModel : ObservableObject
    {
        private LibraryDbContext _context;
        private Window _window;

        [ObservableProperty]
        private Book _book;

        public BookEditViewModel(LibraryDbContext context, Book book = null)
        {
            _context = context;

            if (book == null)
            {
                Book = new Book();
            }
            else
            {
                Book = _context.Books.Find(book.Id);
            }
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Book.Title) || string.IsNullOrWhiteSpace(Book.Author))
            {
                MessageBox.Show("Title and Author are required fields.");
                return;
            }

            if (Book.Id == 0)
            {
                _context.Books.Add(Book);
            }
            else
            {
                _context.Entry(Book).State = EntityState.Modified;
            }

            _context.SaveChanges();

            _window = Application.Current.Windows.OfType<BookEditWindow>().FirstOrDefault();
            _window.DialogResult = true;
            _window.Close();
        }

        [RelayCommand]
        private void Cancel()
        {
            _window = Application.Current.Windows.OfType<BookEditWindow>().FirstOrDefault();
            _window.DialogResult = false;
            _window.Close();
        }
    }
}