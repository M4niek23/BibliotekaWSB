using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaWSB.Models;
using System.Windows;

namespace BibliotekaWSB.ViewsWPFModel
{
    public partial class BookDetailsWindow : Window
    {
        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            this.DataContext = book;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

