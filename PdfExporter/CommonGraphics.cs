using System;
using System.Drawing;
using System.Text;
using PDFLib;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
	/// <summary>
	/// Summary description for CommonGraphics.
	/// </summary>
	public abstract class CommonGraphics
	{
		protected StringBuilder _writer= new StringBuilder();
		public CommonGraphics()
		{
		}
				
		public void SetRGBFillColor (Color color)
		{
			_writer.Append (new Number((float)color.R/255));
			_writer.Append (new Number((float)color.G/255));
			_writer.Append (new Number((float)color.B/255));
			_writer.Append ("rg\n");

			return;
		}

		public void SetRGBStrokeColor (Color color)
		{
            SetRGBStrokeColor((double)color.R / 255, (double)color.G / 255, (double)color.B / 255);
		}
        public void SetRGBStrokeColor(double r, double g, double b)
        {
            _writer.Append(new Number(r));
            _writer.Append(new Number(g));
            _writer.Append(new Number(b));
            _writer.Append("RG\n");
        }
		
		
	}
}
