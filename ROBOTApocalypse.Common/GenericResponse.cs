namespace ROBOTApocalypse.Common
{
    public class GenericResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public System.Net.HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }

        public GenericResponse(bool success, string message, System.Net.HttpStatusCode statusCode, T result)
        {
            this.Success = success;
            this.Message = message;
            this.StatusCode = statusCode;
            this.Result = result;
        }

    }
}