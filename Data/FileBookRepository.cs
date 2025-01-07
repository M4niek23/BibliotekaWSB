using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System.IO;
using System.Text.Json;

namespace BibliotekaWSB.Data;

public class FileBookRepository : IBookRepository
{
    private string _filePath = "books.json";
    private List<Book> _books;

    public FileBookRepository()
    {
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

    private void Save()
    {
        var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void Add(Book entity)
    {
        _books.Add(entity);
        Save();
    }

    public IEnumerable<Book> GetAll() => _books;

    public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Remove(Book entity)
    {
        _books.Remove(entity);
        Save();
    }

    public IEnumerable<Book> Search(string query)
    {
        return _books.Where(b => b.Title.Contains(query, System.StringComparison.OrdinalIgnoreCase)
                              || b.Author.Contains(query, System.StringComparison.OrdinalIgnoreCase));
    }
}