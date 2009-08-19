using System.IO;

namespace NHibernateHbmToFluent.Converter
{
	public class MappedPropertyInfo
	{
		private readonly object _hbmObject;

		private string _name;
		private string _columnName;
		private int? _maxLength;
		private bool _haveMaxLength;
		private bool _haveNullability;
		private bool? _canBeNull;
		private string _returnType;
		private bool? _isUnique;
		private bool haveIsUnique;
		private string _uniqueIndex;
		private string _columnType;

		public MappedPropertyInfo(object nhibernateObject, string fileName)
		{
			_hbmObject = nhibernateObject;
			FileName = fileName;
			string type = Path.GetExtension(nhibernateObject.GetType().FullName).Substring(1);
			Type = PropertyMappingType.GetByHbmTypeName(type);
		}

		public T HbmObject<T>()
		{
			return (T) _hbmObject;
		}

		public string Name
		{
			get
			{
				if (_name == null)
				{
					_name = Type.GetPropertyName(_hbmObject);
				}
				return _name;
			}
		}

		public string ColumnName
		{
			get
			{
				if (_columnName == null)
				{
					_columnName = Type.GetColumnName(_hbmObject);
				}
				return _columnName;
			}
		}

		public int? MaxLength
		{
			get
			{
				if (!_haveMaxLength)
				{
					_maxLength = Type.GetMaxLength(_hbmObject);

					_haveMaxLength = true;
				}
				return _maxLength;
			}
		}

		public bool? CanBeNull
		{
			get
			{
				if (!_haveNullability)
				{
					_canBeNull = Type.GetNullability(_hbmObject);
					_haveNullability = true;
				}
				return _canBeNull;
			}
		}

		public string ReturnType
		{
			get
			{
				if (_returnType == null)
				{
					_returnType = Type.GetReturnType(_hbmObject);
				}
				return _returnType;
			}
		}

		public bool? IsUnique
		{
			get
			{
				if (!haveIsUnique)
				{
					_isUnique = Type.GetIsUnique(_hbmObject);
					haveIsUnique = true;
				}
				return _isUnique;
			}
		}

		public PropertyMappingType Type { get; private set; }

		public string SqlType
		{
			get
			{
				if (_columnType == null)
				{
					_columnType = Type.GetColumnType(_hbmObject);
				}
				return _columnType;
			}
		}

		public string UniqueIndex
		{
			get
			{
				if (_uniqueIndex == null)
				{
					_uniqueIndex = Type.GetUniqueIndex(_hbmObject);
				}
				return _uniqueIndex;
			}
		}

		public string FileName { get; private set; }
	}
}