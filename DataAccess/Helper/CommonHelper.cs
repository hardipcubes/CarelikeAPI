using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helper
{
    public class CommonHelper
    {
        public static T FromDB<T>(object value)
        {
            return value == DBNull.Value ? default(T) : (T)value;
        }

        public static object ToDB<T>(T value)
        {
            return value == null ? (object)DBNull.Value : value;
        }
    }
}
