using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaWSB.Interfaces;
using BibliotekaWSB.Models;

namespace BibliotekaWSB.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User GetByUsername(string username);

}
