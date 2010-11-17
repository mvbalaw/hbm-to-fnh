namespace NHibernateHbmToFluent.Converter.Types
{
	public interface IMapStart
	{
		void Start(string prefix, MappedPropertyInfo item);
	}
}