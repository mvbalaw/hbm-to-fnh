using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NHibernateHbmToFluent.Converter
{
	public class CodeFileBuilder
	{
		private readonly StringBuilder _sb = new StringBuilder();
		private int _indentLevel;

		public void StartMethod(string methodPrototype)
		{
			StartBlock(methodPrototype);
		}

		public void AddProperty(string name, string getBody, string setBody, bool isStatic, bool isOverride)
		{
			StartBlock("public " + (isOverride ? "override " : "") + (isStatic ? "static " : "") + "string " + name);
			{
				if (getBody != null)
				{
					if (getBody.IndexOf(Environment.NewLine) == -1)
					{
						AddLine("get { " + getBody + " }");
					}
					else
					{
						StartBlock("get");
						{
							AddLine(getBody);
						}
						EndBlock();
					}
				}
				if (setBody != null)
				{
					if (setBody.IndexOf(Environment.NewLine) == -1)
					{
						AddLine("set { " + setBody + " }");
					}
					else
					{
						StartBlock("set");
						{
							AddLine(setBody);
						}
						EndBlock();
					}
				}
			}
			EndBlock();
		}

		public void AddComment(string comment)
		{
			AddLine("// " + comment);
		}

		public void StartRegion(string name)
		{
			AddLine("");
			AddLine("#region " + name);
			AddLine("");
		}

		public void EndRegion()
		{
			AddLine("");
			AddLine("#endregion");
		}

		public void StartClass(string name, bool isPartial, bool isStatic)
		{
			StartBlock("public" + (isPartial ? " partial" : "") + (isStatic ? " static" : "") + " class " + name);
		}

		public void StartNamespace(string @namespace)
		{
			AddLine("");
			StartBlock("namespace " + @namespace);
		}

		public void AddUsing(string s)
		{
			AddLine(string.Format("using {0};", s));
		}

		private void StartBlock(string header)
		{
			AddLine(header);
			StartBlock();
		}

		public void StartBlock()
		{
			AddLine("{");
			Indent();
		}

		public void EndBlock()
		{
			Unindent();
			AddLine("}");
		}

		public void AddLine(string line)
		{
			if (!String.IsNullOrEmpty(line))
			{
				_sb.AppendFormat("{0}{1}{2}", GetTabs(), line, Environment.NewLine);
			}
			else
			{
				_sb.Append(Environment.NewLine);
			}
		}

		private string GetTabs()
		{
			return "".PadLeft(_indentLevel, '\t');
		}

		public void Indent()
		{
			_indentLevel++;
		}

		public void Indent(int count)
		{
			_indentLevel += count;
		}

		public void Unindent()
		{
			_indentLevel--;
		}

		public override string ToString()
		{
			return Regex.Replace(_sb.ToString(), "\r\n\t+;", ";", RegexOptions.Multiline | RegexOptions.Compiled);
		}
	}
}