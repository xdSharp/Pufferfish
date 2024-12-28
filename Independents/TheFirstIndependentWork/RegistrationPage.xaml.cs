namespace TeFtItWk;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
        InitializeComponent();
	}

    
    private void GoToMenuPage(object sender, EventArgs e)
    {
        string userEmail = UserEmailEntry.Text;
        string userName = UserNameEntry.Text;
        string userPassword = UserPasswordEntry.Text;
        string userRepeatPassword = UserRepeatPasswordEntry.Text;

        bool isUserEmailEmpty = string.IsNullOrWhiteSpace(userName);
        if (isUserEmailEmpty)
        {
            AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
            return;
        }

        bool isUserNameEmpty = string.IsNullOrWhiteSpace(userName);
        if (isUserNameEmpty)
        {
            AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
            return;
        }

        bool isUserPasswordEmpty = string.IsNullOrWhiteSpace(userPassword);
        if (isUserPasswordEmpty)
        {
            AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
            return;
        }

        bool isUserRepeatPasswordEmpty = string.IsNullOrWhiteSpace(userRepeatPassword);
        if (isUserRepeatPasswordEmpty)
        {
            AppShell.Current.DisplayAlert("������", "��������� ��� ����!", "��");
            return;
        }

        bool isUserExistByName = CatalogData.Users.Any(x => x.Name == userName);
        if (isUserExistByName)
        {
            AppShell.Current.DisplayAlert("������", "��� ��� ������������ ������, ������� ������", "��");
            return;
        }

        bool isPasswordRepeatSucceded = userPassword == userRepeatPassword;
        if (!isPasswordRepeatSucceded)
        {
            AppShell.Current.DisplayAlert("������", "������ �� ���������!", "��");
            return;
        }

        CatalogData.Users.Add(new User(userEmail, userName, userPassword));

        AppShell.Current.DisplayAlert("�����", "����������� ��������!", "��");
        AppShell.Current.GoToAsync("..", true);
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
