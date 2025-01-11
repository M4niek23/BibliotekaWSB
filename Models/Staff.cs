using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Staff : User
{
    public override string Role => "Staff"; // Rola uytkownika typu "Staff", czyli Admin
    public string Position { get; set; }
    public Staff(int id, string username, string passwordHash, string fullName, string email = "", string phone = "", string position = "")
        : base(id, username, passwordHash, fullName, email, phone)
    {
        Position = position;
    }
    public override string GetUserRole()
    {
        return "Staff";
    }
}

