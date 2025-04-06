namespace MalenkijMelo.Share.Models.Responses
{
    public class ErrorStore
    {
        public ErrorStore()
        {
            ClearErrorStore();
        }

        public string Error { get; set; } = string.Empty;
        public bool HasError
        {
            get => !string.IsNullOrEmpty(Error);
        }

        public void ClearErrorStore()
        {
            Error = string.Empty;
        }

        public void ClearAndAddError(string errorMessage)
        {
            Error = errorMessage;
        }

        public void AppendError(string errorMessage)
        {
            Error += "\n" + errorMessage;
        }
    }
}
