using System;
using System.Linq;
using System.Windows;
using BibliotekaWSB.Data;
using BibliotekaWSB.Models;

namespace BibliotekaWSB;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        InitializeData();

        Console.WriteLine("Dane zostały wczytane do plików JSON.");
    }

    private void InitializeData()
    {
        InitializeBooks();
        InitializeRentals();
        InitializeUsers();
    }

    private void InitializeBooks()
    {
        var fileRepo = new FileBookRepository();

        // Jeśli plik books.json zawiera dane, pomiń inicjalizację
        if (fileRepo.GetAll().Any())
        {
            Console.WriteLine("Plik books.json już zawiera dane.");
            return;
        }

        var books = new[]
        {
            new Book(1, "Duma i uprzedzenie", "Jane Austen", "Klasyka") { Availability = 7 },
            new Book(2, "Władca Pierścieni", "J.R.R. Tolkien", "Fantastyka") { Availability = 5 },
            new Book(3, "Jane Eyre", "Charlotte Brontë", "Klasyka") { Availability = 3 },
            new Book(4, "Harry Potter (seria)", "J.K. Rowling", "Fantastyka") { Availability = 8 },
            new Book(5, "Zabić drozda", "Harper Lee", "Klasyka") { Availability = 6 },
            new Book(6, "Biblia", "Różni autorzy", "Religia") { Availability = 4 },
            new Book(7, "Wichrowe Wzgórza", "Emily Brontë", "Klasyka") { Availability = 2 },
            new Book(8, "Rok 1984", "George Orwell", "Science Fiction") { Availability = 9 },
            new Book(9, "Mroczne materie (seria)", "Philip Pullman", "Fantastyka") { Availability = 1 },
            new Book(10, "Wielkie nadzieje", "Charles Dickens", "Klasyka") { Availability = 10 },
            new Book(11, "Małe kobietki", "Louisa May Alcott", "Klasyka") { Availability = 7 },
            new Book(12, "Tessa D’Urberville", "Thomas Hardy", "Klasyka") { Availability = 5 },
            new Book(13, "Paragraf 22", "Joseph Heller", "Satyria") { Availability = 3 },
            new Book(14, "Dzieła zebrane Szekspira", "William Shakespeare", "Dramat") { Availability = 8 },
            new Book(15, "Rebeka", "Daphne Du Maurier", "Kryminał") { Availability = 6 },
            new Book(16, "Hobbit", "J.R.R. Tolkien", "Fantastyka") { Availability = 4 },
            new Book(17, "Ptasi śpiew", "Sebastian Faulks", "Historyczna") { Availability = 2 },
            new Book(18, "Buszujący w zbożu", "J.D. Salinger", "Klasyka") { Availability = 9 },
            new Book(19, "Żona podróżnika w czasie", "Audrey Niffenegger", "Romans") { Availability = 1 },
            new Book(20, "Miasteczko Middlemarch", "George Eliot", "Klasyka") { Availability = 10 },
            new Book(21, "Przeminęło z wiatrem", "Margaret Mitchell", "Romans") { Availability = 7 },
            new Book(22, "Wielki Gatsby", "F. Scott Fitzgerald", "Klasyka") { Availability = 5 },
            new Book(23, "Samotnia", "Charles Dickens", "Klasyka") { Availability = 3 },
            new Book(24, "Wojna i pokój", "Lew Tołstoj", "Klasyka") { Availability = 8 },
            new Book(25, "Autostopem przez Galaktykę", "Douglas Adams", "Science Fiction") { Availability = 6 },
            new Book(26, "Znowu w Brideshead", "Evelyn Waugh", "Obyczajowa") { Availability = 4 },
            new Book(27, "Zbrodnia i kara", "Fiodor Dostojewski", "Klasyka") { Availability = 2 },
            new Book(28, "Grona gniewu", "John Steinbeck", "Klasyka") { Availability = 9 },
            new Book(29, "Alicja w Krainie Czarów", "Lewis Carroll", "Fantastyka") { Availability = 1 },
            new Book(30, "O czym szumią wierzby", "Kenneth Grahame", "Klasyka") { Availability = 10 },
        };

        foreach (var book in books)
        {
            fileRepo.Add(book);
        }

        Console.WriteLine("Dane książek zostały zapisane do books.json.");
    }

    private void InitializeRentals()
    {
        var fileRepo = new FileRentalRepository();

        // Jeśli plik rentals.json zawiera dane, pomiń inicjalizację
        if (fileRepo.GetAll().Any())
        {
            Console.WriteLine("Plik rentals.json już zawiera dane.");
            return;
        }

        var rentals = new[]
        {
            new Rental(1, 1, 1, DateTime.Now.AddDays(-10), null), // Aktywne wypożyczenie
            new Rental(2, 2, 1, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5)), // Zwrócone
            new Rental(3, 3, 2, DateTime.Now.AddDays(-15), null) // Aktywne wypożyczenie
        };

        foreach (var rental in rentals)
        {
            fileRepo.Add(rental);
        }

        Console.WriteLine("Dane wypożyczeń zostały zapisane do rentals.json.");
    }

    private void InitializeUsers()
    {
        var fileRepo = new FileUserRepository();

        // Jeśli plik users.json zawiera dane, pomiń inicjalizację
        if (fileRepo.GetAll().Any())
        {
            Console.WriteLine("Plik users.json już zawiera dane.");
            return;
        }

        var users = new User[]
        {
            new Student(1, "jan.kowalski", "pass123", "Jan Kowalski", "S12345", "jan.kowalski@example.com", "123456789"),
            new Staff(2, "anna.nowak", "admin123", "Anna Nowak", "anna.nowak@example.com", "987654321", "Bibliotekarz")
        };

        foreach (var user in users)
        {
            fileRepo.Add(user);
        }

        Console.WriteLine("Dane użytkowników zostały zapisane do users.json.");
    }
}