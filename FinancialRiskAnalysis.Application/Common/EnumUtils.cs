using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Common
{
    public static class EnumUtils
    {
        /// <summary>
        /// Retrieves enum properties names
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetNames<T>()
        {
            if (!typeof(T).IsEnum)
                return string.Empty;

            return string.Join(",", Enum.GetNames(typeof(T)).Select(x => x.ToLower()).OrderBy(x => x));
        }
    }
}
