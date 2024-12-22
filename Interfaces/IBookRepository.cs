using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaWSB.Models;


namespace BibliotekaWSB.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    IEnumerable<Book> Search(string query);
}
