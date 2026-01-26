using PersonalLibraryManager.ViewModels;

namespace PersonalLibraryManager.Views
{
    public partial class GenreWindow : System.Windows.Window
    {
        public GenreWindow()
        {
            InitializeComponent();
            DataContext = new GenreViewModel();
        }
    }
}