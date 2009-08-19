using System;
using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmManyToOneExtensionsTests
	{
		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get__true__given_unique_is_true()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						unique = true
					};
				bool? result = manyToOne.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test, ExpectedException(typeof (NullReferenceException))]
			public void Should_get_exception_given_unique_is_false_and_Items_is_null()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						unique = false,
						Items = null
					};
				manyToOne.IsUnique();
			}

			[Test]
			public void Should_get_null_given_unique_is_false_and_Items_uniqueSpecified_is_false()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						unique = false,
						Items = new object[]
							{
								new HbmColumn
									{
										uniqueSpecified = false
									}
							}
					};
				bool? result = manyToOne.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_unique_is_false_and_Items_uniqueSpecified_is_true_and_Items_unique_is_true()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						unique = false,
						Items = new object[]
							{
								new HbmColumn
									{
										uniqueSpecified = true,
										unique = true
									}
							}
					};
				bool? result = manyToOne.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_unique_is_false_and_Items_uniqueSpecified_is_true_and_Items_unique_is_false()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						unique = false,
						Items = new object[]
							{
								new HbmColumn
									{
										uniqueSpecified = true,
										unique = false
									}
							}
					};
				bool? result = manyToOne.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_to_GetMaxLength
		{
			[Test]
			public void Should_get_null_if_sqltype_is_not_a_string_or_array_type()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						column = "decimal"
					};
				int? result = manyToOne.GetMaxLength();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_if_sqltype_is_valid()
			{
				const int expected = 16;
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						column = "VARCHAR2",
						Items = new object[]
							{
								new HbmColumn
									{
										length = expected.ToString()
									}
							}
					};
				int? result = manyToOne.GetMaxLength();
				result.ShouldNotBeNull();
				result.Value.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_valid_sqltype_and_null_length_in_Items()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						column = "VARCHAR2",
						Items = new object[] {new HbmColumn()}
					};
				int? result = manyToOne.GetMaxLength();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_to_GetSqlType
		{
			[Test]
			public void Should_get_the_correct_value_from_column_if_not_null()
			{
				const string expected = "VARCHAR2";
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						column = expected
					};
				string result = manyToOne.GetSqlType();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_column()
			{
				const string expected = "VARCHAR2";
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						Items = new object[]
							{
								new HbmColumn
									{
										sqltype = expected
									}
							}
					};
				string result = manyToOne.GetSqlType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetUniqueIndex
		{
			[Test]
			public void Should_get_the_correct_value_from_index_if_not_null()
			{
				const string expected = "Name";
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						index = expected
					};
				string result = manyToOne.GetUniqueIndex();
				result.ShouldNotBeNull();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_index()
			{
				const string expected = "Name";
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						Items = new object[]
							{
								new HbmColumn
									{
										index = expected
									}
							}
					};
				string result = manyToOne.GetUniqueIndex();
				result.ShouldNotBeNull();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_null_index_and_Items_index()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						Items = new object[] {new HbmColumn()}
					};
				string result = manyToOne.GetUniqueIndex();
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
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						name = expected
					};
				string result = manyToOne.GetPropertyName();
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
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						@class = expected + ", mscorlib"
					};
				string result = manyToOne.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get__false__given_notnullSpecified_and_notnull_are_both_true()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = true,
						notnull = true
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}

			[Test]
			public void Should_get__true__given_notnullSpecified_is_true_and_notnull_is_false()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = true,
						notnull = false
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test, ExpectedException(typeof (NullReferenceException))]
			public void Should_get_exception_given_notnullSpecified_is_false_and_Items_is_null()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = false,
						Items = null
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_notnullSpecified_is_false_and_Items_notnullSpecified_is_false()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = false,
						Items = new object[]
							{
								new HbmColumn
									{
										notnullSpecified = false
									}
							}
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_notnullSpecified_is_false_and_Items_notnullSpecified_is_true_and_Items_notnull_is_false()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = false,
						Items = new object[]
							{
								new HbmColumn
									{
										notnullSpecified = true,
										notnull = false
									}
							}
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_notnullSpecified_is_false_and_Items_notnullSpecified_is_true_and_Items_notnull_is_true()
			{
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						notnullSpecified = false,
						Items = new object[]
							{
								new HbmColumn
									{
										notnullSpecified = true,
										notnull = true
									}
							}
					};
				bool? result = manyToOne.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_Items()
			{
				const string expected = "FirstName";
				HbmManyToOne manyToOne = new HbmManyToOne
					{
						Items = new object[]
							{
								new HbmColumn
									{
										name = expected
									}
							}
					};
				string result = manyToOne.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}
		}
	}
}