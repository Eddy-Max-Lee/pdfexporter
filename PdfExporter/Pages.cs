// Pages.cs
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
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;


namespace PDFLib.Objects
{
	/// <summary>
	/// Pages object
	/// </summary>
	public class Pages : PDFDictionary
	{
		PDFArray _arrkids = new PDFArray ();		

		private Name _count = new Name("Count");
		private Name _Kids = new Name("Kids");
		
		/// <summary>
		/// Craete a pages object
		/// </summary>
		public Pages() :base()
		{
			base.Add (new Name ("Type"), new Name ("Pages"));			
			base.Add (_Kids, _arrkids);
		}
		
		/// <summary>
		/// Adds a reference to a page object
		/// </summary>
		/// <param name="refToPage">The reference to the page object</param>
		/// <returns>True is sucess</returns>
		public bool AddPageRef ( Reference  refToPage)
		{
			if (refToPage.ReferredObject.ReferredObject is Page)
			{
				_arrkids.Add (refToPage);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// Removes the page reference
		/// </summary>
		/// <param name="refToPage">Reference to the page to remove</param>
		/// <returns>True if success</returns>
		public bool RemovePageRef ( Reference  refToPage)
		{
			if (refToPage.ReferredObject.ReferredObject is Page)
			{
				_arrkids.Remove  (refToPage);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		/// <summary>
		/// Removes page by index
		/// </summary>
		/// <param name="index">Index to the page reference to be removes</param>
		/// <returns>True if success</returns>
		public bool RemovePageRefAt ( int index)
		{
			_arrkids.RemoveAt (index);
			return true;
		}
		
		/// <summary>
		/// Numbe rof pages referred
		/// </summary>
		public int PageCount
		{
			get{return _arrkids.Count;}
		}
		
		/// <summary>
		/// The pages array
		/// </summary>
		public PDFArray Kids 
		{
			get{return _arrkids;}
		}

		/// <summary>
		/// Represents the pages object
		/// </summary>
		/// <returns>String representation of the pages object</returns>
		public override string ToString ()
		{
			if (base.Exists (_count))
			{
				base.Remove(_count);
			}
			base.Add (_count, new Number (this.PageCount));
			return base.ToString();
		}
	}
}