using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public class Patterns
    {
        string Name = "^[A-Z][a-z0-9A-Z]{3,}";
        string EmailId = "^[a-z0-9A-Z]+([._+-][a-z0-9A-Z]+)*[@][a-z0-9A-Z]+[.][a-zA-Z]{2,3}(.[a-zA-Z]{2,})?$";
        string mobileNo = "^[+][0-9]{1,3}[ ][1-9]{1}[0-9]{9}$";
        string Password = "^((?=.*[A-Z])(?=.*[0-9])(?=^[a-zA-Z0-9]*[!@$#&*_+-]{1}[a-zA-Z0-9]).{8,})";

        public bool ValidateName(string name)
        {
            try
            {
                if (name.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Name should not be empty");
                }
                else if (Regex.IsMatch(name, Name))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Name not valid");
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_INPUT, "Name should not be null");
            }
        }
        public bool ValidateEmail(string email)
        {
            try
            {
                if (email.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Email should not be empty");
                }
                if (Regex.IsMatch(email, EmailId))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Email id not valid");
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_INPUT, "Email should not be null");
            }
        }
        public bool ValidateMobile(string mobile)
        {
            try
            {
                if (mobile.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Mobile Number should not be empty");
                }
                if (Regex.IsMatch(mobile, mobileNo))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("mobile number not valid");
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_INPUT, "Mobile Number should not be null");
            }

        }
        public bool ValidatePassword(string pw)
        {
            try
            {
                if (pw.Equals(string.Empty))
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_INPUT, "Password should not be empty");
                }
                if (Regex.IsMatch(pw, Password))
                {
                    Console.WriteLine("Password is valid");
                    return true;
                }
                else
                {
                    Console.WriteLine("Password not valid");
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.NULL_INPUT, "Password should not be null");
            }
        }
        
    }
}
