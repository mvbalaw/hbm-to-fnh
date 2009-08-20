using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Extensions;
using NUnit.Framework;

namespace ConverterTests.Types
{
	public class MappingConverterTests
	{
		[TestFixture]
		public class When_asked_for_a_FluentNHibernate_name
		{
			[Test]
			public void Should_return_the_correct_value_for__Table()
			{
				MappingConverter.FluentNHibernateNames.Table.ShouldBeEqualTo("Table");
			}

			[Test]
			public void Should_return_the_correct_value_for__ClassMap()
			{
				MappingConverter.FluentNHibernateNames.ClassMap.ShouldBeEqualTo("ClassMap");
			}
		}

		[TestFixture]
		public class When_asked_to_Convert
		{
			[Test]
			public void Should_emit_Table_if_present_in_original_xml()
			{
				const string input = @"";
				MappedClassInfo classInfo = HbmFileUtility.LoadFromString(@"
					<hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
						<class name=""Mvba.Enterprise.Business.User, Mvba.Enterprise.Business"" table=""USERS"">" + input + @"</class>
					</hibernate-mapping>");

				string result = MappingConverter.Convert("CountyMap", classInfo, "Test");
				var expected = (MappingConverter.FluentNHibernateNames.Table + @"(""USERS"");").SplitOnFormattingWhitespace();
				ClassFileUtilities.GetConstructorContents(result, "CountyMap").ShouldBeEqualTo(expected);
			}
		}
	}
}