﻿

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using BibliotekaWSB.Models;
using BibliotekaWSB.ViewsWPFModel;

namespace BibliotekaWSB.ViewsWPFModel;

public partial class MainWindow : Window
{
    private User _loggedUser;

    public MainWindow(User user)
    {
        InitializeComponent();

        _loggedUser = user;
        this.DataContext = _loggedUser;

    }
    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }


    private void SearchBooks_Click(object sender, RoutedEventArgs e)
    {
        // Tworzenie instancji BookSearchView
        BookSearchView bookSearchView = new BookSearchView(_loggedUser);

        // Ustawienie MainWindow jako zamknięte
        this.Close();

        // Wyświetlenie BookSearchView jako nowego okna
        bookSearchView.Show();

    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
    private void Logout_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindow();
        loginWindow.Show();
        this.Close();
    }

    private void RentalHistoryView_Click(object sender, RoutedEventArgs e)
    {
        var rentalHistoryView = new RentalHistoryView(_loggedUser);
        rentalHistoryView.Show();
        this.Close();
    }
    public void MyAccountView_Click(object sender, RoutedEventArgs e)
    {
        var myAccountView = new MyAccountView(_loggedUser);
        myAccountView.Show();
        this.Close();
    }
}