using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;
using PersonalLibraryManager.Services;

namespace PersonalLibraryManager
{
    public partial class App : Application
    {
        private static LibraryDbContext _context = new LibraryDbContext();

        public static ObservableCollection<Author> Authors => _context.Authors.Local.ToObservableCollection();
        public static ObservableCollection<Genre> Genres => _context.Genres.Local.ToObservableCollection();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _context.Database.EnsureCreated();
            _context.Authors.Load();
            _context.Genres.Load();
        }
    }
}