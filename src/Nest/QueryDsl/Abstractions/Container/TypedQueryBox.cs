using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	internal abstract class TypedQueryBox
	{
		public abstract IQuery Query { get; }
	}

	internal class TypedQueryBox<T> : TypedQueryBox
		where T : IQuery
	{
		public T TypedQuery { get; set; }

		public override IQuery Query => TypedQuery;

		public TypedQueryBox(T query)
		{
			TypedQuery = query;
		}
	}
}
