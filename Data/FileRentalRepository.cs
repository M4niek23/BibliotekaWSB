
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BibliotekaWSB.Data;

public class FileRentalRepository : IRentalRepository
{
    private string _filePath = "rentals.json";
    private List<Rental> _rentals;

    public FileRentalRepository()
    {
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

    private void Save()
    {
        var json = JsonSerializer.Serialize(_rentals, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void Add(Rental entity)
    {
        _rentals.Add(entity);
        Save();
    }

    public IEnumerable<Rental> GetAll() => _rentals;

    public Rental GetById(int id) => _rentals.FirstOrDefault(r => r.Id == id);

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