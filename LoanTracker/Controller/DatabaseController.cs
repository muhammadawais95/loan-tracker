using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using LoanTracker.Models;

namespace LoanTracker.Controllers;

public class DatabaseController
{
    private const string _liteDatabaseFile = "loan-tracker.db";

    private readonly ILiteDatabase _liteDatabase;

    private static readonly Lazy<DatabaseController> _instance = new Lazy<DatabaseController>(() => new DatabaseController());

    private DatabaseController()
    {
        _liteDatabase = new LiteDatabase(_liteDatabaseFile);

        Persons = new LiteDbRepository<Person>(_liteDatabase, nameof(Persons));
        Transactions = new LiteDbRepository<Transaction>(_liteDatabase, nameof(Transactions));
    }

    public static DatabaseController Instance => _instance.Value;

    public IRepository<Person> Persons { get; }

    public IRepository<Transaction> Transactions { get; }

    //TODO: use StringComparer class object to compare strings? or a global instance maybe?
    //public IList<SafetyDiagram> GetList(string mapName, string equipmentName) => Persons.Get()
    //        .Where(x => x.MapName.Equals(mapName, StringComparison.OrdinalIgnoreCase) && x.Equipment.Name.Equals(equipmentName, StringComparison.OrdinalIgnoreCase))
    //        .OrderBy(x => x.ModifiedOn)
    //        .ToList();

    public void Dispose() => _liteDatabase?.Dispose();
}