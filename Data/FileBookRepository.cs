using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System.IO;
using System.Text.Json;

namespace BibliotekaWSB.Data;

public class FileBookRepository : IBookRepository
{
    private string _filePath = "books.json"; // Ścieżka do pliku json z książkami
    private List<Book> _books; // Wewnętrzna lista książek w pamięci

    public FileBookRepository()
    {
        // Wczytanie z pliku JSON lub utworzenie pustej listy
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
        else
        {
            _books = new List<Book>();
            Save();
        }
    }

    private void Save() // Zapisywanie do pliku JSON
    {
        var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void Add(Book entity)
    {
        _books.Add(entity);
        Save();
    }

    public IEnumerable<Book> GetAll() => _books; // Zwraca wszystkie książki

    public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id); // Szuka książki po id

    public void Remove(Book entity)
    {
        _books.Remove(entity);
        Save();
    }

    public IEnumerable<Book> Search(string query)
    {
        // Wyszukiwanie książki po autorze
        return _books.Where(b => b.Title.Contains(query, System.StringComparison.OrdinalIgnoreCase)
                              || b.Author.Contains(query, System.StringComparison.OrdinalIgnoreCase));
    }
}