using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;
using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class MapTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Map()
			{
				Map.FluentNHibernateNames.Map.ShouldBeEqualTo("Map");
			}
		}

		[TestFixture]
		public class When_asked_to_convert_a_property_column
		{
			[Test]
			public void Should_emit_Column_name()
			{
				const string input = @"
					<property name=""LastName"" type=""String"">
						<column name=""LAST_NAME"" sql-type=""VARCHAR2"" not-null=""false""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected, result);
			}

			[Test]
			public void Should_emit_Not_Nullable_if_present_in_original_xml()
			{
				const string input = @"
					<property name=""LastName"" type=""String"">
						<column name=""LAST_NAME"" sql-type=""VARCHAR2"" not-null=""true""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"")
						." + Nullability.FluentNHibernateNames.Not + @"." + Nullability.FluentNHibernateNames.Nullable + @"();").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_Length_if_present_in_original_xml()
			{
				const string input = @"
					<property name=""LastName"" type=""String"">
						<column name=""LAST_NAME"" length=""50"" sql-type=""VARCHAR2"" not-null=""false""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"")
						." + Length.FluentNHibernateNames.Length + @"(50);").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_CustomType_if_present_in_original_xml()
			{
				const string input = @"
					<property name=""LastName"" type=""YesNo"">
						<column name=""LAST_NAME"" sql-type=""CHAR""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"")
						." + CustomType.FluentNHibernateNames.CustomType + @"(""YesNo"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_Unique_if_present_in_original_xml()
			{
				const string input = @"
					<property name=""LastName"" type=""bool"" unique=""true"">
						<column name=""LAST_NAME"" sql-type=""CHAR""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"")
						." + Unique.FluentNHibernateNames.Unique + @"();").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_Index_if_present_in_original_xml()
			{
				const string input = @"
					<property name=""LastName"" type=""string"" index=""IX_LAST_NAME"">
						<column name=""LAST_NAME"" sql-type=""CHAR""/>
					</property>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Map.FluentNHibernateNames.Map + @"(x => x.LastName, ""LAST_NAME"")
						." + Index.FluentNHibernateNames.Index + @"(""IX_LAST_NAME"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}
		}
	}
}