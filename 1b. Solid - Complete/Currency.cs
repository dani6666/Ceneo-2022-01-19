namespace SOLID_Example
{
  public class Currency
  {
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Currency(string name, decimal price)
    {
      Name = name;
      Price = price;
    }
  }
}