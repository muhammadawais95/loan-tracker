using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace LoanTracker.Models;

public class Transaction
{
    [BsonId]
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; } 

    public TransactionType Type { get; set; }

    public PaymentMode Mode { get; set; }

    public DateTime Date { get; set; }
}