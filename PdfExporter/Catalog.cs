// Catalog.cs
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
	/// Summary description for Trailer.
	/// </summary>
	public class Catalog : PDFDictionary
	{
		Name _outlines = new Name(@"Outlines");
		Name _pages = new Name(@"Pages");
		Name _info = new Name(@"PageMode");
	
		/// <summary>
		/// Create a catalog object
		/// </summary>
		public Catalog() :base()
		{
			// Define this as catalog
			base.Add (new Name ("Type"), new Name ("Catalog"));
		}

		/// <summary>
		/// Reference to the outline object
		/// </summary>
		public Reference Outlines 
		{
			get
			{
				if (base.Exists(_outlines))
				{
					return (Reference) base[_outlines];
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (base.Exists(_outlines))
				{
					base.Remove (_outlines);
				}
				base.Add (_outlines,value);
			}
		}

		/// <summary>
		/// Reference to the pages object
		/// </summary>
		public Reference Pages
		{
			get
			{
				if (base.Exists(_pages))
				{
					return (Reference) base[_pages];
				}
				else
				{
					return null;
				}
			}
			set 
			{
				if (base.Exists(_pages))
				{
					base.Remove (_pages);
				}
				base.Add (_pages,value);
			}
		}

		/// <summary>
		/// Reference to the Info object
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
	}
}