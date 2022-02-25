namespace Insurance.Application.Common
{
    public static class EnumUtils
    {
        /// <summary>
        /// Retrieves enum properties names
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A comma concatenated list of specific enumeration</returns>
        public static string GetNames<T>()
        {
            if (!typeof(T).IsEnum)
                return string.Empty;

            return string.Join(",", Enum.GetNames(typeof(T)).Select(x => x.ToLower()).OrderBy(x => x));
        }
    }
}
