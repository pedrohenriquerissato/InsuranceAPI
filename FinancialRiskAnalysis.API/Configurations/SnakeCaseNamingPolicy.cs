using System.Text.Json;

namespace Insurance.API.Configurations
{
    /// <summary>
    /// Creates a Lower Snake Case Policy for JSON convertions. Source: https://medium.com/@hannan.sultan1/adding-custom-naming-convention-to-the-new-system-text-json-in-net-core-c52f63f28a4f
    /// </summary>
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}
