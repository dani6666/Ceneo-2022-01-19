using System.Net;

namespace SOLID_Example
{
  public class HttpDownloader : IDownloader
  {
    private readonly string _uri;

    public HttpDownloader(string uri)
    {
      this._uri = uri;
    }

    public string GetData()
    {
      using (var cli = new WebClient())
      {
        return cli.DownloadString(_uri);
      }
    }
  }
}