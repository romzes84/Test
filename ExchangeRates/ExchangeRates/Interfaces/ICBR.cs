using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeRates.Models;

namespace ExchangeRates.Interfaces
{
    public interface ICBR
    {
        Task<List<Valute>>  GetCourse(DateTime date);
    }
}