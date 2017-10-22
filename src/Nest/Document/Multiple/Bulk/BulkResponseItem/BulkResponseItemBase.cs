using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	[JsonConverter(typeof(BulkResponseItemJsonConverter))]
	public abstract class BulkResponseItemBase
	{
		public abstract string Operation { get; internal set; }

		[JsonProperty("_index")]
		public string Index { get; internal set; }

		/// <summary>
		/// The assigned shard id of the item. Codex ElasticSearch only.
		/// </summary>
		[JsonProperty("_shard_id")]
		public int Shard { get; internal set; }

		[JsonProperty("_type")]
		public string Type { get; internal set; }

		[JsonProperty("_id")]
		public string Id { get; internal set; }

		[JsonProperty("_version")]
		public long Version { get; internal set; }

		/// <summary>
		/// The assigned stable id of the item. Codex ElasticSearch only.
		/// </summary>
		[JsonProperty("_stable_id")]
		public long StableId { get; internal set; } = -1;

		[JsonProperty("_seq_no")]
		public long SequenceNumber { get; internal set; }

		[JsonProperty("status")]
		public int Status { get; internal set; }

		[JsonProperty("error")]
		public BulkError Error { get; internal set; }

		[JsonProperty("result")]
		public string Result { get; internal set; }

		[JsonProperty("_shards")]
		public ShardsMetaData Shards { get; internal set; }

		/// <summary>
		/// Specifies wheter this particular bulk operation succeeded or not
		/// </summary>
		public bool IsValid
		{
			get
			{
				if (this.Error != null || this.Type.IsNullOrEmpty()) return false;
				switch (this.Operation.ToLowerInvariant())
				{
					case "delete": return this.Status == 200 || this.Status == 404;
					case "update": 
					case "index":
					case "create":
						return this.Status == 200 || this.Status == 201;
					default:
						return false;
				}
			}
		}

		public override string ToString() => $"{Operation} returned {Status} ({Result}) _index: {Index} _shard: {Shard} _type: {Type} _id: {Id} _version: {Version} _seqNo: {SequenceNumber}, _stableId: {StableId} error: {Error}";
	}
}
