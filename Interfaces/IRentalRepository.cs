using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;
using System.Collections.Generic;

namespace BibliotekaWSB.Interfaces;

public interface IRentalRepository : IRepository<Rental>
{
    IEnumerable<Rental> GetRentalsByUserId(int userId);
    void Update(Rental rental); // Metoda do aktualizacji wypożyczenia
}