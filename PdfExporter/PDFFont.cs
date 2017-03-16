// PDFFont.cs
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
using PDFLib;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;


namespace PDFLib.Objects
{
	/// <summary>
	/// Font object in PDF
	/// </summary>
	public class PDFFont : PDFDictionary
    {
        public Name _cidToGIDMap = new Name("CIDToGIDMap");
        public Name CIDToGIDMap
        {
            get
            {
                if (this.Exists(_cidToGIDMap))
                {
                    return (Name)this[_cidToGIDMap];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Exists(_cidToGIDMap))
                {
                    this.Remove(_cidToGIDMap);
                }
                this.Add(_cidToGIDMap, value);
            }
        }

        public Name _fontDescriptor = new Name("FontDescriptor");
        public Reference FontDescriptor
        {
            get
            {
                if (this.Exists(_fontDescriptor))
                {
                    return (Reference)this[_fontDescriptor];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Exists(_fontDescriptor))
                {
                    this.Remove(_fontDescriptor);
                }
                this.Add(_fontDescriptor, value);
            }
        }

        public Name _cidSystemInfo = new Name("CIDSystemInfo");
        public PDFDictionary CIDSystemInfo
        {
            get
            {
                if (this.Exists(_cidSystemInfo))
                {
                    return (PDFDictionary)this[_cidSystemInfo];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Exists(_cidSystemInfo))
                {
                    this.Remove(_cidSystemInfo);
                }
                this.Add(_cidSystemInfo, value);
            }
        }
        
        public Name _descendantFonts = new Name("DescendantFonts");
		/*
		/Type /Font 
		/Subtype /Type1 
		/Name /F1 
		/BaseFont /Helvetica 
		/Encoding /MacRomanEncoding  
		*/													
		private Name _subtype = new Name ("Subtype");
		private Name _name = new Name ("Name");
		private Name _baseFont = new Name ("BaseFont");
		private Name _encoding = new Name ("Encoding");
		
		/// <summary>
		/// Create the font object 
		/// </summary>
		public PDFFont() : base()		
		{
			base.Add ( new Name("Type"), new Name ("Font"));			
		}
		
		/// <summary>
		/// Name of the font obejct
		/// </summary>
		public Name Name
		{
			get
			{
				if (this.Exists(_name))
				{
					return (Name)this[_name];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_name))
				{
					this.Remove (_name);
				}
				this.Add (_name,value);
			}
		}

		/// <summary>
		/// Base font 
		/// </summary>
		public Name BaseFont
		{
			get
			{
				if (this.Exists(_baseFont))
				{
					return (Name)this[_baseFont];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_baseFont))
				{
					this.Remove (_baseFont);
				}
				this.Add (_baseFont,value);
			}
		}

		/// <summary>
		/// Type of encoding to use
		/// </summary>
		public Name Encoding
		{
			get
			{
				if (this.Exists(_encoding))
				{
					return (Name)this[_encoding];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_encoding))
				{
					this.Remove (_encoding);
				}
				this.Add (_encoding,value);
			}
		}

		/// <summary>
		/// Font type
		/// </summary>
		public Name SubType
		{
			get
			{
				if (this.Exists(_subtype))
				{
					return (Name)this[_subtype];
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (this.Exists(_subtype))
				{
					this.Remove (_subtype);
				}
				this.Add (_subtype,value);
			}
		}
        public PDFArray DescendantFonts
        {
            get
            {
                if (this.Exists(_descendantFonts))
                {
                    return (PDFArray)this[_descendantFonts];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Exists(_descendantFonts))
                {
                    this.Remove(_descendantFonts);
                }
                this.Add(_descendantFonts, value);
            }
        }
    }
}
