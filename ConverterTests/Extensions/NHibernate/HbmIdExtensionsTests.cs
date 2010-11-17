using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NUnit.Framework;

namespace ConverterTests.Extensions.NHibernate
{
	public class HbmIdExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_GetPropertyName
		{
			[Test]
			public void Should_get_the_correct_value()
			{
				const string expected = "FirstName";
				HbmId id = new HbmId
					{
						name = expected
					};
				string result = id.GetPropertyName();
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
				HbmId id = new HbmId
					{
						type1 = expected + ", mscorlib"
					};
				string result = id.GetReturnType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetSqlType
		{
			[Test]
			public void Should_get_the_correct_value_from_column()
			{
				const string expected = "VARCHAR2";
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										sqltype = expected
									}
							}
					};
				string result = id.GetSqlType();
				result.ShouldBeEqualTo(expected);
			}
		}

		[TestFixture]
		public class When_asked_to_GetColumnName
		{
			[Test]
			public void Should_get_the_correct_value_from_column_given_null_column()
			{
				const string expected = "FirstName";
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										name = expected
									}
							}
					};
				string result = id.GetColumnName();
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
				HbmId id = new HbmId
					{
						length = expected.ToString()
					};
				int? result = id.GetMaxLength();
				result.ShouldNotBeNull();
				result.Value.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_the_correct_value_from_column_given_null_length()
			{
				const int expected = 16;
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										length = expected.ToString()
									}
							}
					};
				int? result = id.GetMaxLength();
				result.ShouldNotBeNull();
				result.Value.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_null_length_and_column_length()
			{
				HbmId id = new HbmId
					{
						column = new[] {new HbmColumn()}
					};
				int? result = id.GetMaxLength();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_to_GetUniqueIndex
		{
			[Test]
			public void Should_get_the_correct_value_from_column()
			{
				const string expected = "Name";
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										index = expected
									}
							}
					};
				string result = id.GetUniqueIndex();
				result.ShouldNotBeNull();
				result.ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_get_null_given_null_index_and_column_index()
			{
				HbmId id = new HbmId
					{
						column = new[] {new HbmColumn()}
					};
				string result = id.GetUniqueIndex();
				result.ShouldBeNull();
			}
		}

		[TestFixture]
		public class When_asked_if_CanBeNull
		{
			[Test]
			public void Should_get_null_given_column_is_null()
			{
				HbmId id = new HbmId
					{
						column = null
					};
				bool? result = id.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_column_notnullSpecified_is_false()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										notnullSpecified = false
									}
							}
					};
				bool? result = id.CanBeNull();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_column_notnullSpecified_is_true_and_notnull_is_false()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										notnullSpecified = true,
										notnull = false
									}
							}
					};
				bool? result = id.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_column_notnullSpecified_is_true_and_notnull_is_true()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										notnullSpecified = true,
										notnull = true
									}
							}
					};
				bool? result = id.CanBeNull();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}

		[TestFixture]
		public class When_asked_if_IsUnique
		{
			[Test]
			public void Should_get_null_given_column_is_null()
			{
				HbmId id = new HbmId
					{
						column = null
					};
				bool? result = id.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get_null_given_column_uniqueSpecified_is_false()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										uniqueSpecified = false
									}
							}
					};
				bool? result = id.IsUnique();
				result.ShouldBeNull();
			}

			[Test]
			public void Should_get__true__given_column_uniqueSpecified_is_true_and_column_unique_is_true()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										uniqueSpecified = true,
										unique = true
									}
							}
					};
				bool? result = id.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeTrue();
			}

			[Test]
			public void Should_get__false__given_column_uniqueSpecified_is_true_and_column_unique_is_false()
			{
				HbmId id = new HbmId
					{
						column = new[]
							{
								new HbmColumn
									{
										uniqueSpecified = true,
										unique = false
									}
							}
					};
				bool? result = id.IsUnique();
				result.ShouldNotBeNull();
				result.Value.ShouldBeFalse();
			}
		}
	}
}