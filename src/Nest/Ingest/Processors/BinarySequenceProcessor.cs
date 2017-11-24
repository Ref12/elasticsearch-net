using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	/// <summary>
	/// The purpose of this processor is to encode a series of integral values as a dense bit vector
	/// for use by stored filter query
	/// Codex ElasticSearch only.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<BinarySequenceProcessor>))]
	public interface IBinarySequenceProcessor : IProcessor
	{
		/// <summary>
		/// The field containing integral values to add to the bit vector
		/// </summary>
		[JsonProperty("include_field")]
		Field IncludeField { get; set; }

		/// <summary>
		/// The field containing integral values to remove from the bit vector
		/// </summary>
		[JsonProperty("exclude_field")]
		Field ExcludeField { get; set; }

		/// <summary>
		/// The field in which the bit vector is stored
		/// </summary>
		[JsonProperty("target_field")]
		Field TargetField { get; set; }
	}

	public class BinarySequenceProcessor : ProcessorBase, IBinarySequenceProcessor
	{
		protected override string Name => "binary_sequence";

		/// <summary>
		/// The field containing integral values to add to the bit vector
		/// </summary>
		public Field IncludeField { get; set; }

		/// <summary>
		/// The field containing integral values to remove from the bit vector
		/// </summary>
		public Field ExcludeField { get; set; }

		/// <summary>
		/// The field in which the bit vector is stored
		/// </summary>
		public Field TargetField { get; set; }
	}

	public class BinarySequenceProcessorDescriptor<T> : ProcessorDescriptorBase<BinarySequenceProcessorDescriptor<T>, IBinarySequenceProcessor>, IBinarySequenceProcessor
		where T : class
	{
		protected override string Name => "binary_sequence";

		/// <summary>
		/// The field containing integral values to add to the bit vector
		/// </summary>
		Field IBinarySequenceProcessor.IncludeField { get; set; }

		/// <summary>
		/// The field containing integral values to remove from the bit vector
		/// </summary>
		Field IBinarySequenceProcessor.ExcludeField { get; set; }

		/// <summary>
		/// The field in which the bit vector is stored
		/// </summary>
		Field IBinarySequenceProcessor.TargetField { get; set; }

		/// <summary>
		/// The field containing integral values to add to the bit vector
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> IncludeField(Field field) => Assign(a => a.IncludeField = field);

		/// <summary>
		/// The field containing integral values to add to the bit vector
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> IncludeField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.IncludeField = objectPath);

		/// <summary>
		/// The field containing integral values to remove from the bit vector
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> ExcludeField(Field field) => Assign(a => a.ExcludeField = field);

		/// <summary>
		/// The field containing integral values to remove from the bit vector
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> ExcludeField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.ExcludeField = objectPath);

		/// <summary>
		/// The field in which the bit vector is stored
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetField(Field field) => Assign(a => a.TargetField = field);

		/// <summary>
		/// The field in which the bit vector is stored
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.TargetField = objectPath);
	}
}
