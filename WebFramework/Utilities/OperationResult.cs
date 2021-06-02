namespace WebFramework.Utilities
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
