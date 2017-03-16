// Trailer.cs
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
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
	/// <summary>
	/// Trailer object of a PDF document
	/// </summary>
	public class Trailer : PDFDictionary
	{
		Name _size = new Name(@"Size");
		Name _info = new Name(@"Info");
		Name _id = new Name(@"ID");
		Name _root = new Name(@"Root");		
		
		/// <summary>
		/// Create the trailer object
		/// </summary>
		public Trailer() :base()
		{
		}

		/// <summary>
		/// Size of the trailer
		/// </summary>
		public int Size
		{
			get
			{
				if (base.Exists(_size))
				{
					return (int) base[_size];
				}
				else
				{
					return 0;
				}
			}
			set 
			{
				if (base.Exists(_size))
				{
					base.Remove (_size);
				}
				base.Add (_size,value);
			}
		}

		/// <summary>
		/// Reference to the root object fo the document
		/// Should be reference to a catalog
		/// </summary>
		public Reference  Root
		{
			get
			{
				if (base.Exists(_root))
				{
					return (Reference) base[_root];
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (base.Exists(_root))
				{
					base.Remove (_root);
				}
				base.Add (_root,value);
			}
		}

		/// <summary>
		/// Reference to the information object
		/// </summary>
		public Reference Info
		{
			get
			{
				if (base.Exists(_info))
				{
					return (Reference) base[_info];
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (base.Exists(_info))
				{
					base.Remove (_info);
				}
				base.Add (_info,value);
			}
		}
		
		private int _crossRefStartOffset = 0;
		/// <summary>
		/// Offset of the cross reference table
		/// </summary>
		public int CrossRefStartOffset 
		{
			get {return _crossRefStartOffset;}
			set {_crossRefStartOffset = value;}
		}
		
		
		/// <summary>
		/// string representation of the Trailer object
		/// </summary>
		/// <returns></returns>
		public override string ToString ()
		{
			//this.Add (new Name ("ID"), "[<2976852b2067b0375f85a1284c66b3e6><2976852b2067b0375f85a1284c66b3e6>]\n");
			 return "trailer\n" + base.ToString()+ 
				"\nstartxref\n" + CrossRefStartOffset.ToString() + "\n%%EOF";
		}
	}
} 