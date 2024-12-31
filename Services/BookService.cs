
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Services;

public class BookService
{
    private IBookRepository _bookRepository;
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
        var books = _bookRepository.GetAll();
        return books.Where(b =>
            b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            b.Author.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
