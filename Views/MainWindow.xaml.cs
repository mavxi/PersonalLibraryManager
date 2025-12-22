using System.Windows;
using PersonalLibraryManager.ViewModels;

namespace PersonalLibraryManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}