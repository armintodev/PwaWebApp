namespace WebFramework.Utilities
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public OperationResult(bool success = true, string message = "")
        {
            Success = success;
            Message = message;
        }
    }

    public class OperationResult<TData> : OperationResult where TData : class
    {
        public TData Data { get; set; }
        public OperationResult(TData data, bool success = true, string message = "") : base(success, message)
        {
            Data = data;
        }
    }
}
