using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public abstract class User
{
    private string password; // Nie używane bezpośrednio ( jest PasswordHash )

    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; } // Przechowuje hasło lub jego skrót jako zaszyforwane
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime LastLogin { get; set; }

    // Właściwość abstrakcyjna – wymusza zdefiniowanie 'Role' w klasach pochodnych
    public abstract string Role { get; } 

    public User(int id, string username, string passwordHash, string fullName, string email = "", string phone = "")
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
        FullName = fullName;
        Email = email;
        Phone = phone;

    }

    public string UserRole => GetUserRole();
    protected User(int id, string username, string password)
    {
        Id = id;
        Username = username;
        this.password = password;


    }

    // Przykład enkapsulacji – prosta weryfikacja hasła
    public bool VerifyPassword(string password)
    {

        return PasswordHash == password;
    }
    // Przykład metody abstrakcyjnej (musi być zaimplementowana w klasach dziedziczących)
    public abstract string GetUserRole();
}