using BibliotekaWSB.Models;
using BibliotekaWSB.Data;
using BibliotekaWSB.ViewsWPFModel;
using System.Linq;
using System.Windows;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class ForgotPasswordWindow : Window
{
    private FileUserRepository _userRepository;

    public ForgotPasswordWindow()
    {
        InitializeComponent();
        _userRepository = new FileUserRepository();
    }

    private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameBox.Text;
        var email = EmailBox.Text;
        var user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username && u.Email == email);
        if (user == null)
        {
            MessageBox.Show("Nie znaleziono użytkownika o podanej nazwie i adresie email.");
            return;
        }

        // Logika resetu hasła - np. ustawiamy nowe proste hasło
        user.PasswordHash = "nowehaslo123";
        _userRepository.Remove(user);
        _userRepository.Add(user);
        
        MessageBox.Show("Hasło zostało zresetowane do: nowehaslo123. Zaloguj się i zmień hasło.");
        this.Hide();
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }
    public void btnClose_Click(object sender, RoutedEventArgs e)
    {

        this.Close();
    }
    public void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    public void btn_Back_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }
}
