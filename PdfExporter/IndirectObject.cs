// IndirectObject.cs
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
using System.Text;

namespace PDFLib.Objects.DataTypes
{
	/// <summary>
	/// This class represents an indirect object according to PDF file 
	/// format. This has the referrable object inside it
	/// </summary>
	public class IndirectObject
	{
		private object _obj = null;
		
		/// <summary>
		/// Creates an indirect object
		/// </summary>
		/// <param name="obj">The object that is being made referrable</param>
		/// <param name="id">The id of the indirect object. The developer 
		/// should use PDFDocument.GetNextID() method to obtain this.</param>
		public IndirectObject(object obj, int id)
		{
			_obj = obj;
			ObjectID = id;
		}

		/// <summary>
		/// Basic Constructor
		/// </summary>
		public IndirectObject()
		{
		}

		// For storing the offset of the object. We need this to write 
		// to the cross reference table
		private int _offset=0;
		/// <summary>
		/// Byte offset of the indirect objects start.Required for
		/// generating the cross reference table
		/// </summary>
		public int Offset
		{
			get {return _offset;}
			set {_offset = value;}
		}
		
		private int _objectID = 0;		
		/// <summary>
		/// The id of the indirect object
		/// </summary>
		public int ObjectID
		{
			get { return _objectID;}
			set { _objectID = value;}
		}


		private int _genarationNumber = 0;
		/// <summary>
		/// Generation Number of the object
		/// </summary>
		public int GenarationNumber
		{
			get { return _genarationNumber;}
			set { _genarationNumber = value;}
		}
		
		/// <summary>
		/// The inner object that is being made referrable
		/// </summary>
		public object ReferredObject
		{
			get{ return _obj;}
			set{ _obj = value;}
		}
		
		/// <summary>
		/// String representaion of the indirect object
		/// </summary>
		/// <returns>String representaion of indirect object with the 
		/// referrable object intself wrapped inside.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (ObjectID);
			sb.Append (" ");
			sb.Append (GenarationNumber);
			sb.Append (" ");
			sb.Append ("obj\n");
			sb.Append (_obj.ToString());
			sb.Append ("\nendobj\n");
			return sb.ToString();			
		}

		/// <summary>
		/// The ID string of the object to be used as a key
		/// </summary>		
		public string ID
		{
			get { return ObjectID + " " + GenarationNumber + " obj";}
		}
	}
}
