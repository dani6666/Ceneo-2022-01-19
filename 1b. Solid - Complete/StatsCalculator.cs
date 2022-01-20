using System.Collections.Generic;
using System.Linq;

namespace SOLID_Example
{
  internal class StatsCalculator : IStatsCalculator
  {
    public IDictionary<string, decimal> Calculate(IEnumerable<Currency> oldData, IEnumerable<Currency> newData)
    {
      IDictionary<string, decimal> result = new Dictionary<string, decimal>();
      foreach (Currency newCurrency in newData)
      {
        Currency currency = oldData.FirstOrDefault(f => f.Name == newCurrency.Name);
        if (currency != null && newCurrency.Price != currency.Price)
        {
          result.Add(newCurrency.Name, newCurrency.Price - currency.Price);
        }
      }
      return result;
    }
  }
}