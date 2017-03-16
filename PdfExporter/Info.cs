using System;
using System.Text;
using PDFLib;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
	/// <summary>
	/// Summary description for Info.
	/// </summary>
	public class Info
	{
		public Info()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append ("<< \n");
			sb.Append ("/ModDate (D:20020306011115+06'00')\n");
			sb.Append ("/CreationDate (D:20020306011115+06'00')\n");
			sb.Append (">> ");
			
			return sb.ToString();
		}
		
	}
}
