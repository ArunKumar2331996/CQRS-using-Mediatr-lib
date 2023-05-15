namespace Mediator_Pattern.Model
{
    public class Response<T>: Response where T : class
    {
        public T Value { get; set; }
    }

    public class Response { 
        public string Data { get; set; }
    }
}
