using System;
using System.Drawing;
using System.Text;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
	/// <summary>
	/// Summary description for PDFGraphics.
	/// </summary>
	public class PDFGraphics: CommonGraphics
	{
		//private StringBuilder _writer = new StringBuilder();
		public PDFGraphics()
		{
		}
        public void state(double a, double b, double c, double d, double e, double f)
        {
            _writer.Append(new Number(a));
            _writer.Append(new Number(b));
            _writer.Append(new Number(c));
            _writer.Append(new Number(d));
            _writer.Append(new Number(e));
            _writer.Append(new Number(f));
            _writer.Append(" cm\n");
        }
		
		public void MoveTo ( double x, double y)
		{
			_writer.Append (new Number(x));
			_writer.Append (new Number(y));
			_writer.Append (" m\n");
		}
		
		public void LineTo ( double x, double y)
		{
			_writer.Append (new Number(x));
			_writer.Append (new Number(y));
			_writer.Append (" l\n");
		}
		
		public void StrokePath ()
		{
			_writer.Append (" S\n");
		}

		public void FillAndStrokePath ()
		{
			_writer.Append (" B\n");
		}

		
		public void SetLineWidth (int width)
		{
			_writer.Append ( new Number(width));
			_writer.Append ( " w\n");
		}

        public void SetLineWidth(float width)
        {
            _writer.Append(new Number(width));
            _writer.Append(" w\n");
        }

        public void SetDashPattern (PDFArray dashPattern, int dotPattern )
		{
			_writer.Append ( dashPattern);
			_writer.Append ( new Number (dotPattern));
			_writer.Append ( " d\n");
		}


		public void DrawRectangle ( Rectangle rect)
		{
			_writer.Append (new Number (rect.X));
			_writer.Append (new Number (rect.Y));
			_writer.Append (new Number (rect.Width));
			_writer.Append (new Number (rect.Height));
			_writer.Append (" re\n");
		}
        public void DrawRectangle(double x, double y, double w, double h)
        {
            _writer.Append(new Number(x));
            _writer.Append(new Number(y));
            _writer.Append(new Number(w));
            _writer.Append(new Number(h));
            _writer.Append(" re\n");
        }
		
			
		public override string ToString ()
		{
			return _writer.ToString ();
		}		
	}
}
