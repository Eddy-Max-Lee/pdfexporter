// PDFDictionary.cs
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
// 4 March 2002	:	Created the incode documentation 


using System;
using System.Collections;
using System.Text;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects.DataTypes
{
	/// <summary>
	/// Represents a Dictionary object accoring to PDF file spcification.
	/// This is the base object for most of the objects in the PDF library
	/// </summary>	
	public class PDFDictionary : DictionaryBase 
	{
		/// <summary>
		/// Create a PDFDictinary object
		/// </summary>
		public PDFDictionary():base()
		{
		}
		
		/// <summary>
		/// Adds and object
		/// </summary>
		/// <param name="name">The key of the object</param>
		/// <param name="obj">the object to add</param>
		public void Add ( Name name, object obj)
		{
			Dictionary.Add (name, obj);
		}
		
		/// <summary>
		/// Removes an object
		/// </summary>
		/// <param name="name">key to the object to e removed</param>
		public void Remove ( Name name)
		{
			Dictionary.Remove (name);
		}
		
		/// <summary>
		/// Check if an object exists with the specified key
		/// </summary>
		/// <param name="name">The key to teh object</param>
		/// <returns>True if teh object already exist otherwise false</returns>
		public bool Exists ( Name name)
		{
			return InnerHashtable.ContainsKey (name);
		}

		private string _carriageReturn="\n";
		/// <summary>
		/// Carriage return symbol
		/// </summary>
		public string CarriageReturn
		{
			get{return _carriageReturn;}
			set{_carriageReturn = value;}
		}

		/// <summary>
		/// Indexer for the object with the key
		/// </summary>
		public object this[Name name]
		{
			get
			{
				return Dictionary[name];
			}
			set
			{				
				Add (name,value);
			}
		}
		
		
		/// <summary>
		/// String representation of the Dictionary object
		/// </summary>
		/// <returns>the string representation of the Dictionary object</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append ("<< ");
			sb.Append (CarriageReturn);
			foreach ( object key in InnerHashtable.Keys)
			{
				sb.Append (key);
				sb.Append (InnerHashtable[key]);
				sb.Append (CarriageReturn);
			}
			sb.Append (">> ");
			return sb.ToString();
		}
	}
}