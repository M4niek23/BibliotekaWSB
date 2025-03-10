﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWSB.Models;

public class Book
{
    public int Id { get; private set; } // Id ksiązki 
    public string Title { get; set; } // Tytuł książki
    public string Author { get; set; } // Autor książki
    public int Availability { get; set; } // Liczba dostępnych egzemplarzy

    public string Category { get; set; } // Kategoria książki

    public string Description { get; set; } // Opis książki




    public Book(int id, string title, string author, string category)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;

    }

}