using System.Text.Json;

namespace ResortForecaster.Utilities
{
    public static class Utilities
    {
        public static T? TryParseOut<T>(string? value) where T : struct
        {
            if (value == null)
            {
                return null;
            }

            try
            {
                return ReferenceEquals(value, null) ? default(T) : (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return null;
            }
        }

        public static string? TryGetProperty(string propertyName, JsonElement jsonElement)
        {
            if (jsonElement.TryGetProperty(propertyName, out var property))
            {
                return jsonElement.GetProperty(propertyName).ToString();
            }

            return null;
        }
    }
}
