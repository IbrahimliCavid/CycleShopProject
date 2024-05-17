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
        public static readonly string DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE = "Can't enter less than 3 characters!";
        public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE = "Can't enter more than 2000 characters!";
        public static readonly string DEFAULT_NOT_EMPTY_MESSAGE = "Can't be left blank!";
    }
}
