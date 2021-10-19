using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Constants
    {
        public enum ErrorCodes
        {
            Success = 200,
            InvalidInput = 1,
            CustomerAlreadyExists = 2,
            NotInserted = 3,
            Edited = 4,
            Deleted = 5,
            GeneralException = 400,
            NotFound = 404
        }
    }
}
