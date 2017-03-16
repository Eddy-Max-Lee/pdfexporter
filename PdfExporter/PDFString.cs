// PDFString.cs
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
using System.IO;


namespace PDFLib.Objects.DataTypes
{
	/// <summary>
	/// Represents a string in accoring to PDF specfication
	/// </summary>
	public class PDFString : Base 
	{	
		public PDFString(): base()
		{
		}
		
		public PDFString(string data): base( data.ToString())
		{
		}			
		
		/// <summary>
		/// Returns PDFSrting objects string representation
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "( " + base.ToString() + ") ";
		}			
	}	
}
