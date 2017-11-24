using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	internal abstract class ProcessorJsonConverter
	{
		private static ConcurrentDictionary<string, ProcessorJsonConverter> m_converters = new ConcurrentDictionary<string, ProcessorJsonConverter>();

		public ProcessorJsonConverter(string processorName)
		{
			m_converters.GetOrAdd(processorName, this);
		}

		public static IProcessor ToProcessor(string processorName, JToken jsonProcessor)
		{
			ProcessorJsonConverter converter;
			if (m_converters.TryGetValue(processorName, out converter))
			{
				return converter.Convert(jsonProcessor);
			}

			return null;
		}

		protected abstract IProcessor Convert(JToken jsonProcessor);
	}

	public class ProcessorJsonConverter<TReadAs> : ReserializeJsonConverter<TReadAs, IProcessor>
		where TReadAs : class, IProcessor, new()
	{
		private static readonly ProcessorJsonConverter RegisteredConverter = new RegisteredTypedConverter();

		protected override void SerializeJson(JsonWriter writer, object value, IProcessor castValue, JsonSerializer serializer)
		{
			var name = castValue.Name;
			if (name == null) return;
			writer.WriteStartObject();
			{
				writer.WritePropertyName(name);
				{
					this.Reserialize(writer, value, serializer);
				}
			}
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartObject) return null;
			reader.Read(); //property name of processor type
			if (reader.TokenType != JsonToken.PropertyName) return null;
			reader.Read();
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}

		private class RegisteredTypedConverter : ProcessorJsonConverter
		{
			public RegisteredTypedConverter()
				: base(new TReadAs().Name)
			{
			}

			protected override IProcessor Convert(JToken jsonProcessor)
			{
				return jsonProcessor.ToObject<TReadAs>();
			}
		}
	}
}
