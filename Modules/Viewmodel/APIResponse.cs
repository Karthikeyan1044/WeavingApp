namespace InternarApplication
{
    /// <summary>
    /// Response View Model for All the Controllers
    /// </summary>
    public class APIResponse
    {
        public string Message { get; private set; }
        public bool Status { get; private set; }
        public int ServiceCode { get; private set; }
        public object Data { get; private set; }


        public APIResponse(string message , bool status, int serviceCode, object data)
        {
            Message = message;
            Status = status;
            ServiceCode = serviceCode;
            Data = data;
        }
    }
}
