using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.BaseMessage
{
    public static class UIMessage
    {
        public static readonly string DEFAULT_SUCCESS_ADD_MESSAGE = "Success Added";
        public static readonly string DEFAULT_SUCCESS_UPDATE_MESSAGE = "Success Updated";
        public static readonly string DEFAULT_SUCCESS_DELETE_MESSAGE = "Success Deleted";
        public static readonly string DEFAULT_WARNING_CONFIRM_MESSAGE = "Are you sure?";
        public static readonly string DEFAULT_WARNING_RETURN_MESSAGE = "You will not be able to return!";



        


        public static  string GetMinLengthMessage(int lenght, string propName)
        {
            return $"*{propName} must be at least {lenght} characters!";
        }

        public static string GetMaxLengthMessage(int lenght, string propName)
        {
            return $"*The {propName} cannot exceed {lenght} characters!";
        }


        public static readonly string DEFAULT_INVALID_EMAIL_ADRESS = "*Invalid Email!";
        public static readonly string DEFAULT_NOT_EMPTY_MESSAGE = "*Can't be left blank!";
        public static readonly string DEFAULT_ERROR_DUBLICATE_DATA = "*This is already in the database!";


        public const string PASSWORD_NOT_CONTAIN_UPPERCASE = "*Your password must contain at least one uppercase letter!";
        public const string PASSWORD_NOT_CONTAIN_LOWERCASE = "*Your password must contain at least one lowercase letter!";
        public const string PASSWORD_NOT_CONTAIN_NUMBER = "*Your password must contain at least one number!";
        public const string PASSWORD_NOT_CONTAIN_SYMBOL = "*Your password must contain at least one (!.@.#)!";
    }
}
