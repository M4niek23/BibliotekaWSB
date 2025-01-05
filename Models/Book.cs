using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Availability { get; set; }

    public string Category { get; set; }

    public string Description { get; set; } 




    public Book(int id, string title, string author, string category)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;

    }

}