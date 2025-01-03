# Biblioteka WSB

Projekt **Biblioteka WSB** to prosta aplikacja typu desktop (WPF) realizująca podstawowe funkcje systemu bibliotecznego, tj. zarządzanie użytkownikami, książkami oraz wypożyczeniami.

---

## Spis treści

1. [Wymagania](#wymagania)  
2. [Struktura projektu](#struktura-projektu)  
3. [Opis działania](#opis-działania)  
4. [Uruchomienie aplikacji](#uruchomienie-aplikacji)  
5. [Główne funkcjonalności](#główne-funkcjonalności)  
6. [Pliki konfiguracyjne i baza danych (pliki JSON)](#pliki-konfiguracyjne-i-baza-danych-pliki-json)  
7. [Rozbudowa aplikacji](#rozbudowa-aplikacji)  
8. [Autorzy](#autorzy)  

---

## Wymagania

- **.NET 6.0 lub nowszy** – projekt napisany w C# z wykorzystaniem WPF i serializacji JSON.
- **Microsoft Visual Studio 2022** (lub inny kompatybilny IDE).
- System **Windows** 
- Opcjonalnie: znajomość mechanizmu serializacji wbudowanego w **System.Text.Json**.

---

## Struktura projektu

1. **Data** – Repozytoria zapisujące dane w plikach JSON.
2. **Interfaces** – Definicje interfejsów (m.in. `IRepository<T>`).
3. **Models** – Klasy reprezentujące encje (Książka, Użytkownik, Wypożyczenie itp.).
4. **Services** – Logika biznesowa (m.in. `AuthenticationService`, `BookService`).
5. **ViewsWPFModel** – Warstwa prezentacji WPF (okna `*.xaml` i obsługa zdarzeń w `.cs`).

---

## Opis działania

1. **Logowanie**  
   - Okno `LoginWindow` pobiera od użytkownika login i hasło.  
   - Klasa `AuthenticationService` sprawdza poprawność danych w pliku `users.json` (poprzez `FileUserRepository`).
   - Jeśli dane są prawidłowe, otwiera się główne okno (`MainWindow`).

2. **Rejestracja**  
   - W `RegisterWindow` użytkownik podaje podstawowe dane.  
   - System sprawdza, czy nazwa użytkownika już istnieje.  
   - Tworzony jest obiekt `Student` (domyślny typ) i zapisywany w `users.json`.

3. **Zarządzanie książkami**  
   - Dane książek są w `books.json`.  
   - W `BookSearchView` można je przeszukiwać i wypożyczać.

4. **Wypożyczanie**  
   - Przy każdym wypożyczeniu aktualizowany jest stan dostępności w `Book`.  
   - Tworzony jest wpis w `rentals.json` (klasa `Rental`).

5. **Zwrot**  
   - Widok `RentalHistoryView` pozwala oznaczyć książkę jako zwróconą (`ReturnDate != null`).  
   - Dostępność książki w repozytorium (`books.json`) zwiększa się o 1.

6. **Moje konto**  
   - Okno `MyAccountView` pokazuje dane zalogowanego użytkownika, liczbę aktywnych wypożyczeń i opcje (zmiana hasła / usunięcie konta).

---

## Uruchomienie aplikacji

1. Sklonuj lub pobierz projekt z repozytorium.
2. Otwórz rozwiązanie w Visual Studio 2022 (lub innym IDE wspierającym .NET 6 i WPF).
3. Upewnij się, że masz włączony tryb **Debug** lub **Release**, a następnie zbuduj projekt (`Ctrl + Shift + B`).
4. Uruchom aplikację (F5 lub przycisk _Start_).

   **Po uruchomieniu** w katalogu roboczym pojawią się pliki:
   - `users.json`
   - `books.json`
   - `rentals.json`  
   Jeśli nie istnieją, zostaną utworzone automatycznie.

---

## Główne funkcjonalności

- **Logowanie** / **Wylogowanie** (okno `LoginWindow`).
- **Rejestracja** użytkownika (domyślnie `Student`).
- **Wyszukiwarka** książek (`BookSearchView`).
- **Wypożyczanie** i **zwrot** książek (`RentalService`).
- **Historia** wypożyczeń (`RentalHistoryView`).
- **Zmiana hasła** (`ChangePasswordWindow`).
- **Usuwanie konta** w widoku `MyAccountView`.

---

## Pliki konfiguracyjne i baza danych (pliki JSON)

- **`users.json`**:  
  Przechowuje użytkowników z kluczami: `Id`, `Username`, `PasswordHash`, `Role`, `Email`, `Phone` itp.

- **`books.json`**:  
  Książki z polami `Id`, `Title`, `Author`, `Category`, `Availability`.

- **`rentals.json`**:  
  Wypożyczenia z `Id`, `BookId`, `UserId`, `RentalDate`, `ReturnDate`.

**Serializacja** opiera się na `System.Text.Json`.  

---

## Rozbudowa aplikacji

- **Nowe widoki**: wystarczy dodać pliki `.xaml` i obsługę w `.cs`.
- **Nowe pola** w modelach: można zaktualizować struktury `Book`, `Rental`, `Student`.
- **Baza SQL**: wystarczy zaimplementować własne repozytoria i zastąpić obecne `FileXRepository`.

---

## Autorzy

- Kod powstał w ramach programowanie obiektowe ćwiczenia  
- Autor: **Patryk Mańka**

Dziękujemy za skorzystanie z **Biblioteka WSB**!  
