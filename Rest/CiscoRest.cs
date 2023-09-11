using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIExtensionsLoader.Rest
{
    public class CiscoRest : IDisposable
    {
        public RestClient Client;
        private bool disposedValue;

        public CiscoRest(string host, string username, string password)
        {
            var _baseUri = $"http://{host}/putxml";
            var options = new RestClientOptions(_baseUri)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };

            Client = new RestClient(options);
        }

        public async Task<RestResponse> PostAsync<T>(T Request) where T : class
        {
            try
            {
                RestRequest request = new RestRequest().AddXmlBody(Request);
                return await Client.PostAsync(request);
            }
            catch (Exception ex)
            {
                SimplDebug.Error($"Error sending Post request to endpoint {ex.Message}");
                return null;
            }

        }


        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CiscoRest()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
