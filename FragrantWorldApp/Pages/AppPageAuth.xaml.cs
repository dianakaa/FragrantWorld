using FragrantWorldApp.Data;
using FragrantWorldApp.Models;
using FragrantWorldApp.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FragrantWorldApp.Pages
{
    public partial class AppPageAuth : Page
    {
        private readonly ProductService _productService;

        private readonly User _currentUser;

        public AppPageAuth(User user)
        {
            _productService = new ProductService(new FragrantWorldContext());
            _currentUser = user;

            InitializeComponent();
            LoadProductsAsync();
            DisplayInfo();
        }

        private void DisplayInfo()
        {
            UserInfoLabal.Content = $"{_currentUser.Surname} {_currentUser.Name} {_currentUser.Patronymic}";

            if (_currentUser.RoleId != null &&
                (_currentUser.RoleId == 1 || _currentUser.RoleId == 3))
            {
                ChangeOrdersButton.Visibility = Visibility.Visible;
            }
            else
            {
                ChangeOrdersButton.Visibility = Visibility.Collapsed;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new AppPage();
            NavigationService.Navigate(new AppPage());
        }

        private async void LoadProductsAsync()
        {
            ProductsListBox.ItemsSource = await _productService.GetProductsAsync();
        }

        private void ChangeOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new OrderPage();
            NavigationService.Navigate(new OrderPage());
        }
    }
}
