using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;

namespace ConverterTests
{
	public static class AssertExtensions
	{
		public static void ShouldBeGreaterThan<T>(this T item, [NotNull] T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item));
		}

		public static void ShouldBeGreaterThan<T>(this T item, [NotNull] T lowEndOfRange, string errorMessage)
			where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item), errorMessage);
		}


		public static void ShouldBeLessThan<T>(this T item, [NotNull] T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThan(highEndOfRange).Matches(item));
		}

		public static void ShouldBeGreaterThanOrEqualTo<T>(this T item, [NotNull] T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThanOrEqualTo(lowEndOfRange).Matches(item));
		}

		public static void ShouldBeLessThanOrEqualTo<T>(this T item, [NotNull] T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThanOrEqualTo(highEndOfRange).Matches(item));
		}

		public static void ShouldBeInRangeInclusive<T>(this T item, [NotNull] T lowEndOfRange, [NotNull] T highEndOfRange)
			where T : IComparable
		{
			item.ShouldBeGreaterThanOrEqualTo(lowEndOfRange);
			item.ShouldBeLessThanOrEqualTo(highEndOfRange);
		}

		public static void ShouldBeEqualTo<T>(this IList<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			list.ToList().ShouldContainAll(expected);
			expected.ToList().ShouldContainAll(list);
		}

		public static void ShouldBeEqualTo<T>(this T item, T expected)
		{
			Assert.AreEqual(expected, item);
		}

		public static void ShouldBeEqualTo<T>(this T? item, T? expected) where T : struct
		{
			Assert.AreEqual(expected, item);
		}

		public static void ShouldBeEqualTo<T>(this T item, T expected, [NotNull] string errorMessage)
		{
			Assert.AreEqual(expected, item, errorMessage);
		}

		public static void ShouldNotBeEqualTo<T>(this T item, T expected)
		{
			Assert.AreNotEqual(expected, item);
		}

		public static void ShouldNotBeEqualTo<T>(this T item, T expected, [NotNull] string errorMessage)
		{
			Assert.AreNotEqual(expected, item, errorMessage);
		}

		public static void ShouldStartWith(this string item, [NotNull] string expected, [NotNull] string errorMessage)
		{
			item.StartsWith(expected).ShouldBeTrue(errorMessage);
		}

		public static void ShouldBeTrue(this bool item)
		{
			Assert.IsTrue(item);
		}

		public static void ShouldBeTrue(this bool item, [NotNull] string errorMessage)
		{
			Assert.IsTrue(item, errorMessage);
		}

		public static void ShouldBeFalse(this bool item)
		{
			Assert.IsFalse(item);
		}

		public static void ShouldBeEmpty(this IList item)
		{
			item.ShouldNotBeNull();
			item.Count.ShouldBeEqualTo(0);
		}

		public static void ShouldBeEmpty<T>(this IList<T> item)
		{
			item.ShouldNotBeNull();
			item.Count.ShouldBeEqualTo(0);
		}

		public static void ShouldContain(this string item, string expectedSubstring)
		{
			item.Contains(expectedSubstring).ShouldBeTrue();
		}

		public static void ShouldContainAll<T>(this List<T> collection, IEnumerable<T> expected) where T : IEquatable<T>
		{
			foreach (T item in expected)
			{
				collection.Any(x => x.Equals(item)).ShouldBeTrue("Collection does not contain '" + item + "'");
			}
		}

		public static void ShouldBeFalse(this bool item, [NotNull] string errorMessage)
		{
			Assert.IsFalse(item, errorMessage);
		}

		public static void ShouldBeNull<T>(this T item)
		{
			Assert.IsNull(item);
		}

		public static void ShouldBeNull<T>(this T item, [NotNull] string errorMessage) where T : class
		{
			Assert.IsNull(item, errorMessage);
		}

		public static void ShouldNotBeNull<T>([CanBeNull] this T item) where T : class
		{
			Assert.IsNotNull(item);
		}

		public static void ShouldNotBeNull<T>([NotNull] this T? item) where T : struct
		{
			Assert.IsTrue(item.HasValue);
		}

		public static void ShouldNotBeNull<T>([NotNull] this T item, [NotNull] string errorMessage) where T : class
		{
			Assert.IsNotNull(item, errorMessage);
		}
	}
}