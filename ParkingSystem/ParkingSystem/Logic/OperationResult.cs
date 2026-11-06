namespace ParkingSystem.Logic
{
    public class OperationResult
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public static OperationResult Ok(string message)
        {
            return new OperationResult { Success = true, Message = message };
        }

        public static OperationResult Fail(string message)
        {
            return new OperationResult { Success = false, Message = message };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data { get; private set; }

        public static OperationResult<T> Ok(string message, T data)
        {
            return new OperationResult<T> { Success = true, Message = message, Data = data };
        }

        public static new OperationResult<T> Fail(string message)
        {
            return new OperationResult<T> { Success = false, Message = message };
        }
    }
}
