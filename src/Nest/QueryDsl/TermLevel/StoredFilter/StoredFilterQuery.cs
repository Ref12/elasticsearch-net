using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(StoredFilterQueryJsonConverter))]
	public interface IStoredFilterQuery : IFieldNameQuery
	{
		IFieldLookup FilterLookup { get; set; }
	}

	public class StoredFilterQuery : FieldNameQueryBase, IStoredFilterQuery
	{
		/// <summary>
		/// Token used in stored filter id (see <see cref="IFieldLookup.Id"/> of <see cref="IStoredFilterQuery.FilterLookup"/>)
		/// for replacement when performing stored filter queries
		/// </summary>
		public const string ShardIdToken = "{shard_id}";

		protected override bool Conditionless => IsConditionless(this);
		public IFieldLookup FilterLookup { get; set; }

		internal override void InternalWrapInContainer(IQueryContainer c) => c.StoredFilter = this;
		internal static bool IsConditionless(IStoredFilterQuery q)
		{
			return q.Field.IsConditionless()
				|| (
				(q.FilterLookup == null
					|| q.FilterLookup.Id == null
					|| q.FilterLookup.Path.IsConditionless()
					|| q.FilterLookup.Index == null
					|| q.FilterLookup.Type == null
				));
		}
	}

	/// <summary>
	/// A query that match on any (configurable) of the provided terms.
	/// This is a simpler syntax query for using a bool query with several term queries in the should clauses.
	/// </summary>
	/// <typeparam name="T">The type that represents the expected hit type</typeparam>
	public class StoredFilterQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<StoredFilterQueryDescriptor<T>, IStoredFilterQuery, T>
		, IStoredFilterQuery where T : class
	{
		protected override bool Conditionless => StoredFilterQuery.IsConditionless(this);
		IFieldLookup IStoredFilterQuery.FilterLookup { get; set; }

		public StoredFilterQueryDescriptor<T> FilterLookup<TOther>(Func<FieldLookupDescriptor<TOther>, IFieldLookup> selector)
			where TOther : class => Assign(a => a.FilterLookup = selector(new FieldLookupDescriptor<TOther>()));
	}
}
