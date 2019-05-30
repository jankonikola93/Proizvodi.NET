using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
    public static class Enums
    {
        public enum ErrorCodes
        {
            Authentication = 1,
            Authorization = 2,
            Forbidden = 3,
            NotFound = 4,
            InternalServerError = 5,
            BadGateway = 6,
            ServiceUnavailable = 7,
            NetworkAuthenticationRequired = 8,
            WindowsAD = 9,
            Other = 10
        }
    }
}
