using System.Collections.Generic;

namespace SOLID_Example
{
  public class CurrencyImporter
  {
    private readonly IDownloader _downloader;
    private readonly ICurrencyParser _parser;
    private readonly ICurrencyRepository _repository;
    private readonly IStatsCalculator _statsCalculator;
    private readonly IExporter _exporter;

    public CurrencyImporter(
      IDownloader downloader,
      ICurrencyParser parser, 
      ICurrencyRepository repository, 
      IStatsCalculator statsCalculator, 
      IExporter exporter)
    {
      _downloader = downloader;
      _parser = parser;
      _repository = repository;
      _statsCalculator = statsCalculator;
      _exporter = exporter;
    }

    public void Run()
    {
      string data = _downloader.GetData();
      IEnumerable<Currency> newData = _parser.Parse(data);
      IEnumerable<Currency> oldData = _repository.LoadPreviousData();
      _repository.Update(newData);
      IDictionary<string, decimal> result = _statsCalculator.Calculate(oldData, newData);
      foreach (KeyValuePair<string, decimal> keyValuePair in result)
      {
        _exporter.Export(keyValuePair.Key, keyValuePair.Value);
      }
    }
  }
}