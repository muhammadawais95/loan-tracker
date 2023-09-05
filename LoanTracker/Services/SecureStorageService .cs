using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTracker.Services;

public class SecureStorageService : ISecureStorageService
{
    public SecureStorageService() { }

    public Task<string> Get(string key, string defaultValue = null)
    {
        throw new NotImplementedException();
    }

    public Task Save(string key, string value)
    {
        throw new NotImplementedException();
    }

    //TODO: Install Xamarin.Essentials nuget package? Compaible with Avalonia?
    //public async Task<string> Get(string key, string defaultValue = null)
    //{
    //    var result = await SecureStorage.Default.GetAsync(key);

    //    if (result == null)
    //        return defaultValue;

    //    return result;
    //}

    //public async Task Save(string key, string value) => await SecureStorage.SetAsync(key, value);
}