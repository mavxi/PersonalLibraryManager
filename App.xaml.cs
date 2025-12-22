using System.Windows;
using Microsoft.EntityFrameworkCore;
using PersonalLibraryManager.Models;

namespace PersonalLibraryManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new LibraryDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}