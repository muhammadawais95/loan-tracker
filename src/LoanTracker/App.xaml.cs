using LoanTracker.Views;

namespace LoanTracker;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }
}