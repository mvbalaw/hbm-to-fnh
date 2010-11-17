using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmBagExtensionsTests
	{
		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get__true__given_key_uniqueSpecified_and_unique_are_true()
			{
				HbmBag bag = new HbmBag
					{
						key = new HbmKey
							{
								uniqueSpecified = true,
								unique = true
							}
					};
				bool? result = bag.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_key_uniqueSpecified_is_true_and_unique_is_false()
			{
				HbmBag bag = new HbmBag
					{
						key = new HbmKey
							{
								uniqueSpecified = true,
								unique = false
							}
					};
				bool? result = bag.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}

			[Test]
			public void Should_get_null_given_key_uniqueSpecified_is_false()
			{
				HbmBag bag = new HbmBag
					{
						key = new HbmKey
							{
								uniqueSpecified = false,
								unique = true
							}
					};
				bool? result = bag.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_key_is_null()
			{
				HbmBag bag = new HbmBag
					{
						key = null
					};
				bool? result = bag.IsUnique();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_to_GetPropertyName
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "FirstName";
				HbmBag bag = new HbmBag
					{
						name = expected
					};
				string result = bag.GetPropertyName();
				result.ShouldBeEqualTo(expected);
			}
		}


		[TestFixture]
		public class When_asked_to_GetReturnType
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "System.String";
				HbmBag bag = new HbmBag
					{
						Item = new HbmOneToMany
							{
								@class = expected + ", mscorlib"
							}
					};
				string result = bag.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_key()
			{
				const string expected = "FirstName";
				HbmBag bag = new HbmBag
					{
						key = new HbmKey
							{
								column1 = expected
							}
					};
				string result = bag.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get__true__given_inverse_is_true()
			{
				HbmBag bag = new HbmBag
					{
						inverse = true
					};
				bool? result = bag.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_inverse_is_false()
			{
				HbmBag bag = new HbmBag
					{
						inverse = false
					};
				bool? result = bag.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}
	}
}