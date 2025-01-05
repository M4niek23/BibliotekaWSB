
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
        // Pobierz dane z pól
        string username = UsernameBox.Text;
        string password = PasswordBox.Password;
        string fullName = FullNameBox.Text;
        string email = EmailBox.Text;
        string phone = PhoneBox.Text;

        // Walidacja danych
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Sprawdź, czy użytkownik już istnieje
        if (_userRepository.GetByUsername(username) != null)
        {
            MessageBox.Show("Użytkownik o takiej nazwie już istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Utwórz nowego użytkownika
        var newUser = new Student(
            id: GenerateNewUserId(),
            username: username,
            passwordHash: password,
            fullName: fullName,
            studentNumber: null, // Możesz dodać logiczne przypisanie dla numeru studenta
            email: email,
            phone: phone
        );

        // Dodaj użytkownika do repozytorium
        _userRepository.Add(newUser);

        MessageBox.Show("Rejestracja zakończona sukcesem.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        this.Hide();
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
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