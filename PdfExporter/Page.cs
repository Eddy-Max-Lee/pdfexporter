// Page.cs
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
	/// A page in the PDF document
	/// </summary>
	public class Page : PDFDictionary
	{		
		private Name _parent  = new Name ("Parent");
		private Name _mediaBox  = new Name ("MediaBox");
		private Name _contents = new Name ("Contents");
		private Name _resources = new Name ("Resources");		
		
		/// <summary>
		/// Instantiate a page object
		/// </summary>
		public Page():base()
		{				
			base.Add (new Name("Type"),new Name ("Page"));			
		}

		/// <summary>
		/// Instantiate a page object 
		/// </summary>
		/// <param name="pages">Pages object the contains this page</param>
		public Page(IndirectObject indPages):base()
		{				
			base.Add (new Name("Type"),new Name ("Page"));			
			this.Parent = new Reference (indPages);
		}


		/// <summary>
		/// Instantiate a page object
		/// </summary>
		/// <param name="refPges">Rerefence to pages object that contasins this page</param>
		public Page(Reference refPges):base()
		{				
			base.Add (new Name("Type"),new Name ("Page"));			
			this.Parent = refPges;
		}
		
		/// <summary>
		/// Reference to the Pages object
		/// </summary>
		public Reference Parent 
		{
			get
			{
				if (this.Exists(_parent))
				{
					return (Reference)this[_parent];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_parent))
				{
					this.Remove (_parent);
				}
				this.Add (_parent,value);
			}
		}
		
		/// <summary>
		/// Refence to the content object
		/// </summary>
		public Reference Content
		{
			get
			{
				if (this.Exists(_contents))
				{
					return (Reference)this[_contents];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_contents))
				{
					this.Remove (_contents);
				}
				this.Add (_contents,value);
			}
		}
		
		/// <summary>
		/// PDFArray that defines page dimension
		/// </summary>
		public PDFArray MediaBox
		{
			get
			{
				if (this.Exists(_mediaBox))
				{
					return (PDFArray )this[_mediaBox];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_mediaBox))
				{
					this.Remove (_mediaBox);
				}
				this.Add (_mediaBox,value);
			}		
		}
		
		
		/// <summary>
		/// Resources dictionary for the page
		/// </summary>
		public Resources Resources
		{
			get
			{
				if (this.Exists(_resources))
				{
					return (Resources)this[_resources];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_resources))
				{
					this.Remove (_resources);
				}
				this.Add (_resources,value);
			}
		}
	}
}