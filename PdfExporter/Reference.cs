// Reference.cs
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

namespace PDFLib.Objects.DataTypes
{
	/// <summary>
	/// The reference object refers to an indirect object.
	/// </summary>
	public class Reference
	{
		private IndirectObject _object = null;
		/// <summary>
		/// Creates a reference object 
		/// </summary>
		/// <param name="obj">The objetc to refer to</param>
		public Reference(IndirectObject obj)
		{		
			_object = obj;
		}				

		/// <summary>
		/// String representation of the reference object
		/// </summary>
		/// <returns>String representation of the reference object</returns>		
		public override string ToString()
		{
			return _object.ObjectID + " " + _object.GenarationNumber + " R " ;
		}

		/// <summary>
		/// Points to the the referred indirect object
		/// </summary>		
		public IndirectObject ReferredObject
		{
			get { return _object;}
			set { _object = value;}
		}		
	}	
}
