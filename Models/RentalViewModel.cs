using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class RentalViewModel
{
    public int RentalId { get; set; }
    public string BookTitle { get; set; }
    public DateTime? RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
