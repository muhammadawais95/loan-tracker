using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTracker.Models;

public enum PaymentMode
{
    Cash,

    OnlineTransfer,

    BankTransfer,

    PayOrder
}