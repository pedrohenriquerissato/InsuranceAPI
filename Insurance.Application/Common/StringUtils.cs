namespace Insurance.Application.Common
{
    /// <summary>
    /// Adds extensions to string property. Source: https://medium.com/@hannan.sultan1/adding-custom-naming-convention-to-the-new-system-text-json-in-net-core-c52f63f28a4f
    /// </summary>
    public static class StringUtils
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
