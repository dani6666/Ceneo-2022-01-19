using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using SOLID_Example.Infrastructure;
using SOLID_TDD_Example;

namespace SOLID_Example
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", true, true)
       .Build();
      var databaseSection = configuration.GetSection("ConnectionString");
      var connectionString = databaseSection["ConnectionString"];
      var url = configuration.GetSection("Params")["url"];
      var outputFile = configuration.GetSection("Params")["outputFile"];

      InitDb.Run(connectionString);

      if (args.Length > 1 && args[0] == "cleanup")
      {
        IAdministrativeCurrencyRepository acr = TransactionAspect<IAdministrativeCurrencyRepository>.Create(new CurrencyRepository(connectionString));
        acr.Clean();
      }
      else
      {
        CurrencyImporter invoiceDataImporter = new CurrencyImporter(
          new HttpDownloader(url),
          new XMLCurrencyParser(),
          TransactionAspect<ICurrencyRepository>.Create(new CurrencyRepository(connectionString)),
          new StatsCalculator(),
          new TextFileExporter(outputFile));
        invoiceDataImporter.Run();
      }
    }
  }
}