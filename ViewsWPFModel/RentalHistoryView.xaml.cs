
using BibliotekaWSB.Data;
using BibliotekaWSB.Models;
using BibliotekaWSB.Services;
using BibliotekaWSB.ViewsWPFModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class RentalHistoryView : Window
{
    private readonly User _loggedUser;
    private readonly RentalService _rentalService;

    public RentalHistoryView(User user)
    {
        InitializeComponent();
        _loggedUser = user;

        var bookRepository = new FileBookRepository();
        var rentalRepository = new FileRentalRepository();
        _rentalService = new RentalService(bookRepository, rentalRepository);

        LoadRentals();
    }

    private void LoadRentals()
    {
        var rentals = _rentalService.GetUserRentals(_loggedUser);
        RentalList.ItemsSource = rentals; // Lista RentalViewModel
    }

    private void ReturnBook_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is RentalViewModel rentalVM)
        {
            var rental = _rentalService.GetRentalById(rentalVM.RentalId);
            if (rental != null)
            {
                _rentalService.ReturnBook(rental);
                LoadRentals(); // Odświeżenie listy po zwrocie
            }
        }
    }
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    private void btn_Back_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow(_loggedUser);
        mainWindow.Show();
        Close();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void RentalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
