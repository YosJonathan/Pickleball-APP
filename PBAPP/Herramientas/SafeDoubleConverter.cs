using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PBAPP.Herramientas
{
    public class SafeDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out double value))
            {
                return value;
            }

            if (reader.TokenType == JsonTokenType.String && double.TryParse(reader.GetString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            return 0.0; // valor por defecto
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
