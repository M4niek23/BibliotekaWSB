
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BibliotekaWSB.Data;

public class FileRentalRepository : IRentalRepository
{
    private string _filePath = "rentals.json"; // Ścieżka do pliku json z książkami
    private List<Rental> _rentals; // Wewnętrzna lista wypożyczeń w pamięci

    public FileRentalRepository()
    {
        // Inicjalizacja z pliku JSON lub pustej listy
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _rentals = JsonSerializer.Deserialize<List<Rental>>(json) ?? new List<Rental>();
        }
        else
        {
            _rentals = new List<Rental>();
            Save();
        }
    }

    private void Save() // Zapis do pliku rentals.json
    {
        var json = JsonSerializer.Serialize(_rentals, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void Add(Rental entity)
    {
        _rentals.Add(entity);
        Save();
    }

    public IEnumerable<Rental> GetAll() => _rentals; // Zwraca wszystkie wypożyczenia


    public Rental GetById(int id) => _rentals.FirstOrDefault(r => r.Id == id); // Szukanie wypożyczenia po id

    public void Remove(Rental entity)
    {
        _rentals.Remove(entity);
        Save();
    }

    public IEnumerable<Rental> GetRentalsByUserId(int userId)
    {
        return _rentals.Where(r => r.UserId == userId);
    }

    public void Update(Rental rental)
    {
        // Aktualizacja istniejącego wypożyczenia
        var existing = GetById(rental.Id);
        if (existing != null)
        {
            existing.BookId = rental.BookId;
            existing.UserId = rental.UserId;
            existing.RentalDate = rental.RentalDate;
            existing.ReturnDate = rental.ReturnDate;
            Save();
        }
    }
}