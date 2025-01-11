using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Rental
{
    public int Id { get; set; } // Id wypożyczenia
    public int BookId { get; set; } // ID książki
    public int UserId { get; set; } // Id użytkownika
    public DateTime RentalDate { get; set; } // Data wypożyczenia
    public DateTime? ReturnDate { get; set; } // Data zwrotu
    public Rental(int id, int bookId, int userId, DateTime rentalDate, DateTime? returnDate)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        RentalDate = rentalDate;
        ReturnDate = returnDate;
    }
}