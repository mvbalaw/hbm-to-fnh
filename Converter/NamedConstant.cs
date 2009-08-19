using System;
using System.Collections.Generic;

namespace NHibernateHbmToFluent.Converter
{
	[Serializable]
#pragma warning disable 661,660
	public class NamedConstant<T>
#pragma warning restore 661,660
		where T : class
	{
		private static readonly Dictionary<string, T> NamedConstants = new Dictionary<string, T>();

		protected void Add(string key, T item)
		{
			NamedConstants.Add(key, item);
		}

		protected static T Get(string key)
		{
			if (key == null)
			{
				return null;
			}
			T t;
			NamedConstants.TryGetValue(key, out t);
			return t;
		}

		public static bool operator ==(NamedConstant<T> a, NamedConstant<T> b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (((object) a == null) || ((object) b == null))
			{
				return false;
			}

			return a.Equals(b);
		}

		public static bool operator !=(NamedConstant<T> a, NamedConstant<T> b)
		{
			return !(a == b);
		}
	}
}