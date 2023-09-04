using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace LoanTracker.Models;

public class Person
{
    [BsonId]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }

    public decimal Payable => Transactions.Where(x => x.Type == TransactionType.Credit).Sum(x => x.Amount);

    public decimal Receivable => Transactions.Where(x => x.Type == TransactionType.Debit).Sum(x => x.Amount);

    public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
}