
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.Services;

public class BookService
{
    private IBookRepository _bookRepository; // Repozytorium książek
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public IEnumerable<Book> Search(string query)
    {
        return _bookRepository.Search(query);
    }
    public IEnumerable<Book> GetAll()
    {
        return _bookRepository.GetAll();
    }

    public IEnumerable<Book> SearchBooks(string query)
    {
        // Szukanie książek po tytule lub autorze
        var books = _bookRepository.GetAll();
        return books.Where(b =>
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
