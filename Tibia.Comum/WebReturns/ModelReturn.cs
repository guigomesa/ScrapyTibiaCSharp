using System.Collections.Generic;
using System.Net;

namespace TibiaApi.Comum.WebReturns
{
    public abstract class ModelBaseReturn
    {
        public virtual object Model { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Message { get; protected set; }
        public string UrlCreated { get; set; }
    }

    public class ModelReturn<TModel> : ModelBaseReturn
    {
        public new TModel Model { get; protected set; }
        public List<string> Erros { get; protected set; }

        public ModelReturn() { }

        public ModelReturn(TModel model, HttpStatusCode statusCode, string message = null, List<string> erros = null)
        {
            Model = model;
            Status = statusCode;
            Message = message;
            Erros = erros;
        }

        public ModelReturn(TModel model, int statusCode)
        {
            Model = model;
            Status = (HttpStatusCode)statusCode;
        }

        public ModelReturn(HttpStatusCode status)
        {
            Status = status;
        }

        public ModelReturn(int status)
        {
            Status = (HttpStatusCode)status;
        }
    }
}
