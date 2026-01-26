using System.Windows;
using PersonalLibraryManager.Views;

namespace PersonalLibraryManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBooks(object sender, RoutedEventArgs e)
        {
            new BookWindow().ShowDialog();
        }

        private void OpenAuthors(object sender, RoutedEventArgs e)
        {
            new AuthorWindow().ShowDialog();
        }

        private void OpenGenres(object sender, RoutedEventArgs e)
        {
            new GenreWindow().ShowDialog();
        }

        private void OpenAbout(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }
    }
}