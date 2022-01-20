using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SOLID_Example
{
  public class XMLCurrencyParser : ICurrencyParser
  {
    public IEnumerable<Currency> Parse(string data)
    {
      XElement xelement = XElement.Load(new StringReader(data));
      return from nm in xelement.Elements("pozycja")
             select new Currency(nm.Element("kod_waluty").Value, decimal.Parse(nm.Element("kurs_sredni").Value));
    }
  }
}