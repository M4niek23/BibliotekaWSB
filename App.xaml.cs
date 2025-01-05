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
    new Book(1, "Duma i uprzedzenie", "Jane Austen", "Klasyka")
    {
        Availability = 7,
        Description = "Historia miłości Elizabeth Bennet i pana Darcy'ego, pełna humoru i społecznych komentarzy na temat angielskiej arystokracji końca XVIII wieku."

    },
    new Book(2, "Władca Pierścieni", "J.R.R. Tolkien", "Fantastyka")
    {
        Availability = 5,
        Description = "Epicka saga o przygodach Froda Bagginsa i Drużyny Pierścienia w walce z mrocznym lordem Sauronem, który pragnie odzyskać potężny Pierścień."
    },
    new Book(3, "Jane Eyre", "Charlotte Brontë", "Klasyka")
    {
        Availability = 3,
        Description = "Autobiograficzna powieść o losach niezależnej i silnej kobiety, która stawia czoła przeciwnościom losu i poszukuje miłości oraz tożsamości."
    },
    new Book(4, "Harry Potter (seria)", "J.K. Rowling", "Fantastyka")
    {
        Availability = 8,
        Description = "Przygody młodego czarodzieja Harry'ego Pottera, który uczęszcza do Szkoły Magii i Czarodziejstwa w Hogwarcie, walcząc ze złymi siłami."
    },
    new Book(5, "Zabić drozda", "Harper Lee", "Klasyka")
    {
        Availability = 6,
        Description = "Poruszająca opowieść o rasizmie i niesprawiedliwości w małym miasteczku na południu USA, opowiedziana oczami młodej dziewczyny Scout."
    },
    new Book(6, "Biblia", "Różni autorzy", "Religia")
    {
        Availability = 4,
        Description = "Święta księga chrześcijaństwa, zawierająca Stary i Nowy Testament, będąca fundamentem wiary i moralności dla miliardów ludzi na świecie."
    },
    new Book(7, "Wichrowe Wzgórza", "Emily Brontë", "Klasyka")
    {
        Availability = 2,
        Description = "Mroczna i pasjonująca historia miłosna między Catherine Earnshaw a Heathcliffem, pełna namiętności, zemsty i tragiczych losów."
    },
    new Book(8, "Rok 1984", "George Orwell", "Science Fiction")
    {
        Availability = 9,
        Description = "Dystopijna wizja przyszłości, w której totalitarny rząd kontroluje każdy aspekt życia obywateli, eliminując wolność i prywatność."
    },
    new Book(9, "Mroczne materie (seria)", "Philip Pullman", "Fantastyka")
    {
        Availability = 1,
        Description = "Trilogia fantasy śledząca losy Lyry Belacqua w jej podróżach przez równoległe światy, walczącej przeciwko autorytarnym siłom."
    },
    new Book(10, "Wielkie nadzieje", "Charles Dickens", "Klasyka")
    {
        Availability = 10,
        Description = "Opowieść o młodym Pipie, jego marzeniach, miłości i moralnych wyborach w skomplikowanym świecie wiktoriańskiej Anglii."
    },
    new Book(11, "Małe kobietki", "Louisa May Alcott", "Klasyka")
    {
        Availability = 7,
        Description = "Historia czterech sióstr March, ich dorastania, marzeń i wyzwań w czasie wojny secesyjnej w Ameryce."
    },
    new Book(12, "Tessa D’Urberville", "Thomas Hardy", "Klasyka")
    {
        Availability = 5,
        Description = "Tragiczna historia miłosna Tess Durbeyfield, jej walki z przeznaczeniem i społecznymi normami w XIX-wiecznej Anglii."
    },
    new Book(13, "Paragraf 22", "Joseph Heller", "Satyria")
    {
        Availability = 3,
        Description = "Ironiczna i absurdalna satyra na biurokrację wojskową oraz nonsensy wojny, opowiedziana z perspektywy amerykańskiego żołnierza."
    },
    new Book(14, "Dzieła zebrane Szekspira", "William Shakespeare", "Dramat")
    {
        Availability = 8,
        Description = "Kompletna kolekcja dramatów, sonetów i poematów autorstwa jednego z największych dramaturgów w historii literatury."
    },
    new Book(15, "Rebeka", "Daphne Du Maurier", "Kryminał")
    {
        Availability = 6,
        Description = "Psychologiczny thriller o młodej kobiecie, która poślubia bogatego wdowca, tylko po to, by zmierzyć się z tajemnicami przeszłości jego pierwszej żony."
    },
    new Book(16, "Hobbit", "J.R.R. Tolkien", "Fantastyka")
    {
        Availability = 4,
        Description = "Przygoda Bilbo Bagginsa, hobbita, który wyrusza na niebezpieczną wyprawę z grupą krasnoludów, by odzyskać skarb strzeżony przez smoka Smauga."
    },
    new Book(17, "Ptasi śpiew", "Sebastian Faulks", "Historyczna")
    {
        Availability = 2,
        Description = "Wielowątkowa historia osadzona w czasie I wojny światowej, ukazująca losy różnych postaci na tle historycznych wydarzeń."
    },
    new Book(18, "Buszujący w zbożu", "J.D. Salinger", "Klasyka")
    {
        Availability = 9,
        Description = "Opowieść o młodym Holdenzie Caulfieldzie, który po wyrzuceniu ze szkoły wyrusza na samotną wędrówkę po Nowym Jorku, szukając sensu życia."
    },
    new Book(19, "Żona podróżnika w czasie", "Audrey Niffenegger", "Romans")
    {
        Availability = 1,
        Description = "Nieszablonowa historia miłosna o Clare i Henrym, którzy muszą zmagać się z nieprzewidywalnymi podróżami w czasie Henry'ego."
    },
    new Book(20, "Miasteczko Middlemarch", "George Eliot", "Klasyka")
    {
        Availability = 10,
        Description = "Rozbudowana powieść społeczna przedstawiająca życie mieszkańców fikcyjnego miasteczka Middlemarch, ich ambicje i konflikty."
    },
    new Book(21, "Przeminęło z wiatrem", "Margaret Mitchell", "Romans")
    {
        Availability = 7,
        Description = "Epicka opowieść o Scarlett O'Hara, jej życiu podczas wojny secesyjnej i odbudowie Południa, pełna miłości, strat i determinacji."
    },
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