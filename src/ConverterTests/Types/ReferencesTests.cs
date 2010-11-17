using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Methods;
using NHibernateHbmToFluent.Converter.Types;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class ReferencesTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__References()
			{
				References.FluentNHibernateNames.References.ShouldBeEqualTo("References");
			}
		}

		[TestFixture]
		public class When_asked_to_convert_a_many_to_one_column
		{
			[Test]
			public void Should_emit_Column_name_if_present_in_original_xml()
			{
				const string input = @"
					<many-to-one name=""State"" class=""Mvba.Enterprise.Business.State, Mvba.Enterprise.Business"">
						<column name=""`STATE`"" length=""2"" sql-type=""VARCHAR2""/>
					</many-to-one>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + References.FluentNHibernateNames.References + @"(x => x.State)
						." + Column.FluentNHibernateNames.Column + @"(""`STATE`"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected, result);
			}

			[Test]
			public void Should_emit_Not_Nullable_if_present_in_original_xml()
			{
				const string input = @"
					<many-to-one name=""State"" class=""Mvba.Enterprise.Business.State, Mvba.Enterprise.Business"">
						<column length=""2"" sql-type=""VARCHAR2"" not-null=""true""/>
					</many-to-one>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + References.FluentNHibernateNames.References + @"(x => x.State)
						." + Nullability.FluentNHibernateNames.Not + @"." + Nullability.FluentNHibernateNames.Nullable + @"();").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}

			[Test]
			public void Should_emit_Index_if_present_in_original_xml()
			{
				const string input = @"
					<many-to-one name=""State"" class=""Mvba.Enterprise.Business.State, Mvba.Enterprise.Business"">
						<column length=""2"" sql-type=""VARCHAR2"" index=""IX_STATE""/>
					</many-to-one>";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (@"
					" + References.FluentNHibernateNames.References + @"(x => x.State)
						." + Index.FluentNHibernateNames.Index + @"(""IX_STATE"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}
		}
	}
}