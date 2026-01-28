using System.Windows;

namespace PersonalLibraryManager.Views
{
    public partial class AboutWindow : System.Windows.Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}