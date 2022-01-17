using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesMaster.ExtMethods.ExtLinq
{
	public static class ExtLinq
	{
		public static IList<TR> FullOuterGroupJoin<TA, TB, TK, TR>(
			this IEnumerable<TA> a,
			IEnumerable<TB> b,
			Func<TA, TK> selectKeyA,
			Func<TB, TK> selectKeyB,
			Func<IEnumerable<TA>, IEnumerable<TB>, TK, TR> projection,
			IEqualityComparer<TK> cmp = null)
		{
			cmp = cmp ?? EqualityComparer<TK>.Default;
			var alookup = a.ToLookup(selectKeyA, cmp);
			var blookup = b.ToLookup(selectKeyB, cmp);

			var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);
			keys.UnionWith(blookup.Select(p => p.Key));

			var join = from key in keys
								 let xa = alookup[key]
								 let xb = blookup[key]
								 select projection(xa, xb, key);

			return join.ToList();
		}

		public static IList<TR> FullOuterJoin<TA, TB, TK, TR>(
			this IEnumerable<TA> a,
			IEnumerable<TB> b,
			Func<TA, TK> selectKeyA,
			Func<TB, TK> selectKeyB,
			Func<TA, TB, TK, TR> projection,
			TA defaultA = default(TA),
			TB defaultB = default(TB),
			IEqualityComparer<TK> cmp = null)
		{
			cmp = cmp ?? EqualityComparer<TK>.Default;
			var alookup = a.ToLookup(selectKeyA, cmp);
			var blookup = b.ToLookup(selectKeyB, cmp);

			var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);
			keys.UnionWith(blookup.Select(p => p.Key));

			var join = from key in keys
								 from xa in alookup[key].DefaultIfEmpty(defaultA)
								 from xb in blookup[key].DefaultIfEmpty(defaultB)
								 select projection(xa, xb, key);

			return join.ToList();
		}

		public static IList<TR> LeftOuterJoin<TA, TB, TK, TR>(
			this IEnumerable<TA> a,
			IEnumerable<TB> b,
			Func<TA, TK> selectKeyA,
			Func<TB, TK> selectKeyB,
			Func<TA, TB, TK, TR> projection,
			TB defaultB = default(TB),
			IEqualityComparer<TK> cmp = null)
		{
			cmp = cmp ?? EqualityComparer<TK>.Default;
			var alookup = a.ToLookup(selectKeyA, cmp);
			var blookup = b.ToLookup(selectKeyB, cmp);

			var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);

			var join = from key in keys
								 from xa in alookup[key]
								 from xb in blookup[key].DefaultIfEmpty(defaultB)
								 select projection(xa, xb, key);

			return join.ToList();
		}


		// Max from List

		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
			Func<TSource, TKey> selector)
		{
			return source.MaxBy(selector, null);
		}

		public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
			Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			comparer = comparer ?? Comparer<TKey>.Default;

			using (var sourceIterator = source.GetEnumerator())
			{
				if (!sourceIterator.MoveNext())
					throw new InvalidOperationException("Sequence contains no elements");

				var max = sourceIterator.Current;
				var maxKey = selector(max);

				while (sourceIterator.MoveNext())
				{
					var candidate = sourceIterator.Current;
					var candidateProjected = selector(candidate);
					if (comparer.Compare(candidateProjected, maxKey) > 0)
					{
						max = candidate;
						maxKey = candidateProjected;
					}
				}

				return max;
			}
		}

	}
}
