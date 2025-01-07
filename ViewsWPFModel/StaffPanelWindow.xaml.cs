using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BibliotekaWSB.Data;
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.ViewsWPFModel
{
    public partial class StaffPanelWindow : Window
    {
        private User _loggedUser;
        private IBookRepository _bookRepository;
        private IRentalRepository _rentalRepository;
        private IUserRepository _userRepository;

        public StaffPanelWindow(User user)
        {
            InitializeComponent(); // MUSI być wywołane

            _loggedUser = user;
            _bookRepository = new FileBookRepository();
            _rentalRepository = new FileRentalRepository();
            _userRepository = new FileUserRepository();

            LoadAllRentals();
            LoadAllBooks();
        }

        public StaffPanelWindow() : this(null)
        {
        }

        private class StaffRentalViewModel
        {
            public int Id { get; set; }
            public string BookTitle { get; set; }
            public string Username { get; set; }
            public DateTime RentalDate { get; set; }
            public DateTime? ReturnDate { get; set; }
        }

        private void LoadAllRentals()
        {
            var allRentals = _rentalRepository.GetAll();
            var rentalsView = allRentals.Select(r =>
            {
                var book = _bookRepository.GetById(r.BookId);
                var user = _userRepository.GetById(r.UserId);

                return new StaffRentalViewModel
                {
                    Id = r.Id,
                    BookTitle = book?.Title ?? "(brak tytułu)",
                    Username = user?.Username ?? "(brak użytkownika)",
                    RentalDate = r.RentalDate,
                    ReturnDate = r.ReturnDate
                };
            }).ToList();

            AllRentalsList.ItemsSource = rentalsView;
        }

        private void LoadAllBooks()
        {
            BooksList.ItemsSource = _bookRepository.GetAll();
        }

        private void btnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Book book)
            {
                // (Opcjonalnie) sprawdź, czy nie jest wypożyczona itp.
                _bookRepository.Remove(book);
                MessageBox.Show($"Usunięto książkę: {book.Title}");
                LoadAllBooks();
            }
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow();
            bool? result = addBookWindow.ShowDialog();

            if (result == true)
            {
                LoadAllBooks();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow(_loggedUser);
            MainWindow.Show();
            this.Close();
        }
    }
}
