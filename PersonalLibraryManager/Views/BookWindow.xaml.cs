using System.Windows;
using PersonalLibraryManager.ViewModels;

namespace PersonalLibraryManager.Views
{
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
            DataContext = new BookViewModel();
        }
    }
}