using LoanTracker.Helpers;

namespace LoanTracker.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public string Path => PlatformHelper.GetApplicationPath();
}
