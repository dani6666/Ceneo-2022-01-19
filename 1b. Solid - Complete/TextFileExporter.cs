using System.IO;

namespace SOLID_Example
{
  internal class TextFileExporter : IExporter
  {
    private readonly string _path;

    public TextFileExporter(string path)
    {
      _path = path;
    }

    public void Export(string name, decimal price)
    {
      File.AppendAllText(_path, string.Format("{0} - {1}", name, price));
    }
  }
}