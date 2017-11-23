using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nest;
using Tests.Framework;
using System.Reflection;

namespace Tests.Ingest
{
	public class ProcessorSerializationTests : SerializationTestBase
	{
		[U]
		public void CanSerializeAndDeserializeAllProcessors()
		{
			var processorTypes =
				from t in typeof(IProcessor).Assembly().Types()
				where typeof(ProcessorBase).IsAssignableFrom(t) && !t.IsAbstract()
				select t;

			var processors = processorTypes
				.Select(processorType => (IProcessor)Activator.CreateInstance(processorType))
				.ToList();

			var pipeline = new Pipeline { Processors = processors };
			var deserializedPipeline = this.Deserialize<Pipeline>(this.Serialize(pipeline));

			deserializedPipeline.Processors.Should().HaveCount(pipeline.Processors.Count(), "All processors must be deserialized");
			deserializedPipeline.Processors.Select(p => p.Name).Distinct().Should().HaveCount(pipeline.Processors.Count(),
				"All processors must have unique names. Duplicate names: '{0}'",
				string.Join(", ", deserializedPipeline.Processors.ToLookup(p => p.Name).Where(g => g.Count() > 1).SelectMany(g => g).Select($"(Name: {p.Name}, Processor: {p.GetType()})")));
		}
	}
}
