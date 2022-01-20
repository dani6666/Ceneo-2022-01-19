using System.Collections.Generic;

namespace SOLID_Example
{
  public interface IStatsCalculator
  {
    IDictionary<string, decimal> Calculate(IEnumerable<Currency> oldData, IEnumerable<Currency> newData);
  }
}