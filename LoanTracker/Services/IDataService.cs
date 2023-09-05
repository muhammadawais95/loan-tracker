using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanTracker.Models;

namespace LoanTracker.Services;

public interface IDataService
{
    Task Save(Person person);

    Task<List<Person>> GetAll();
}