// TextObject.cs
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
using System.Drawing;
using System.Text;
using PDFLib;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;



namespace PDFLib.Objects
{
	/// <summary>
	/// Represents a text object in PDF
	/// </summary>
	//[DebugHelper.Attributes.CallTrace()]
	public class TextObject : CommonGraphics
	{
		/// <summary>
		/// Text rendering modes enum
		/// </summary>
		public enum TextRenderingModes
		{	
			FillText=0,
			StrokeText=1,
			FillThenStrokeText=2,
			NoFillNoStroke=3,
			FillTextAddToClipPath=4,
			StokeTextAddToClipPath=5,
			FillStrokTextAddClipPath=6,
			AddTextToClipPath=7
		}
	
		
		/// <summary>
		/// Constructor
		/// </summary>
		public TextObject()
		{
				_writer.Append ("\n\nBT\n");
		}
		
		/// <summary>
		/// Write raw data into the text object
		/// </summary>
		/// <param name="data"></param>
		public void WriteRaw ( object data)
		{
			_writer.Append (data);
		}
		
				
		/// <summary>
		/// Sets the charecter spacing
		/// </summary>
		/// <param name="charSpacing">Space between the charecters</param>
		public void SetCharecterSpacing(float charSpacing )
		{
			_writer.Append (" ");
			_writer.Append (charSpacing);
			_writer.Append (" Tc ");
			return;
		}

		/// <summary>
		/// Sets the word spacing
		/// </summary>
		/// <param name="wordSpacing">Space between words</param>
		public void SetWordSpacing(float wordSpacing )
		{
			_writer.Append (" ");
			_writer.Append (wordSpacing);
			_writer.Append (" Tw ");
			return;
		}

		/// <summary>
		/// Set the horizental scale
		/// </summary>
		/// <param name="horizentalScalingPerc">Scale</param>
		public void SetHorizentalScaling(int horizentalScalingPerc )
		{
			_writer.Append (" ");
			_writer.Append (horizentalScalingPerc );
			_writer.Append (" Tz ");
			return;
		}

		/// <summary>
		/// Set charecter leading
		/// </summary>
		/// <param name="leading">points to lead</param>
		public void SetLeading (float leading)
		{
			_writer.Append (" ");
			_writer.Append (leading);
			_writer.Append (" TL ");
			return;
		}

		/// <summary>
		/// Set text rising. Use this to make subsxript or superscript
		/// </summary>
		/// <param name="rise">amount to rise</param>
		public void SetRise (double rise)
		{
			_writer.Append (" ");
			_writer.Append (rise);
			_writer.Append (" Ts	");
			return;
		}

		/// <summary>
		/// Move from current position
		/// </summary>
		/// <param name="fromCurrentX">x position to move</param>
		/// <param name="fromCurrentY">y position to move</param>
		public void MoveFromCurrent(double fromCurrentX,  double fromCurrentY)
		{
			_writer.Append (fromCurrentX);
			_writer.Append (" ");
			_writer.Append (fromCurrentY);
			_writer.Append (" TD ");			
		}

        public void Move(double x, double y)
        {
            _writer.Append(new Number(0));
            _writer.Append(new Number(0));
            _writer.Append("m ");
            MoveFromCurrent(x, y);
        }

		/// <summary>
		/// Change the font
		/// </summary>
		/// <param name="fnt">font object</param>
		/// <param name="point">fontsize</param>
		public void SetFont (PDFFont fnt, double point)
		{
			_writer.Append ("\n");
			_writer.Append (fnt.Name);
			_writer.Append (point);
			_writer.Append (" Tf\n");
			return;
		}

		/// <summary>
		/// Set the text rendering mode
		/// </summary>
		/// <param name="mode"></param>
		public void SetTextRenderingMode ( TextRenderingModes mode)
		{
			_writer.Append (" ");
			_writer.Append ((int)mode);
			_writer.Append (" Tr ");
			return ;
		}

		/// <summary>
		/// insert new line. has bug
		/// </summary>
		public void NewLine ()
		{
			_writer.Append ("\nT* ");
		}
		
		/// <summary>
		/// write text
		/// </summary>
		/// <param name="text"></param>
		public void Write (string text)
		{
			_writer.Append (new PDFString(text) );
			_writer.Append ("Tj\n");
			return;
		}

        public void WriteBinary(string text)
        {
            _writer.Append(text);
            _writer.Append("Tj\n");
            return;
        }

        /// <summary>
        /// Write a line then insert new line char. Buggy
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine (string text)
		{
			_writer.Append (new PDFString(text) );
			_writer.Append ("Tj\n");
			NewLine();
			return;
		}
		
		/// <summary>
		/// String representration of the text object
		/// </summary>
		/// <returns></returns>
		
		public override string ToString()
		{
			_writer.Append ("\nET\n");
			return _writer.ToString();
		}		
	}
}