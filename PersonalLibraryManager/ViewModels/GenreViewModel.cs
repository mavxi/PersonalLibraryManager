using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PersonalLibraryManager.ViewModels
{
    public class GenreViewModel : ViewModelBase
    {
        private LibraryDbContext _context;
        public ObservableCollection<Genre> Genres { get; set; }

        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set { _selectedGenre = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public GenreViewModel()
        {
            _context = new LibraryDbContext();
            _context.Genres.Load();
            Genres = _context.Genres.Local.ToObservableCollection();

            AddCommand = new RelayCommand(AddGenre);
            SaveCommand = new RelayCommand(SaveChanges);
            DeleteCommand = new RelayCommand(DeleteGenre);
        }

        private void AddGenre()
        {
            var newGenre = new Genre { Name = "New Genre" };
            Genres.Add(newGenre);
            SelectedGenre = newGenre;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        private void DeleteGenre()
        {
            if (SelectedGenre != null)
            {
                _context.Genres.Remove(SelectedGenre);
                _context.SaveChanges();
            }
        }
    }
}