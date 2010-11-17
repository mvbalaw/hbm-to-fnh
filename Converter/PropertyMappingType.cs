using System;
using JetBrains.Annotations;
using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter.Extensions;
using NHibernateHbmToFluent.Converter.Extensions.NHibernate;
using NHibernateHbmToFluent.Converter.Types;

namespace NHibernateHbmToFluent.Converter
{
	public class PropertyMappingType : NamedConstant<PropertyMappingType>
	{
		public static readonly PropertyMappingType Id = new PropertyMappingType(typeof (HbmId),
		                                                                        "id",
		                                                                        x => ((HbmId) x).GetPropertyName(),
		                                                                        x => ((HbmId) x).GetColumnName(),
		                                                                        x => ((HbmId) x).GetMaxLength(),
		                                                                        x => ((HbmId) x).CanBeNull(),
		                                                                        x => ((HbmId) x).GetReturnType(),
		                                                                        x => ((HbmId) x).IsUnique(),
		                                                                        x => ((HbmId) x).GetUniqueIndex(),
		                                                                        x => ((HbmId) x).GetSqlType(),
		                                                                        (prefix, builder, item) => new Id(builder).Start(prefix, item));

		public static readonly PropertyMappingType Property = new PropertyMappingType(typeof (HbmProperty),
		                                                                              "property",
		                                                                              x => ((HbmProperty) x).GetPropertyName(),
		                                                                              x => ((HbmProperty) x).GetColumnName(),
		                                                                              x => ((HbmProperty) x).GetMaxLength(),
		                                                                              x => ((HbmProperty) x).CanBeNull(),
		                                                                              x => ((HbmProperty) x).GetReturnType(),
		                                                                              x => ((HbmProperty) x).IsUnique(),
		                                                                              x => ((HbmProperty) x).GetUniqueIndex(),
		                                                                              x => ((HbmProperty) x).GetSqlType(),
		                                                                              (prefix, builder, item) => new Map(builder).Start(prefix, item));

		public static readonly PropertyMappingType ManyToOne = new PropertyMappingType(typeof (HbmManyToOne),
		                                                                               "many-to-one",
		                                                                               x =>
		                                                                               ((HbmManyToOne) x).GetPropertyName(),
		                                                                               x => ((HbmManyToOne) x).GetColumnName(),
		                                                                               x => ((HbmManyToOne) x).GetMaxLength(),
		                                                                               x => ((HbmManyToOne) x).CanBeNull(),
		                                                                               x => ((HbmManyToOne) x).GetReturnType(),
		                                                                               x => ((HbmManyToOne) x).IsUnique(),
		                                                                               x =>
		                                                                               ((HbmManyToOne) x).GetUniqueIndex(),
		                                                                               x => ((HbmManyToOne) x).GetSqlType(),
		                                                                               (prefix, builder, item) => new References(builder).Start(prefix, item));

		public static readonly PropertyMappingType ManyToMany = new PropertyMappingType(typeof (HbmManyToMany),
		                                                                                "many-to-many",
		                                                                                null,
		                                                                                x =>
		                                                                                ((HbmManyToMany) x).GetColumnName(),
		                                                                                x => null,
		                                                                                null,
		                                                                                x =>
		                                                                                ((HbmManyToMany) x).GetReturnType(),
		                                                                                null,
		                                                                                null,
		                                                                                null,
		                                                                                (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

		public static readonly PropertyMappingType OneToOne = new PropertyMappingType(typeof (HbmOneToOne),
		                                                                              "one-to-one",
		                                                                              null,
		                                                                              null,
		                                                                              x => null,
		                                                                              null,
		                                                                              null,
		                                                                              null,
		                                                                              null,
		                                                                              null,
		                                                                              (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

		public static readonly PropertyMappingType OneToMany = new PropertyMappingType(typeof (HbmOneToMany),
		                                                                               "one-to-many",
		                                                                               null,
		                                                                               null,
		                                                                               x => null,
		                                                                               null,
		                                                                               x => ((HbmOneToMany) x).GetReturnType(),
		                                                                               null,
		                                                                               null,
		                                                                               null,
		                                                                               (prefix, builder, item) => builder.StartMethod(prefix, "?(x => x." + item.ReturnType + ")"));

		public static readonly PropertyMappingType Set = new PropertyMappingType(typeof (HbmSet),
		                                                                         "set",
		                                                                         x => ((HbmSet) x).GetPropertyName(),
		                                                                         x => ((HbmSet) x).GetColumnName(),
		                                                                         x => null,
		                                                                         x => ((HbmSet) x).CanBeNull(),
		                                                                         x => ((HbmSet) x).GetReturnType(),
		                                                                         x => ((HbmSet) x).IsUnique(),
		                                                                         x => null,
		                                                                         x => "NUMBER",
		                                                                         (prefix, builder, item) => new Set(builder).Start(prefix, item));

		public static readonly PropertyMappingType Bag = new PropertyMappingType(typeof (HbmBag),
		                                                                         "bag",
		                                                                         x => ((HbmBag) x).GetPropertyName(),
		                                                                         x => ((HbmBag) x).GetColumnName(),
		                                                                         x => null,
		                                                                         x => ((HbmBag) x).CanBeNull(),
		                                                                         x => ((HbmBag) x).GetReturnType(),
		                                                                         x => ((HbmBag) x).IsUnique(),
		                                                                         x => null,
		                                                                         x => "NUMBER",
		                                                                         (prefix, builder, item) => new Bag(builder).Start(prefix, item));

		public static readonly PropertyMappingType Component = new PropertyMappingType(typeof (HbmComponent),
		                                                                               "component",
		                                                                               x =>
		                                                                               ((HbmComponent) x).GetPropertyName(),
		                                                                               null,
		                                                                               x => null,
		                                                                               x => null,
		                                                                               x => ((HbmComponent) x).GetReturnType(),
		                                                                               x => null,
		                                                                               x => null,
		                                                                               null,
		                                                                               (prefix, builder, item) => new Component(builder).Start(prefix, item));

		public Type HbmType { get; private set; }
		public string XmlTagName { get; private set; }
		public Func<object, string> GetPropertyName { get; private set; }
		public Func<object, string> GetColumnName { get; private set; }
		public Func<object, int?> GetMaxLength { get; private set; }
		public Func<object, bool?> GetNullability { get; private set; }
		public Func<object, string> GetReturnType { get; private set; }
		public Func<object, bool?> GetIsUnique { get; private set; }
		public Func<object, string> GetUniqueIndex { get; private set; }
		public Func<object, string> GetColumnType { get; private set; }
		public Action<string, CodeFileBuilder, MappedPropertyInfo> StartMethod { get; set; }

		private PropertyMappingType(Type hbmType, string xmlTagName, Func<object, string> getPropertyName,
		                            Func<object, string> getColumnName, Func<object, int?> getMaxLength,
		                            Func<object, bool?> getNullability, Func<object, string> getReturnType,
		                            Func<object, bool?> getIsUnique, Func<object, string> getUniqueIndex,
		                            Func<object, string> getColumnType, Action<string, CodeFileBuilder, MappedPropertyInfo> startMethod)
		{
			HbmType = hbmType;
			XmlTagName = xmlTagName;
			GetPropertyName = getPropertyName;
			GetColumnName = getColumnName;
			GetMaxLength = getMaxLength;
			GetNullability = getNullability;
			GetReturnType = getReturnType;
			GetIsUnique = getIsUnique;
			GetUniqueIndex = getUniqueIndex;
			GetColumnType = getColumnType;
			StartMethod = startMethod;
			Add(xmlTagName.ToLower(), this);
			Add(hbmType.Name.ToLower(), this);
		}

		[NotNull]
		public static PropertyMappingType GetByXmlTagName(string typeName)
		{
			PropertyMappingType propertyMappingType = Get(typeName.ToLower());
			if (propertyMappingType == null)
			{
				throw new Exception("Received request for unsupported type '" + typeName + "'");
			}
			return propertyMappingType;
		}

		public static PropertyMappingType GetByHbmTypeName(string hbmTypeName)
		{
			PropertyMappingType propertyMappingType = Get(hbmTypeName.ToLower());
			if (propertyMappingType == null)
			{
				throw new Exception("Received request for unsupported type '" + hbmTypeName + "'");
			}
			return propertyMappingType;
		}
	}
}