using BibliotekaWSB.Models;
using BibliotekaWSB.ViewsWPFModel;
using BibliotekaWSB;
using System.Windows;
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Data;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class ChangePasswordWindow : Window
{
    private readonly User _loggedUser;
    private readonly IUserRepository _userRepository;

    public ChangePasswordWindow(User loggedUser)
    {
        InitializeComponent();
        _loggedUser = loggedUser;
        _userRepository = new FileUserRepository();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        string oldPassword = OldPasswordBox.Password;
        string newPassword = NewPasswordBox.Password;

        if (_loggedUser.VerifyPassword(oldPassword))
        {
            _loggedUser.PasswordHash = newPassword; 
            _userRepository.Update(_loggedUser);    

            MessageBox.Show("Hasło zostało pomyślnie zmienione.");
            this.Hide();
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
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
