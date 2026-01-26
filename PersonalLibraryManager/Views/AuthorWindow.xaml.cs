using PersonalLibraryManager.ViewModels;

namespace PersonalLibraryManager.Views
{
    public partial class AuthorWindow : System.Windows.Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
            DataContext = new AuthorViewModel();
        }
    }
}