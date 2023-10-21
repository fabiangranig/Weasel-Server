using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Resolvers;

namespace WeaselServer.CommandHandler.RestAPI
{
    internal class GetRequests
    {
        private static Thread _GetHandler;

        public static void StartReuests()
        {
            _GetHandler = new Thread(GetRequestHandler);
            _GetHandler.Name = "ThreadGET";
            _GetHandler.Start();
        }

        private static void GetRequestHandler()
        {
            string url = "http://localhost:9999/";
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(HandleRequest, context);
                }
            }
        }

        static void HandleRequest(object state)
        {
            HttpListenerContext context = (HttpListenerContext)state;
            HttpListenerRequest request = context.Request;

            string path = request.Url.LocalPath.ToLower();

            if (request.HttpMethod == "GET")
            {
                if (path == "/map")
                {
                    //Handle GET request to /map
                    string responseString = MapResolver.ShowMapJSON();
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

                    HttpListenerResponse response = context.Response;
                    response.ContentLength64 = buffer.Length;
                    response.StatusCode = (int)HttpStatusCode.OK;

                    using (System.IO.Stream output = response.OutputStream)
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }
                }
                else
                {
                    //Handle unknown request with 404
                    HttpListenerResponse response = context.Response;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
            }
            else
            {
                //Handle other HTTP methods or return an error
                HttpListenerResponse response = context.Response;
                response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            }
            context.Response.Close();
        }

    }
}
