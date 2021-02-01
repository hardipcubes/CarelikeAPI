using System.Net;

namespace BusinessObjects.ViewModel
{
    public class APIResponseBase<T>
    {
        //public  APIResponseBase()
        //{
          
        //}

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
    
}