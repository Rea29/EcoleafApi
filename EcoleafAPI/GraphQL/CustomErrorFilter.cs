namespace API.GraphQL
{
    public class CustomErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            // Customize the error format as needed
            return error;
        }

    }
}
