using System.Windows;
using System.Windows.Controls;

namespace Finals
{
    public partial class AboutDevelopersPage : Page
    {
        public AboutDevelopersPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the previous page (if available)
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService?.GoBack();
            }
            else
            {
                // Navigate to the main page if there's no page in the back stack
                NavigationService?.Navigate(new MainWindow());
            }
        }

        private void AboutDevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the current page is already the AboutDevelopersPage before navigating
            if (!(NavigationService?.Content is AboutDevelopersPage))
            {
                NavigationService?.Navigate(new AboutDevelopersPage());
            }
        }
    }
}
