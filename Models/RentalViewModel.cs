using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class RentalViewModel
{
    public int RentalId { get; set; } // Id wypożyczenia
    public string BookTitle { get; set; } // Nazwa książki
    public DateTime? RentalDate { get; set; } // Data wypożyczenia
    public DateTime? ReturnDate { get; set; } // Data zwrotu
}
