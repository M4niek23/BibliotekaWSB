using BibliotekaWSB.Models;
using BibliotekaWSB.ViewsWPFModel;
using BibliotekaWSB;
using System.Windows;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class ChangePasswordWindow : Window
{
    private readonly User _loggedUser;

    public ChangePasswordWindow(User loggedUser)
    {
        InitializeComponent();
        _loggedUser = loggedUser;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        string oldPassword = OldPasswordBox.Password;
        string newPassword = NewPasswordBox.Password;


        if (_loggedUser.VerifyPassword(oldPassword))
        {
            _loggedUser.PasswordHash = newPassword; // Zamień na odpowiednie hashowanie
            MessageBox.Show("Hasło zostało pomyślnie zmienione.");
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
        else
        {
            MessageBox.Show("Stare hasło jest niepoprawne.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    public void btn_Back_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow(_loggedUser);
        mainWindow.Show();
        Close();
    }
}
