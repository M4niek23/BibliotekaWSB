using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Rental
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Rental(int id, int bookId, int userId, DateTime rentalDate, DateTime? returnDate)
    {
        Id = id;
        BookId = bookId;
        UserId = userId;
        RentalDate = rentalDate;
        ReturnDate = returnDate;
    }
}