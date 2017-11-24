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

		/// <summary>
		/// The field containing a list of bit vectors to union with the bit vector
		/// </summary>
		[JsonProperty("union_field")]
		Field UnionField { get; set; }

		/// <summary>
		/// The field in which the count of entries in bit vector is stored (optional)
		/// </summary>
		[JsonProperty("target_count_field")]
		Field TargetCountField { get; set; }

		/// <summary>
		/// The field in which the hash of bit vector is stored (optional)
		/// </summary>
		[JsonProperty("target_hash_field")]
		Field TargetHashField { get; set; }
	}

	public class BinarySequenceProcessor : ProcessorBase, IBinarySequenceProcessor
	{
		protected override string Name => "binary_sequence";

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.IncludeField"/>
		/// </summary>
		public Field IncludeField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.ExcludeField"/>
		/// </summary>
		public Field ExcludeField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetField"/>
		/// </summary>
		public Field TargetField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.UnionField"/>
		/// </summary>
		public Field UnionField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetCountField"/>
		/// </summary>
		public Field TargetCountField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetHashField"/>
		/// </summary>
		public Field TargetHashField { get; set; }
	}

	public class BinarySequenceProcessorDescriptor<T> : ProcessorDescriptorBase<BinarySequenceProcessorDescriptor<T>, IBinarySequenceProcessor>, IBinarySequenceProcessor
		where T : class
	{
		protected override string Name => "binary_sequence";

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.IncludeField"/>
		/// </summary>
		Field IBinarySequenceProcessor.IncludeField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.ExcludeField"/>
		/// </summary>
		Field IBinarySequenceProcessor.ExcludeField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetField"/>
		/// </summary>
		Field IBinarySequenceProcessor.TargetField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.UnionField"/>
		/// </summary>
		Field IBinarySequenceProcessor.UnionField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetCountField"/>
		/// </summary>
		Field IBinarySequenceProcessor.TargetCountField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetHashField"/>
		/// </summary>
		Field IBinarySequenceProcessor.TargetHashField { get; set; }

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.IncludeField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> IncludeField(Field field) => Assign(a => a.IncludeField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.IncludeField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> IncludeField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.IncludeField = objectPath);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.ExcludeField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> ExcludeField(Field field) => Assign(a => a.ExcludeField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.ExcludeField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> ExcludeField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.ExcludeField = objectPath);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetField(Field field) => Assign(a => a.TargetField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.TargetField = objectPath);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetHashField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetHashField(Field field) => Assign(a => a.TargetHashField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetHashField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetHashField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.TargetHashField = objectPath);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetCountField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetCountField(Field field) => Assign(a => a.TargetCountField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.TargetCountField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> TargetCountField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.TargetCountField = objectPath);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.UnionField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> UnionField(Field field) => Assign(a => a.UnionField = field);

		/// <summary>
		/// <see cref="IBinarySequenceProcessor.UnionField"/>
		/// </summary>
		public BinarySequenceProcessorDescriptor<T> UnionField(Expression<Func<T, object>> objectPath) =>
			Assign(a => a.UnionField = objectPath);
	}
}
