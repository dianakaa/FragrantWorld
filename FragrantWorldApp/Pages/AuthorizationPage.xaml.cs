using FragrantWorldApp.Data;
using FragrantWorldApp.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FragrantWorldApp.Pages
{
    public partial class AuthorizationPage : Page
    {
        private readonly UserService _userService;

        public AuthorizationPage()
        {
            InitializeComponent();

            _userService = new UserService(new FragrantWorldContext());

        }

        private async void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = PasswordBox.Password;

            var user = await _userService.LoginAsync(login, password);

            if (user != null)
            {
                this.Content = new AppPageAuth(user);
                NavigationService.Navigate(new AppPageAuth(user));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
