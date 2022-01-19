using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;

namespace SOLID_Example
{
  internal class TransactionAspect<T> : DispatchProxy
  {
    private T _instance;

    public static T Create(T decorated)
    {
      object proxy = Create<T, TransactionAspect<T>>();
      ((TransactionAspect<T>)proxy).SetParameters(decorated);

      return (T)proxy;
    }

    private void SetParameters(T instance)
    {
      _instance = instance;
    }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
      if (targetMethod != null)
      {
        try
        {
          using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
          {
            var result = targetMethod.Invoke(_instance, args);
            Console.WriteLine("After invoke: " + targetMethod.Name);
            ts.Complete();
            return result;
          }
        }
        catch (Exception e)
        {
          Console.WriteLine("Exception: " + e);
          throw e;
        }
      }

      throw new ArgumentException(nameof(targetMethod));
    }
  }
}