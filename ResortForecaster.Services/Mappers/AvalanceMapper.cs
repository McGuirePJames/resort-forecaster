using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ResortForecaster.Services.Mappers
{
    public class AvalanceMapper : IAvalancheMapper
    {
        public List<Avalanche> FromRaw(List<AvalanceRaw>? avalanceRaws)
        {
            if (avalanceRaws == null)
            {
                return new List<Avalanche>();
            }

            var avalanches = new List<Avalanche>();

            foreach (var avalancheRaw in avalanceRaws)
            {
                var avalanche = new Avalanche();

                PropertyInfo[] props = avalancheRaw.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(avalancheRaw)?.ToString();
                    prop.SetValue(avalancheRaw, this.HandleNone(propValue));
                }

                try
                {
                    avalanche.Id = Guid.NewGuid();
                    avalanche.ExternalId = avalancheRaw.Id;
                    avalanche.Latitude = this.CleanCoordinate(avalancheRaw.Latitude);
                    avalanche.Longitude = this.CleanCoordinate(avalancheRaw.Longitude);
                    avalanche.Elevation = this.CleanInteger(avalancheRaw.Elevation);
                    avalanche.Aspect = this.CleanString(avalancheRaw.Aspect);
                    avalanche.Type = this.CleanString(avalancheRaw.Type);
                    avalanche.Cause = this.CleanString(avalancheRaw.Cause);
                    avalanche.Depth = this.CleanMeasurement(avalancheRaw.Depth);
                    avalanche.Width = this.CleanMeasurement(avalancheRaw.Width);

                    avalanches.Add(avalanche);
                }
                catch
                {

                }
            }

            return avalanches;
        }

        private int? CleanMeasurement(string? value)
        {
            if (string.IsNullOrEmpty(value?.Trim()) || value == "Unknown")
            {
                return null;
            }

            if (value.Contains("\""))
            {
                return this.ConvertInches(value);
            }
            else if (value.Contains("'") || value.Contains(","))
            {
                return this.ConvertFeet(value);
            }

            return null;
        }

        private int ConvertFeet(string value)
        {
            var cleanedValue = value.Replace("'", "");
            
            if (cleanedValue.Contains(","))
            {
                var cleanedFeet = Regex.Replace(cleanedValue, "[^0-9]", "");

                return int.Parse(cleanedFeet) * 12;
            }

            var totalInches = 0;
            var cleanedValueParts = cleanedValue.Split('.');

            var feet = int.Parse(cleanedValueParts[0]);
            totalInches = (feet * 12);

            if (cleanedValueParts.Length == 2)
            {
                totalInches += 6;
            }

            return totalInches;
        }

        private int ConvertInches(string value)
        {
            var inches = value.Replace("\"", "");

            return int.Parse(inches);
        }

        private string? CleanString(string? value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
            {
                return null;
            }

            return value.Trim();
        }

        private int? CleanInteger(string? value)
        {
            if (string.IsNullOrEmpty(value?.Trim()))
            {
                return null;
            }

            var cleanedInteger = Regex.Replace(value, "[^0-9]", "");

            if (cleanedInteger.Length == 0)
            {
                return null;
            }

            return int.Parse(cleanedInteger);
        }

        private double? CleanCoordinate(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var cleanedCoordinate = Regex.Replace(value, "[^0-9.-]", "");

            if (cleanedCoordinate.Length == 0)
            {
                return null;
            }

            return Double.Parse(cleanedCoordinate);
        }

        private string? HandleNone(string? value)
        {
            if (value == "None")
            {
                return null;
            }

            return value;
        }
    }
}
