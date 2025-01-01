using BibliotekaWSB.Data;
using BibliotekaWSB.Services;
using BibliotekaWSB.ViewsWPFModel;
using BibliotekaWSB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class LoginWindow : Window
{
    private AuthenticationService _authService;

    public LoginWindow()
    {
        InitializeComponent();
        var userRepo = new FileUserRepository();
        _authService = new AuthenticationService(userRepo);
    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var user = _authService.Login(UsernameBox.Text, PasswordBox.Password);
        if (user != null)
        {
            var mainWindow = new MainWindow(user);
            mainWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Błędna nazwa użytkownika lub hasło.");
        }
    }
    public void Register_Button_Click(object sender, RoutedEventArgs e)
    {
        var registerWindow = new RegisterWindow();
        registerWindow.Show();
        Close();
    }
    public void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
    public void ForgotPassword_Click(object sender, RoutedEventArgs e)
    {
        var forgotPasswordWindow = new ForgotPasswordWindow();
        forgotPasswordWindow.Show();
        Close();
    }
}