using System.Linq;
using System.Windows.Input;
using System.Windows;
using BibliotekaWSB.Data;
using BibliotekaWSB.Models;
using BibliotekaWSB.Services;
using BibliotekaWSB.ViewsWPFModel;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class MyAccountView : Window
{
    private User _loggedUser;
    private RentalService _rentalService;

    public MyAccountView(User user)
    {
        InitializeComponent();
        _loggedUser = user;

        // Inicjalizacja RentalService
        var bookRepository = new FileBookRepository();
        var rentalRepository = new FileRentalRepository();
        _rentalService = new RentalService(bookRepository, rentalRepository);

        // Pobranie liczby aktywnych wypożyczeń
        var activeLoansCount = _rentalService.GetUserRentals(_loggedUser)
            .Count(r => r.ReturnDate == null);

        // Ustawienie kontekstu danych
        DataContext = new
        {
            LoggedUser = _loggedUser,
            ActiveLoans = activeLoansCount
        };
      
    }

    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }

    
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void btn_Back_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow(_loggedUser);
        mainWindow.Show();
        this.Close();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }

    }
    public void Btn_Change_Pass(Object sender, RoutedEventArgs e)
    {
        var changePasswordWindow = new ChangePasswordWindow(_loggedUser);
        changePasswordWindow.Show();
        this.Close();
    }


}
