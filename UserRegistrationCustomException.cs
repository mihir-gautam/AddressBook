using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class UserRegistrationCustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_INPUT,
            EMPTY_INPUT,
            INVALID_NAME,
            INVALID_MOBILE,
            INVALID_EMAIL,
            INVALID_PASSWORD
        }
        private readonly ExceptionType type;
        public UserRegistrationCustomException(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}
