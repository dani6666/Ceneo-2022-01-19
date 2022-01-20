using System.Collections.Generic;

namespace SOLID_Example
{
  public interface ICurrencyRepository
  {
    IEnumerable<Currency> LoadPreviousData();

    void Update(IEnumerable<Currency> newData);
  }
}