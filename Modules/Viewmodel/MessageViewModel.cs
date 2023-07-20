
namespace InternalApplication.Modules.Viewmodel
{
    public class MessageViewModel
    {

        public string MessageKey { get; private set; }
        public bool Status { get; private set; }
        public string ErrorMessage { get; private set; }
        public object Data { get; private set; }

        public MessageViewModel(string message, bool status, string errorMessage = "", object data = null)
        {
            MessageKey = message;
            Status = status;
            ErrorMessage = errorMessage;
            Data = data;
        }
    }
}
