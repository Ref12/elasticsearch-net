using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	internal class PipelineJsonConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => true;
		public override bool CanWrite => false;
		public override bool CanRead => true;

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var root = JObject.Load(reader);
			var pipeline = new Pipeline { Description = root["description"]?.ToString() };
			if (root["processors"] != null)
				pipeline.Processors = GetProcessors(root["processors"], serializer);
			if (root["on_failure"] != null)
				pipeline.OnFailure = GetProcessors(root["on_failure"], serializer);
			return pipeline;
		}

		private List<IProcessor> GetProcessors(JToken jsonProcessors, JsonSerializer serializer)
		{
			var processors = new List<IProcessor>();
			foreach (var jsonProcessor in jsonProcessors.ToArray())
			{
				var processorName = jsonProcessor.ToObject<JObject>().Properties().First().Name;
				var processor = ProcessorJsonConverter.ToProcessor(processorName, jsonProcessor);
				if (processor != null)
				{
					processors.Add(processor);
				}
			}
			return processors;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotSupportedException();
		}
	}
}
