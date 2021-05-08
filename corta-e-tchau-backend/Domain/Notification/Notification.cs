namespace corta_e_tchau_backend.Domain.Notification
{
    public class Notification
    {
        public string errorMessage { get; }

        public Notification(string message)
        {
            errorMessage = message;
        }
    }
}
