#region Header
/**
 * JsonException.cs
 *   Base class throwed by LitJSON when a parsing error occurs.
 *
 * The authors disclaim copyright to this source code. For more details, see
 * the COPYING file included with this distribution.
 **/
#endregion


using System;
using System.IO;
using System.Reflection;


namespace THOR.Serialization.JSON
{
	public class JsonException : ApplicationException
	{
		public JsonException()
			: base()
		{
		}

		internal JsonException(ParserToken token) :
			base(String.Format(
				   "Invalid token '{0}' in input string", token))
		{
		}

		internal JsonException(ParserToken token,
								Exception inner_exception) :
			base(String.Format(
					"Invalid token '{0}' in input string", token),
				inner_exception)
		{
		}

		internal JsonException(int c) :
			base(String.Format(
				   "Invalid character '{0}' in input string", (char)c))
		{
		}

		internal JsonException(int c, Exception inner_exception) :
			base(String.Format(
				   "Invalid character '{0}' in input string", (char)c),
			   inner_exception)
		{
		}


		public JsonException(string message)
			: base(message)
		{
		}

		public JsonException(string message, Exception inner_exception) :
			base(message, inner_exception)
		{
		}


		private TextReader reader;
		public TextReader OwnerReader
		{
			get
			{
				return reader;
			}
			set
			{

				reader = value;

				try
				{
					BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
					Type type = reader.GetType();
					FieldInfo field = type.GetField("_pos", flag);
					ReaderPosition = (int)field.GetValue(reader);
				}
				catch
				{
				}

				//-----

				try
				{
					BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
					Type type = reader.GetType();
					FieldInfo field = type.GetField("_s", flag);
					ReaderString = (string)field.GetValue(reader);
				}
				catch
				{
				}
			}
		}

		public int ReaderPosition { get; protected set; }
		public string ReaderString { get; protected set; }
	}
}
