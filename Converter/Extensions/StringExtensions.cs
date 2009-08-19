using System;

namespace NHibernateHbmToFluent.Converter.Extensions
{
	public static class StringExtensions
	{
		public static string GetTypeName(this string fullTypeDescriptor)
		{
			int commaLoc = fullTypeDescriptor.IndexOf(',');
			if (commaLoc > -1)
			{
				return fullTypeDescriptor.Substring(0, commaLoc);
			}
			return fullTypeDescriptor;
		}

		public static int? ParseInt32(this string input)
		{
			try
			{
				return Int32.Parse(input);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}