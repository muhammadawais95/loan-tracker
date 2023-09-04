﻿using LoanTracker.Services;
using LoanTracker.ViewModels;

namespace LoanTracker.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }
}