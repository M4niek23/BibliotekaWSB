
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System;
using System.Linq;

namespace BibliotekaWSB.Services;

public class RentalService
{
    private IBookRepository _bookRepository;
    private IRentalRepository _rentalRepository;

    public RentalService(IBookRepository bookRepository, IRentalRepository rentalRepository)
    {
        _bookRepository = bookRepository;
        _rentalRepository = rentalRepository;
    }

    public bool CanRentBook(User user, Book book)
    {
        // Sprawdź czy użytkownik ma mniej niż 5 aktywnych wypożyczeń
        var userRentals = _rentalRepository.GetRentalsByUserId(user.Id)
            .Where(r => r.ReturnDate == null);
        if (userRentals.Count() >= 5)
            return false;

        // Sprawdź czy użytkownik już ma tę książkę wypożyczoną i jej nie oddał
        if (userRentals.Any(r => r.BookId == book.Id))
            return false;

        // Sprawdź dostępność książki
        if (book.Availability <= 0)
            return false;

        return true;
    }



    public IEnumerable<RentalViewModel> GetUserRentals(User user)
    {
        var rentals = _rentalRepository.GetRentalsByUserId(user.Id);

        return rentals.Select(r =>
        {
            var book = _bookRepository.GetById(r.BookId);
            return new RentalViewModel
            {
                RentalId = r.Id,
                BookTitle = book?.Title,
                RentalDate = r.RentalDate,
                ReturnDate = r.ReturnDate
            };
        });
    }

    public Rental GetRentalById(int id)
    {
        return _rentalRepository.GetById(id);
    }

    public bool RentBook(User user, Book book)
    {
        if (CanRentBook(user, book))
        {
            book.Availability--;
            _bookRepository.Remove(book);
            _bookRepository.Add(book);

            var rental = new Rental(
                id: NewRentalId(),
                bookId: book.Id,
                userId: user.Id,
                rentalDate: DateTime.Now,
                returnDate: null
            );
            _rentalRepository.Add(rental);
            return true;
        }
        return false;
    }

    public void ReturnBook(Rental rental)
    {

        rental.ReturnDate = DateTime.Now;
        _rentalRepository.Update(rental);
        var book = _bookRepository.GetById(rental.BookId);
        if (book != null)
        {
            book.Availability++;
            _bookRepository.Remove(book);
            _bookRepository.Add(book);
        }
    }

    private int NewRentalId()
    {
        var all = _rentalRepository.GetAll();
        if (!all.Any()) return 1;
        return all.Max(r => r.Id) + 1;
    }
}