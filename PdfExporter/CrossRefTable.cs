// CrossRefTable.cs
// Copyright (C) 2002 Shafqat Ahmed
// email	: raasiel@yahoo.com
// IM		: raasiel@hotmail.com
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// As a special exception, if you link this library with other files to
// produce an executable, this library does not by itself cause the
// resulting executable to be covered by the GNU General Public License.
// This exception does not however invalidate any other reasons why the
// executable file might be covered by the GNU General Public License.

// UPDATES
// 5 March 2002	:	Created the incode documentation 

using System;
using System.Text;
using System.Collections ;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
	/// <summary>
	/// The cross reference table i s the object that used for random access
	/// to the indirect objects defined in the PDF document
	/// </summary>
	public class CrossRefTable
	{
		private ArrayList  _arr= new ArrayList();
		
		/// <summary>
		/// Instantiate the CrossReference table
		/// </summary>
		public CrossRefTable()
		{
		}
		
		/// <summary>
		/// Add a cross reference entry
		/// </summary>
		/// <param name="cr">The corss referece object to add</param>
		public void Add (CrossRef cr)
		{
			_arr.Add (cr);
		}
		
		/// <summary>
		/// This objects offset
		/// </summary>
		public int Offset = 0;
		/// <summary>
		/// Its ID
		/// </summary>
		public int ID = 0;
		/// <summary>
		/// Its generation
		/// </summary>
		public int Generation = 0;
		
		/// <summary>
		/// Tring representation of the cross ref table
		/// </summary>
		/// <returns></returns>
		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append ("xref\n");
			sb.Append (Generation);			
			sb.Append (" ");
			sb.Append (new Number( _arr.Count  +1));
			sb.Append ("\n0000000000 65535 f");
			sb.Append ("\n");
			IEnumerator enu = _arr.GetEnumerator();
			while (enu.MoveNext())
			{				
				sb.Append (enu.Current);				
				sb.Append ("\n");
			}			
			return sb.ToString();
		}		
	}
}
