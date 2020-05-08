using System;
using System.Net;

namespace ProjectTest.API.Model
{
    public class Response
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public Object Model { get; set; }
        public string MessageError { get; set; }
    }
}
