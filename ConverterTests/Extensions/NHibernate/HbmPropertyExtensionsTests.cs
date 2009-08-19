using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmPropertyExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_GetPropertyName
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "FirstName";
				HbmProperty property = new HbmProperty
					{
						name = expected
					};
				string result = property.GetPropertyName();
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
				HbmProperty property = new HbmProperty
					{
						type1 = expected + ", mscorlib"
					};
				string result = property.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetSqlType
		{
			[Test]
			public void Should_get_the_correct_value_from_column_if_not_null()
			{
				const string expected = "VARCHAR2";
				HbmProperty property = new HbmProperty
				{
					column = expected
				};
				string result = property.GetSqlType();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_column()
			{
				const string expected = "VARCHAR2";
				HbmProperty property = new HbmProperty
					{
						Items = new object[]
							{
								new HbmColumn
									{
										sqltype = expected
									}
							}
					};
				string result = property.GetSqlType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_column_if_not_null()
			{
				const string expected = "FirstName";
				HbmProperty property = new HbmProperty
					{
						column = expected
					};
				string result = property.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_column()
			{
				const string expected = "FirstName";
				HbmProperty property = new HbmProperty
					{
						Items = new object[]
							{
								new HbmColumn
									{
										name = expected
									}
							}
					};
				string result = property.GetColumnName();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetMaxLength
		{
			[Test]
			public void Should_get_the_correct_value_from_length_if_not_null()
			{
				const int expected = 16;
				HbmProperty property = new HbmProperty
					{
						length = expected.ToString()
					};
				int? result = property.GetMaxLength();
				result.ShouldNotBeNull();
				result.Value.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_length()
			{
				const int expected = 16;
				HbmProperty property = new HbmProperty
					{
						Items = new object[]
							{
								new HbmColumn
									{
										length = expected.ToString()
									}
							}
					};
				int? result = property.GetMaxLength();
				result.ShouldNotBeNull();
				result.Value.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_null_length_and_Items_length()
			{
				HbmProperty property = new HbmProperty
					{
						Items = new object[] {new HbmColumn()}
					};
				int? result = property.GetMaxLength();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_to_GetUniqueIndex
		{
			[Test]
			public void Should_get_the_correct_value_from_index_if_not_null()
			{
				const string expected = "Name";
				HbmProperty property = new HbmProperty
					{
						index = expected
					};
				string result = property.GetUniqueIndex();
				result.ShouldNotBeNull();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_Items_given_null_index()
			{
				const string expected = "Name";
				HbmProperty property = new HbmProperty
					{
						Items = new object[]
							{
								new HbmColumn
									{
										index = expected
									}
							}
					};
				string result = property.GetUniqueIndex();
				result.ShouldNotBeNull();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_null_index_and_Items_index()
			{
				HbmProperty property = new HbmProperty
					{
						Items = new object[] {new HbmColumn()}
					};
				string result = property.GetUniqueIndex();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get__false__given_notnullSpecified_and_notnull_are_both_true()
			{
				HbmProperty property = new HbmProperty
					{
						notnullSpecified = true,
						notnull = true
					};
				bool? result = property.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}

			[Test]
			public void Should_get__true__given_notnullSpecified_is_true_and_notnull_is_false()
			{
				HbmProperty property = new HbmProperty
					{
						notnullSpecified = true,
						notnull = false
					};
				bool? result = property.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get_null_given_notnullSpecified_is_false_and_Items_is_null()
			{
				HbmProperty property = new HbmProperty
					{
						notnullSpecified = false,
						Items = null
					};
				bool? result = property.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_notnullSpecified_is_false_and_Items_notnullSpecified_is_false()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_notnullSpecified_is_false_and_Items_notnullSpecified_is_true_and_Items_notnull_is_false()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_notnullSpecified_is_false_and_Items_notnullSpecified_is_true_and_Items_notnull_is_true()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get__true__given_unique_is_true()
			{
				HbmProperty property = new HbmProperty
					{
						unique = true
					};
				bool? result = property.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_unique_is_false_and_Items_is_null()
			{
				HbmProperty property = new HbmProperty
					{
						unique = false,
						Items = null
					};
				bool? result = property.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}

			[Test]
			public void Should_get_null_given_unique_is_false_and_Items_uniqueSpecified_is_false()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_unique_is_false_and_Items_uniqueSpecified_is_true_and_Items_unique_is_true()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_unique_is_false_and_Items_uniqueSpecified_is_true_and_Items_unique_is_false()
			{
				HbmProperty property = new HbmProperty
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
				bool? result = property.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}
	}
}