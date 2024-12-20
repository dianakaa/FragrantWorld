using FragrantWorldApp.Data;
using FragrantWorldApp.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FragrantWorldApp.Pages
{
    public partial class AppPage : Page
    {
        private readonly ProductService _productService;

        public AppPage()
        {
            _productService = new ProductService(new FragrantWorldContext());

            InitializeComponent();
            LoadProductsAsync();
        }
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new AuthorizationPage();
            NavigationService.Navigate(new AuthorizationPage());
        }

        private async void LoadProductsAsync()
        {
            ProductsListBox.ItemsSource = await _productService.GetProductsAsync();
        }
    }
}
