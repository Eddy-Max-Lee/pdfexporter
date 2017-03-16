using System;
using System.Text;
using System.Collections;

namespace PDFLib.Objects
{
	/// <summary>
	/// Summary description for ProcSet.
	/// </summary>
	public class ProcSet:ArrayList 
	{
		public ProcSet():base()
		{
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			IEnumerator enu = base.GetEnumerator();
			sb.Append ("[ \n");
			while (enu.MoveNext())
			{
				sb.Append (enu.Current);
			}
			sb.Append ("\n]");
			return sb.ToString();
		}		
		
		
	}
}
