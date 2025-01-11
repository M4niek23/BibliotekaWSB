using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Student : User
{
    public override string Role => "Student"; // Rola użytkownika jest ona domyślna jako "Student"
    public string StudentNumeber { get; set; }
    public Student(int id, string username, string passwordHash, string fullName, string studentNumber, string email = "", string phone = "")
             : base(id, username, passwordHash, fullName, email, phone)
    {
        StudentNumeber = studentNumber;
    }
    public override string GetUserRole()
    {
        return "Student";
    }
}

