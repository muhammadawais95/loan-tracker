using LoanTracker.Models;
using LoanTracker.Services;

namespace LoanTracker.ViewModels;

public class MainViewModel
{
    private IDataService _dataService;

    public MainViewModel()
    {
        
    }

    public string ProfilePhotoSource { get; set; } = "cemahseri";
    public string ProfileName { get; set; } = "cemahseri";
    public string ProfileDetails { get; set; } = "Back-End Developer";

    public int Income { get; set; } = 8900;
    public int Expenses { get; set; } = 5500;
    public int Loan { get; set; } = 890;

    public List<TransactionItem> OverviewItems { get; set; } = new List<TransactionItem>
    {
        new TransactionItem
        {
            IconSource = "arrow_upward",

            Title = "Sent",
            Description = "Sent payment to client.",

            Amount = 150
        },
        new TransactionItem
        {
            IconSource = "arrow_downward",

            Title = "Receive",
            Description = "Received payment from company.",

            Amount = 200
        },
        new TransactionItem
        {
            IconSource = "payments",

            Title = "Loan",
            Description = "Loan for the car.",

            Amount = 100
        },
        new TransactionItem
        {
            IconSource = "arrow_upward",

            Title = "Sent",
            Description = "Sent payment to client.",

            Amount = 150
        },
        new TransactionItem
        {
            IconSource = "arrow_downward",

            Title = "Receive",
            Description = "Received payment from company.",

            Amount = 306
        }
    };
}