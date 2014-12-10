using System;
using System.IO;
using FluentNHibernate.Conventions.Helpers;
using NHibernateHbmToFluent.Converter.Methods.Join;

namespace NHibernateHbmToFluent.Converter
{
	public class MappingConverter
	{
		private readonly Action<string> _writeToConsole;
		private readonly Action<string> _writeToError;

		public MappingConverter(Action<string> writeToConsole, Action<string> writeToError)
		{
			_writeToConsole = writeToConsole;
			_writeToError = writeToError;
		}

		public void ConvertAll(string hbmDirectory, string mapDirectory, string nameSpace)
		{
			string[] files = Directory.GetFiles(hbmDirectory, "*" + HbmFileUtility.NHibernateFileExtension);
			foreach (string hbmFilePath in files)
			{
				try
				{
					_writeToConsole(hbmFilePath);
                    foreach (var classInfo in HbmFileUtility.LoadFile(hbmFilePath))
				    {
                        string classNameAndNamespace = classInfo.ClassName;
                        int dotLoc = classNameAndNamespace.LastIndexOf('.');
                        string className = classNameAndNamespace;
                        if (dotLoc != -1)
                        {
                            className = className.Substring(dotLoc + 1);
                        }
                        string classMapName = className + "Map";
                        string result = Convert(classMapName, classInfo, nameSpace);
                        File.WriteAllText(Path.Combine(mapDirectory, classMapName + ".cs"), result);
				    }
				}
				catch (Exception ex)
				{
					_writeToError("Caught exception processing file " + Path.GetFileName(hbmFilePath) + ": " + ex);
				}
			}
			_writeToConsole("done...");
		}

		public static string Convert(string classMapName, MappedClassInfo classInfo, string nameSpace)
		{
			CodeFileBuilder builder = new CodeFileBuilder();
			builder.AddUsing("System");
			builder.AddUsing("FluentNHibernate.Mapping");
			builder.StartNamespace(nameSpace);
			{
				builder.StartClass(classMapName + ": ClassMap<" + classInfo.ClassName + ">", false, false);
				{
					builder.StartMethod("public " + classMapName + "()");
					{
						if (!String.IsNullOrEmpty(classInfo.TableName))
						{
							builder.AddLine(FluentNHibernateNames.Table + "(\"" + classInfo.TableName + "\");");
						}

                        new CacheBuilder(builder).Add(classInfo.Cache, true);

                        if (!classInfo.Mutable)
                        {
                            builder.AddLine("ReadOnly();");
                        }

                        ClassMapBody bodyBuilder = new ClassMapBody(builder);
						foreach (var info in classInfo.Properties)
						{
							bodyBuilder.Add("", info);
						}
					}
					builder.EndBlock();
				}
				builder.EndBlock();
			}
			builder.EndBlock();
			return builder.ToString();
		}

		public static class FluentNHibernateNames
		{
			public static string Table
			{
				get { return typeof (FakeMap).GetMethod("Table").Name; }
			}

			public static string ClassMap
			{
				get
				{
					string name = typeof (FakeMap).BaseType.Name;
					int index = name.IndexOf('`');
					if (index != -1)
					{
						name = name.Substring(0, index);
					}
					return name;
				}
			}
		}
	}
}