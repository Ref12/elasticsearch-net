using System;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization.OptIn)]
	public partial class QueryContainer : IQueryContainer, IDescriptor
	{
		private IQueryContainer Self => this;

		internal TypedQueryBox QueryBox { get; set; }

		internal IQuery ContainedQuery => QueryBox?.Query;

		private void Set<T>(T value) where T : IQuery
		{
			if (this.QueryBox != null)
				throw new Exception($"QueryContainer can only hold a single query already contains a {this.ContainedQuery.GetType().Name}");
			this.QueryBox = new TypedQueryBox<T>(value);
		}

		private T Get<T>() where T : class, IQuery
		{
			return (this.QueryBox as TypedQueryBox<T>)?.TypedQuery;
		}

		IRawQuery IQueryContainer.RawQuery { get { return Get<IRawQuery>(); } set { Set(value); } }
		IBoolQuery IQueryContainer.Bool { get { return Get<IBoolQuery>(); } set { Set(value); } }
		IMatchAllQuery IQueryContainer.MatchAll { get { return Get<IMatchAllQuery>(); } set { Set(value); } }
		IMatchNoneQuery IQueryContainer.MatchNone { get { return Get<IMatchNoneQuery>(); } set { Set(value); } }
		ITermQuery IQueryContainer.Term { get { return Get<ITermQuery>(); } set { Set(value); } }
		IWildcardQuery IQueryContainer.Wildcard { get { return Get<IWildcardQuery>(); } set { Set(value); } }
		IPrefixQuery IQueryContainer.Prefix { get { return Get<IPrefixQuery>(); } set { Set(value); } }
		IBoostingQuery IQueryContainer.Boosting { get { return Get<IBoostingQuery>(); } set { Set(value); } }
		IIdsQuery IQueryContainer.Ids { get { return Get<IIdsQuery>(); } set { Set(value); } }

		IConstantScoreQuery IQueryContainer.ConstantScore { get { return Get<IConstantScoreQuery>(); } set { Set(value); } }
		IDisMaxQuery IQueryContainer.DisMax { get { return Get<IDisMaxQuery>(); } set { Set(value); } }
		IMultiMatchQuery IQueryContainer.MultiMatch { get { return Get<IMultiMatchQuery>(); } set { Set(value); } }
		IMatchQuery IQueryContainer.Match { get { return Get<IMatchQuery>(); } set { Set(value); } }
		IMatchPhraseQuery IQueryContainer.MatchPhrase { get { return Get<IMatchPhraseQuery>(); } set { Set(value); } }
		IMatchPhrasePrefixQuery IQueryContainer.MatchPhrasePrefix { get { return Get<IMatchPhrasePrefixQuery>(); } set { Set(value); } }
		IFuzzyQuery IQueryContainer.Fuzzy { get { return Get<IFuzzyQuery>(); } set { Set(value); } }
		IGeoShapeQuery IQueryContainer.GeoShape { get { return Get<IGeoShapeQuery>(); } set { Set(value); } }
		ICommonTermsQuery IQueryContainer.CommonTerms { get { return Get<ICommonTermsQuery>(); } set { Set(value); } }
		ITermsQuery IQueryContainer.Terms { get { return Get<ITermsQuery>(); } set { Set(value); } }
		IQueryStringQuery IQueryContainer.QueryString { get { return Get<IQueryStringQuery>(); } set { Set(value); } }
		ISimpleQueryStringQuery IQueryContainer.SimpleQueryString { get { return Get<ISimpleQueryStringQuery>(); } set { Set(value); } }
		IRegexpQuery IQueryContainer.Regexp { get { return Get<IRegexpQuery>(); } set { Set(value); } }
		IHasChildQuery IQueryContainer.HasChild { get { return Get<IHasChildQuery>(); } set { Set(value); } }
		IHasParentQuery IQueryContainer.HasParent { get { return Get<IHasParentQuery>(); } set { Set(value); } }
		IMoreLikeThisQuery IQueryContainer.MoreLikeThis { get { return Get<IMoreLikeThisQuery>(); } set { Set(value); } }
		IRangeQuery IQueryContainer.Range { get { return Get<IRangeQuery>(); } set { Set(value); } }
		ISpanTermQuery IQueryContainer.SpanTerm { get { return Get<ISpanTermQuery>(); } set { Set(value); } }
		ISpanFirstQuery IQueryContainer.SpanFirst { get { return Get<ISpanFirstQuery>(); } set { Set(value); } }
		ISpanOrQuery IQueryContainer.SpanOr { get { return Get<ISpanOrQuery>(); } set { Set(value); } }
		ISpanNotQuery IQueryContainer.SpanNot { get { return Get<ISpanNotQuery>(); } set { Set(value); } }
		ISpanNearQuery IQueryContainer.SpanNear { get { return Get<ISpanNearQuery>(); } set { Set(value); } }
		ISpanContainingQuery IQueryContainer.SpanContaining { get { return Get<ISpanContainingQuery>(); } set { Set(value); } }
		ISpanWithinQuery IQueryContainer.SpanWithin { get { return Get<ISpanWithinQuery>(); } set { Set(value); } }
		ISpanMultiTermQuery IQueryContainer.SpanMultiTerm { get { return Get<ISpanMultiTermQuery>(); } set { Set(value); } }
		ISpanFieldMaskingQuery IQueryContainer.SpanFieldMasking { get { return Get<ISpanFieldMaskingQuery>(); } set { Set(value); } }
		INestedQuery IQueryContainer.Nested { get { return Get<INestedQuery>(); } set { Set(value); } }
#pragma warning disable 618
		IIndicesQuery IQueryContainer.Indices { get { return Get<IIndicesQuery>(); } set { Set(value); } }
#pragma warning restore 618
		IFunctionScoreQuery IQueryContainer.FunctionScore { get { return Get<IFunctionScoreQuery>(); } set { Set(value); } }
		ITemplateQuery IQueryContainer.Template { get { return Get<ITemplateQuery>(); } set { Set(value); } }
		IGeoBoundingBoxQuery IQueryContainer.GeoBoundingBox { get { return Get<IGeoBoundingBoxQuery>(); } set { Set(value); } }
		IGeoDistanceQuery IQueryContainer.GeoDistance { get { return Get<IGeoDistanceQuery>(); } set { Set(value); } }
		IGeoPolygonQuery IQueryContainer.GeoPolygon { get { return Get<IGeoPolygonQuery>(); } set { Set(value); } }
		IGeoHashCellQuery IQueryContainer.GeoHashCell { get { return Get<IGeoHashCellQuery>(); } set { Set(value); } }
		IScriptQuery IQueryContainer.Script { get { return Get<IScriptQuery>(); } set { Set(value); } }
		IExistsQuery IQueryContainer.Exists { get { return Get<IExistsQuery>(); } set { Set(value); } }
		ITypeQuery IQueryContainer.Type { get { return Get<ITypeQuery>(); } set { Set(value); } }
		IPercolateQuery IQueryContainer.Percolate { get { return Get<IPercolateQuery>(); } set { Set(value); } }
		IParentIdQuery IQueryContainer.ParentId { get { return Get<IParentIdQuery>(); } set { Set(value); } }
		IStoredFilterQuery IQueryContainer.StoredFilter { get { return Get<IStoredFilterQuery>(); } set { Set(value); } }
	}
}
