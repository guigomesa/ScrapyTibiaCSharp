using System;
using System.Net;

namespace TibiaApi.Comum.TibiaExceptions
{
    public class TibiaDomainLayerException : Exception
    {
        public HttpStatusCode Code { get; }

        public TibiaDomainLayerException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}
