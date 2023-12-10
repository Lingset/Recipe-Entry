using System.Windows;

namespace Finals
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RecipeEntryButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the RecipeEntryPage when the button is clicked
            MainFrame.NavigationService.Navigate(new RecipeEntryPage());
        }

        private void AboutDevelopersButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the AboutDevelopersPage when the button is clicked
            MainFrame.NavigationService.Navigate(new AboutDevelopersPage());
        }
    }
}
