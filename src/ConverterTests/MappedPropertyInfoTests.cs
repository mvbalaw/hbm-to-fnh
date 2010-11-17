using NHibernateHbmToFluent.Converter;
using NUnit.Framework;

namespace ConverterTests
{
	public class MappedPropertyInfoTests
	{
		[TestFixture]
		public class When_asked_to_get_the_info_from_a_String_property
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"

					<property name=""LastName"" type=""String"">
						<column name=""LAST_NAME"" length=""50"" sql-type=""VARCHAR2"" not-null=""true""/>
					</property>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("LastName");
			}

			[Test]
			public void Should_get_the_correct_sql_type()
			{
				_info.SqlType.ShouldBeEqualTo("VARCHAR2");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("LAST_NAME");
			}

			[Test]
			public void Should_get_the_correct_max_length()
			{
				_info.MaxLength.ShouldBeEqualTo(50);
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_null_true()
			{
				_info.CanBeNull.ShouldBeEqualTo(false);
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("String");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_an_assigned_id_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<id name=""StateCode"" type=""String"" unsaved-value=""null"">
						<column name=""STATE_CODE"" length=""2"" sql-type=""VARCHAR2"" not-null=""true"" unique=""true"" index=""PK_STATES""/>
						<generator class=""assigned"" />
					</id>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("StateCode");
			}

			[Test]
			public void Should_get_the_correct_sql_type()
			{
				_info.SqlType.ShouldBeEqualTo("VARCHAR2");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("STATE_CODE");
			}

			[Test]
			public void Should_get_the_correct_max_length()
			{
				_info.MaxLength.ShouldBeEqualTo(2);
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_null_true()
			{
				_info.CanBeNull.ShouldBeEqualTo(false);
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_true()
			{
				_info.IsUnique.ShouldBeEqualTo(true);
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("String");
			}

			[Test]
			public void Should_get_the_correct_unique_index()
			{
				_info.UniqueIndex.ShouldBeEqualTo("PK_STATES");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_sequence_id_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<id name=""CountyId"" type=""Int32"" unsaved-value=""0"">
						<column name=""COUNTY_ID"" sql-type=""NUMBER"" not-null=""true"" unique=""true"" index=""PK_COUNTY""/>
						<generator class=""sequence""> 
							<param name=""sequence"">S_COUNTY_ID</param> 
						</generator> 
					</id>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("CountyId");
			}

			[Test]
			public void Should_get_the_correct_sql_type()
			{
				_info.SqlType.ShouldBeEqualTo("NUMBER");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("COUNTY_ID");
			}

			[Test]
			public void Should_get_the_correct_max_length()
			{
				_info.MaxLength.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_null_true()
			{
				_info.CanBeNull.ShouldBeEqualTo(false);
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_true()
			{
				_info.IsUnique.ShouldBeEqualTo(true);
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Int32");
			}

			[Test]
			public void Should_get_the_correct_unique_index()
			{
				_info.UniqueIndex.ShouldBeEqualTo("PK_COUNTY");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_many_to_one_number_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<many-to-one name=""CourtTypeCode"" class=""Mvba.Enterprise.Business.Code, Mvba.Enterprise.Business"">
						<column name=""COURT_TYPE_CODE_ID"" sql-type=""NUMBER"" not-null=""true"" index=""IX_COURT_COURTTYPECODEID""/>
					</many-to-one>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("CourtTypeCode");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("COURT_TYPE_CODE_ID");
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_null_true()
			{
				_info.CanBeNull.ShouldBeEqualTo(false);
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_unspecified()
			{
				_info.IsUnique.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Mvba.Enterprise.Business.Code");
			}

			[Test]
			public void Should_get_the_correct_unique_index()
			{
				_info.UniqueIndex.ShouldBeEqualTo("IX_COURT_COURTTYPECODEID");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_many_to_one_varchar_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<many-to-one name=""State"" class=""Mvba.Enterprise.Business.State, Mvba.Enterprise.Business"">
						<column name=""`STATE`"" length=""2"" sql-type=""VARCHAR2"" not-null=""true""/>
					</many-to-one>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("State");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("`STATE`");
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_null_true()
			{
				_info.CanBeNull.ShouldBeEqualTo(false);
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_unspecified()
			{
				_info.IsUnique.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Mvba.Enterprise.Business.State");
			}

			[Test]
			public void Should_get_the_correct_unique_index_given_not_specified()
			{
				_info.UniqueIndex.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_max_length()
			{
				_info.MaxLength.ShouldBeEqualTo(2);
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_set_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<set name=""TaxRecords"" inverse=""true"" cascade=""none""  table=""TAX_CALC_FILTER"" lazy=""true""  outer-join=""false"">
						<key column=""TAX_CALC_RUN_ID""/>
						<many-to-many  column=""SPTD_ID"" class=""Mvba.Enterprise.Business.TaxRecord, Mvba.Enterprise.Business""/>
					</set>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("TaxRecords");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("TAX_CALC_RUN_ID");
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_unspecified()
			{
				_info.IsUnique.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_nullability_given_not_specified()
			{
				_info.CanBeNull.ShouldBeEqualTo(true);
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Mvba.Enterprise.Business.TaxRecord");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_bag_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<bag name=""Clerks"" inverse=""true"" table=""CLERK"" lazy=""true"" order-by=""FIRST_NAME"">
						<key column =""COUNTY_ID""/>
						<one-to-many class=""Mvba.Enterprise.Business.Clerk, Mvba.Enterprise.Business""/>
					</bag>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("Clerks");
			}

			[Test]
			public void Should_get_the_correct_column_name()
			{
				_info.ColumnName.ShouldBeEqualTo("COUNTY_ID");
			}

			[Test]
			public void Should_get_the_correct_IsUnique_value_given_unspecified()
			{
				_info.IsUnique.ShouldBeNull();
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Mvba.Enterprise.Business.Clerk");
			}
		}

		[TestFixture]
		public class When_asked_to_get_the_info_from_a_component_column
		{
			private MappedPropertyInfo _info;

			[SetUp]
			public void BeforeEachTest()
			{
				const string input = @"
					<component name=""Address"" class=""Mvba.Enterprise.Business.Address, Mvba.Enterprise.Business"" insert=""true"" update=""true"">
						<property name=""Street"" column=""STREET"" type=""string"" not-null=""false"" ></property>
						<property name=""City"" column=""CITY"" type=""string"" not-null=""false"" ></property>
						<property name=""State"" column=""STATE"" type=""string"" not-null=""false"" ></property>
						<property name=""ZipCode"" column=""ZIPCODE"" type=""string"" not-null=""false"" ></property>
						<property name=""ZipPlus"" column=""ZIPPLUS"" type=""string"" not-null=""false"" ></property>
					</component>";
				_info = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>").Properties[0];
			}

			[Test]
			public void Should_get_the_correct_property_name()
			{
				_info.Name.ShouldBeEqualTo("Address");
			}

			[Test]
			public void Should_get_the_correct_return_type()
			{
				_info.ReturnType.ShouldBeEqualTo("Mvba.Enterprise.Business.Address");
			}
		}
	}
}