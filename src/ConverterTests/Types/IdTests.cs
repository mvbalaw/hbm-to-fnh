using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;
using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class IdTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Id()
			{
				Id.FluentNHibernateNames.Id.ShouldBeEqualTo("Id");
			}
		}

		[TestFixture]
		public class When_asked_to_convert_an_Id_column
		{
			[Test]
			public void Should_emit_Column_name_if_present_in_original_xml()
			{
				const string input = @"
					<id name=""CountyId"" type=""Int32"">
						<column name=""COUNTY_ID"" sql-type=""NUMBER"" not-null=""true"" unique=""true"" index=""PK_COUNTY""/>
					</id>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Id.FluentNHibernateNames.Id + @"(x => x.CountyId)
						." + Column.FluentNHibernateNames.Column + @"(""COUNTY_ID"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_GeneratedBy_Sequence_if_present_in_original_xml()
			{
				const string input = @"
					<id name=""CountyId"" type=""Int32"">
						<column sql-type=""NUMBER"" not-null=""true"" unique=""true"" index=""PK_COUNTY""/>
						<generator class=""sequence""> 
							<param name=""sequence"">S_COUNTY_ID</param> 
						</generator> 
					</id>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Id.FluentNHibernateNames.Id + @"(x => x.CountyId)
						." + GeneratedBy.FluentNHibernateNames.GeneratedBy + @"." + GeneratedBy.FluentNHibernateNames.Sequence + @"(""S_COUNTY_ID"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_GeneratedBy_Assigned_if_present_in_original_xml()
			{
				const string input = @"
					<id name=""CountyId"" type=""Int32"">
						<column sql-type=""NUMBER"" not-null=""true"" unique=""true"" index=""PK_COUNTY""/>
						<generator class=""assigned"" />
					</id>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Id.FluentNHibernateNames.Id + @"(x => x.CountyId)
						." + GeneratedBy.FluentNHibernateNames.GeneratedBy + @"." + GeneratedBy.FluentNHibernateNames.Assigned + @"();").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_UnsavedValue_if_present_in_original_xml()
			{
				const string input = @"
					<id name=""CountyId"" type=""Int32"" unsaved-value=""0"">
						<column sql-type=""NUMBER"" not-null=""true"" unique=""true"" index=""PK_COUNTY""/>
					</id>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + Id.FluentNHibernateNames.Id + @"(x => x.CountyId)
						." + UnsavedValue.FluentNHibernateNames.UnsavedValue + @"(0);").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}
		}
	}
}