
using BibliotekaWSB.Data;
using BibliotekaWSB.Models;
using BibliotekaWSB.ViewsWPFModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class RegisterWindow : Window
{
    private readonly FileUserRepository _userRepository;

    public RegisterWindow()
    {
        InitializeComponent();
        _userRepository = new FileUserRepository();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameBox.Text;
        string password = PasswordBox.Password;
        string fullName = FullNameBox.Text;
        string email = EmailBox.Text;
        string phone = PhoneBox.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!IsValidEmail(email))
        {
            MessageBox.Show("Nieprawidłowy format adresu e-mail.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (password.Length < 6)
        {
            MessageBox.Show("Hasło musi mieć co najmniej 6 znaków.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_userRepository.GetByUsername(username) != null)
        {
            MessageBox.Show("Użytkownik o takiej nazwie już istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var newUser = new Student(
            id: GenerateNewUserId(),
            username: username,
            passwordHash: password,
            fullName: fullName,
            studentNumber: null, 
            email: email,
            phone: phone
        );

        
        _userRepository.Add(newUser);

        MessageBox.Show("Rejestracja zakończona sukcesem.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        this.Hide();
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }


    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private int GenerateNewUserId()
    {
        var users = _userRepository.GetAll();
        return users.Any() ? users.Max(u => u.Id) + 1 : 1;
    }
    public void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    public void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btn_Back_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow();
        this.Close();
        loginWindow.Show();
    }
}