using System.Collections.Generic;

namespace SOLID_Example
{
  public interface ICurrencyParser
  {
    IEnumerable<Currency> Parse(string data);
  }
}