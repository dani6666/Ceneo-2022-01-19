using System;
using SOLID_TDD_Example;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace SOLID_Example
{
  internal class CurrencyRepository : ICurrencyRepository, IAdministrativeCurrencyRepository
  {
    private readonly string _connectionString;

    public CurrencyRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public IEnumerable<Currency> LoadPreviousData()
    {
      using (IDbConnection connection = OpenConnection())
      {
        return connection.Query<Currency>("select name,price from Currency");
      }
    }

    private IDbConnection OpenConnection()
    {
      SqlConnection sqlConnection = new SqlConnection(_connectionString);
      sqlConnection.Open();
      return sqlConnection;
    }

    public void Update(IEnumerable<Currency> newData)
    {
      using (IDbConnection connection = OpenConnection())
      {
        connection.Execute("insert into Currency(name,price)Values(@name,@price)", newData);
      }
    }

    public void Clean()
    {      
      using (IDbConnection connection = OpenConnection())
      {
        Console.WriteLine("Administrative cleanup");
        connection.Execute("delete from Currency");
      }
    }
  }
}