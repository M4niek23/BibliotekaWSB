using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public abstract class User
{
    private string password;

    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime LastLogin { get; set; }

    public abstract string Role { get; } // Dodane!

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

    public bool VerifyPassword(string password)
    {
        return PasswordHash == password;
    }
    public abstract string GetUserRole();
}