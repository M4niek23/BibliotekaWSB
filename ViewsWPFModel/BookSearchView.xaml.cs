using BibliotekaWSB.Data;
using BibliotekaWSB.Models;
using BibliotekaWSB.Services;
using BibliotekaWSB;
using System.Windows;
using System.Windows.Controls;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class BookSearchView : Window
{
    private readonly User _loggedUser;
    private readonly BookService _bookService;
    private readonly RentalService _rentalService;

    public BookSearchView(User user)
    {
        InitializeComponent();
        _loggedUser = user;

        var bookRepository = new FileBookRepository();
        var rentalRepository = new FileRentalRepository();

        _bookService = new BookService(bookRepository);
        _rentalService = new RentalService(bookRepository, rentalRepository);

        BookList.ItemsSource = _bookService.GetAll();
        var allBooks = _bookService.GetAll();

    }

    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        var query = SearchBox.Text;
        BookList.ItemsSource = _bookService.SearchBooks(query);
    }

    private void RentBook_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Book book)
        {
            if (_rentalService.RentBook(_loggedUser, book))
            {
                MessageBox.Show($"Wypożyczono książkę: {book.Title}");
                BookList.ItemsSource = _bookService.GetAll();
            }
            else
            {
                MessageBox.Show("Nie można wypożyczyć tej książki.");
            }
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

}
