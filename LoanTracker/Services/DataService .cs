using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using LoanTracker.Helpers;
using LoanTracker.Models;
using Microsoft.CodeAnalysis;

namespace LoanTracker.Services;

public class DataService : IDataService
{
    private const string _personsDataCollectionName = "persons";

    private readonly ISecureStorageService _secureStorageService;

    public DataService(ISecureStorageService secureStorageService)
    {
        _secureStorageService = secureStorageService;
    }

    public async Task<List<Person>> GetAll()
    {
        using var db = new LiteDatabase(await GetConnectionString());

        var collection = db.GetCollection<Person>(_personsDataCollectionName);

        var persons = collection.Query().ToList();

        return persons;
    }

    public async Task Save(Person person)
    {
        using var db = new LiteDatabase(await GetConnectionString());

        var collection = db.GetCollection<Person>(_personsDataCollectionName);

        collection.Insert(person);

        collection.EnsureIndex(x => x.Name);
    }

    public async Task<string> Upload(byte[] bytes, string filename)
    {
        using var db = new LiteDatabase(await GetConnectionString());

        var info = db.FileStorage.Upload(Guid.NewGuid().ToString(), filename, new MemoryStream(bytes));

        return info.Id;
    }

    public async Task<byte[]> Download(string id)
    {
        using var db = new LiteDatabase(await GetConnectionString());

        var stream = new MemoryStream();

        db.FileStorage.Download(id, stream);

        stream.Position = 0;

        return stream.ToArray();
    }

    private async Task<string> GetConnectionString()
    {
        //var path = FileSystem.Current.AppDataDirectory;
        var path = PlatformHelper.GetApplicationPath();

        var fullPath = Path.Combine(path, $"{_personsDataCollectionName}.db");

        var password = await _secureStorageService.Get("password");

        if (password == null)
        {
            password = Guid.NewGuid().ToString();
            await _secureStorageService.Save("password", password);
        }

        var connectionString = $"Filename={fullPath};Password={password}";

        return connectionString;
    }
}