namespace editorial_webapi.Configurations
{
    public class OperationResult : object
    {
        public bool isValid { get; set; }
        public List<OperationException> exceptions { get; set; }
    }
    public class OperationResult<T> : OperationResult
    {
        public T content { get; set; }

    }

    public class OperationException : object
    {
        public string code { get; set; }
        public string description { get; set; }
        public OperationException(string code, string description) : base()
        {
            this.code = code;
            this.description = description;
        }
        public OperationException()
        {

        }
    }
}
