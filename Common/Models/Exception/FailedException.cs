namespace Common.Models.Exception
{
    public class FailedException : System.Exception
    {
        public Constants.ErrorCodes ErrorCode;

        public FailedException(Constants.ErrorCodes code)
        {
            ErrorCode = code;
        }
    }
}
