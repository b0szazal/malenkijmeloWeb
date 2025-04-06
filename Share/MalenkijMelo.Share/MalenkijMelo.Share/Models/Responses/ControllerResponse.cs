namespace MalenkijMelo.Share.Models.Responses
{
    public class ControllerResponse : ErrorStore
    {
        public bool Success
            => !HasError;

        public ControllerResponse() : base()
        {
        }
    }
}
