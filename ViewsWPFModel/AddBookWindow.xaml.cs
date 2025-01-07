using System;
using System.Linq;
using System.Windows;
using BibliotekaWSB.Data;
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.ViewsWPFModel
{
    public partial class AddBookWindow : Window
    {
        private IBookRepository _bookRepository;

        public AddBookWindow()
        {
            InitializeComponent(); // musi być wywołane
            _bookRepository = new FileBookRepository();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text) ||
                string.IsNullOrWhiteSpace(AuthorBox.Text) ||
                string.IsNullOrWhiteSpace(CategoryBox.Text))
            {
                MessageBox.Show("Uzupełnij tytuł, autora i kategorię.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(AvailabilityBox.Text, out int availability))
            {
                MessageBox.Show("Niepoprawna dostępność. Wpisz liczbę całkowitą.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Wygeneruj ID: 
            var allBooks = _bookRepository.GetAll();
            int newId = allBooks.Any() ? allBooks.Max(b => b.Id) + 1 : 1;

            var newBook = new Book(newId, TitleBox.Text, AuthorBox.Text, CategoryBox.Text)
            {
                Availability = availability,
                Description = DescriptionBox.Text
            };

            _bookRepository.Add(newBook);
            MessageBox.Show("Książka została dodana pomyślnie!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            // Ustawiamy DialogResult na true => StaffPanelWindow zobaczy, że się udało
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
