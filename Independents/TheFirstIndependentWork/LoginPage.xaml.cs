namespace TeFtItWk
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToRegistrationPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(RegistrationPage), true);
        }

        private void GoToMenuPage(object sender, EventArgs e)
        {
            string userEmail = UserEmailEntry.Text;
            string userPassword = UserPasswordEntry.Text;

            bool isUserEmailEmpty = string.IsNullOrWhiteSpace(userEmail);
            if (isUserEmailEmpty)
            {
                AppShell.Current.DisplayAlert("Ошибка", "Заполните все поля!", "ОК");
                return;
            }

            bool isUserPasswordEmpty = string.IsNullOrWhiteSpace(userPassword);
            if (isUserPasswordEmpty)
            {
                AppShell.Current.DisplayAlert("Ошибка", "Заполните все поля!", "ОК");
                return;
            }

            bool isLoginSucceded = CatalogData.Users.Any(x => x.Name == userEmail && x.Password == userPassword);
            if (!isLoginSucceded)
            {
                AppShell.Current.DisplayAlert("Ошибка", "Проверьте пароль и почту, либо пройдите регистрацию", "ОК");
                return;
            }

            AppShell.Current.DisplayAlert("Успех", "Пользователь успешно авторизирован.", "Ок");

            AppShell.Current.GoToAsync("//" + nameof(MenuPage), true);
        }

        private void ChangePasswordVisibility(object sender, EventArgs e)
        {
            if (UserPasswordEntry.IsPassword == true)
            {
                UserPasswordEntry.IsPassword = false;
                PasswordVisibilityIB.Source = "not_visible";

            }

            else
            {
                UserPasswordEntry.IsPassword = true;
                PasswordVisibilityIB.Source = "visible";
            }
        }
    }

}
