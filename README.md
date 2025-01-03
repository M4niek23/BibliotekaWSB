Biblioteka WSB - temat projektu
Projekt Biblioteka WSB to prosta aplikacja typu desktop (WPF) realizaująca podsatawowe funkcje systemu bibliotecznego, tj. zarządzanie książkami, użytkownikiem oraz wypożyczeniami.

**Struktura projektu**
  Projekt składa się z następujących folderów i plików źródłowych:
    1. Data – zawiera implementacje repozytoriów bazujących na zapisie i odczycie z plików JSON:
      1.1 FileBookRepository.cs
      1.2 FileRentalRepository.cs
      1.3 FileUserRepository.cs
    2.Interfaces – zawiera interfejsy definiujące kontrakty dla repozytoriów i serwisów:
      2.1 IRepository<T>.cs
      2.2 IBookRepository.cs
      2.3 IRentalRepository.cs
      2.4 IUserRepository.cs
    3.Models – zawiera klasy modelowe reprezentujące encje w systemie:
      3.1 Book.cs
      3.2 Rental.cs
      3.3 RentalViewModel.cs
      3.4 Student.cs
      3.5 Staff.cs
      3.6 User.cs
    4. Services – zawiera logikę biznesową aplikacji:
      4.1 AuthenticationService.cs
      4.2 BookService.cs
      4.3 RentalService.cs
      4.4 UserService.cs
    5.ViewsWPFModel – zawiera warstwę prezentacji (WPF):
      Główne okna:
      5.1 LoginWindow.xaml / .cs
      5.2 MainWindow.xaml / .cs
      5.3 RegisterWindow.xaml / .cs
      Dodatkowe widoki:
      5.4 BookSearchView.xaml / .cs
      5.5 ForgotPasswordWindow.xaml / .cs
      5.6 ChangePasswordWindow.xaml / .cs
      5.7 MyAccountView.xaml / .cs
      5.8 RentalHistoryView.xaml / .cs
**Opis działania**
  
  Logowanie:
    Użytkownik wprowadza dane logowania (login i hasło) w oknie LoginWindow.
    Następuje weryfikacja w klasie AuthenticationService, która łączy się z repozytorium użytkowników (FileUserRepository).
    Jeśli dane są poprawne, użytkownik zostaje przekierowany do głównego okna (MainWindow).
  
  Rejestracja:
    W oknie RegisterWindow użytkownik podaje podstawowe dane konta (nazwa użytkownika, hasło, imię i nazwisko, email itp.).
    System sprawdza, czy dana nazwa użytkownika już istnieje w bazie (pliku JSON).
    Nowy użytkownik (domyślnie typu Student) zapisywany jest w users.json.
  
  Zarządzanie książkami:
    Książki przechowywane są w books.json.
    Za pomocą FileBookRepository można dodawać/usuwać książki (logika do integracji w razie potrzeby).
    W aplikacji wizualnej użytkownicy mogą wyszukiwać książki w oknie BookSearchView.
  
  Wypożyczanie:
    Po zalogowaniu, w widoku wyszukiwania książek BookSearchView dostępny jest przycisk Wypożycz.
    Sprawdzane są reguły:
    Limit 5 wypożyczeń naraz.
    Sprawdzenie, czy książka jest dostępna (jej pole Availability > 0).
    Jeśli wypożyczenie jest możliwe, stan dostępności książki się zmniejsza, a nowy wpis ląduje w rentals.json.
    Zwrot książek

  Widok historii wypożyczeń (RentalHistoryView) pokazuje listę wszystkich wypożyczeń użytkownika.
    Jeżeli książka jest nadal w posiadaniu użytkownika (brak daty zwrotu), można kliknąć przycisk Zwróć, a system ustawi datę zwrotu w danym Rental oraz zwiększy dostępność książki w repozytorium.
  
  Moje konto
    Widok MyAccountView pokazuje podstawowe dane użytkownika i liczbę aktywnych wypożyczeń.
    Z tego poziomu możliwa jest zmiana hasła, usunięcie konta lub wylogowanie.



**Uruchomienie aplikacji**
  Klonowanie / pobranie repozytorium
  Sklonuj repozytorium z systemu kontroli wersji (np. Git) lub pobierz paczkę ZIP.

  Otwórz projekt
  Otwórz rozwiązanie w Visual Studio (lub innym IDE obsługującym .NET 6.0+ i WPF).

  Zbuduj projekt

  Upewnij się, że masz włączony tryb Debug (lub Release).
  Uruchom Build Solution (skrót klawiszowy: Ctrl + Shift + B w VS).
  Uruchom aplikację

  Ustaw projekt startowy (jeśli jest taka potrzeba).
  Uruchom (F5 albo przycisk Start w Visual Studio).
  Powinno otworzyć się okno logowania (LoginWindow).
  Po pierwszym uruchomieniu

  W folderze głównym aplikacji (lub w katalogu roboczym) utworzą się pliki:
  users.json, books.json, rentals.json – jeśli ich nie było wcześniej.
  Możesz się zalogować na istniejące konto (jeśli takie jest w pliku users.json) lub zarejestrować nowe.


**Główne funkcjonalności**
  1. Logowanie i wylogowanie użytkownika.
  2. Rejestracja nowych użytkowników (domyślnie jako Student).
  3. Wyszukiwanie książek (BookSearchView).
  4. Wypożyczanie i zwrot książek (RentalService).
  5. Podgląd historii wypożyczeń i statusu książek (RentalHistoryView).
  6. Zmiana hasła w widoku ChangePasswordWindow.
  7. Usuwanie konta użytkownika w widoku MyAccountView
     
**Pliki konfiguracyjne i baza danych (pliki JSON)**
  users.json:
  Przechowuje listę obiektów UserDto (w praktyce Student lub Staff).

  books.json:
  Zawiera listę obiektów klasy Book, np. z polami Id, Title, Author, Category, Availability.

  rentals.json:
  Przechowuje listę obiektów Rental z informacjami o aktualnie wypożyczonych książkach oraz historią zwrotów (pole ReturnDate).

  Mechanizm serializacji: System.Text.Json i klasa JsonSerializer.
  
**Autor**
  Kod i struktura projektu: Patryk Mańka 
  Projekt realizowany na poczęt zajęć programowanie obiektowe
