using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFLib;
using PDFLib.Objects;
using PDFLib.Objects.DataTypes;
using System.Drawing;

namespace PdfExporter
{
    class Program
    {
        public struct PDFRectangle
        {
            public PDFRectangle(double left, double top, double right, double bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public double Height
            {
                get
                {
                    return Top - Bottom;
                }
            }
            public double Width
            {
                get
                {
                    return Right - Left;
                }
            }
            public double Left;
            public double Top;
            public double Right;
            public double Bottom;
        }

        public class PDFSize
        {
            public PDFSize(double w, double h)
            {
                Width = w;
                Height = h;
            }
            public double Width { get; set; }
            public double Height { get; set; }

        }
        public struct PDFPoint
        {
            public PDFPoint(double x, double y)
            {
                X = x;
                Y = y;
            }
            public double X { get; set; }
            public double Y { get; set; }
        }
        static void Main(string[] args)
        {
            PDFSize paper = new PDFSize(842, 595); //A4 paper size 210mm×297mm
            // Create a document object and initialize it
            PDFDocument doc = new PDFDocument();
            doc.VersionMinor = 4;

            // Create a catalog
            Catalog cat = new Catalog();
            // Create an indirect obejct pointing to the catalog
            // Look how we get the id number from the document
            IndirectObject ioCat = new IndirectObject(cat, doc.NextObjectID());
            doc.IndirectObjects.Add(ioCat);
            doc.Trailer.Root = new Reference(ioCat);
            // Create pages object
            Pages pages = new Pages();
            IndirectObject ioPages = new IndirectObject(pages, doc.NextObjectID());
            doc.IndirectObjects.Add(ioPages);
            Reference refPages = new Reference(ioPages);
            // Create a reference to the Pages object and add it to teh catalog object
            cat.Pages = refPages;
            Page page = new Page();
            // define the dimention of the pages
            page.MediaBox = new PDFArray() { new Number(0), new Number(0), new Number(paper.Width), new Number(paper.Height) };
            // Set the page objects parent
            page.Parent = refPages;
            // Create indirect object for pages
            IndirectObject ioPage = new IndirectObject(page, doc.NextObjectID());
            doc.IndirectObjects.Add(ioPage);
            pages.AddPageRef(new Reference(ioPage));
            // Create resources object for each pages
            page.Resources = new Resources();


            PDFFontDescriptor fontDescriptor = new PDFFontDescriptor();
            fontDescriptor.FontBBox = new PDFArray() { new Number(0), new Number(0), new Number(0), new Number(0) };
            IndirectObject _fontDescriptorID = new IndirectObject(fontDescriptor, doc.NextObjectID());
            doc.IndirectObjects.Add(_fontDescriptorID);
            Reference fontDescriptorRef = new Reference(_fontDescriptorID);

            PDFFont descendantFont = new PDFFont();
            IndirectObject descendantFontID = new IndirectObject(descendantFont, doc.NextObjectID());
            doc.IndirectObjects.Add(descendantFontID);
            descendantFont.SubType = new Name("CIDFontType2");
            descendantFont.BaseFont = new Name("SimSun");

            descendantFont.FontDescriptor = fontDescriptorRef;
            descendantFont.CIDSystemInfo = new PDFDictionary();
            descendantFont.CIDSystemInfo.Add(new Name("Registry"), "(Adobe)");
            descendantFont.CIDSystemInfo.Add(new Name("Ordering"), "(GB1)");

            // Create font andf initialize it
            PDFFont ascii = new PDFFont();
            ascii.Name = new Name("F2");
            ascii.Encoding = new Name("WinAnsiEncoding");
            ascii.BaseFont = new Name("Helvetica");
            ascii.SubType = new Name("TrueType");
            IndirectObject arialID = new IndirectObject(ascii, doc.NextObjectID());
            doc.IndirectObjects.Add(arialID);


            // Create font and initialize it
            PDFFont gb = new PDFFont();
            gb.SubType = new Name("Type0");
            gb.Name = new Name("F1");
            gb.BaseFont = new Name("SimSun");
            gb.Encoding = new Name("UniGB-UCS2-H");
            gb.FontDescriptor = fontDescriptorRef;
            gb.DescendantFonts = new PDFArray() { new Reference(descendantFontID) };
            IndirectObject fontID = new IndirectObject(gb, doc.NextObjectID());
            doc.IndirectObjects.Add(fontID);


            // add the font dictionary to the resources
            PDFDictionary dicFont = new PDFDictionary();
            dicFont.CarriageReturn = string.Empty;
            dicFont.Add(ascii.Name, new Reference(arialID));
            dicFont.Add(gb.Name, new Reference(fontID));
            page.Resources.Add(new Name("Font"), dicFont);
            // Create the procedure set			
            ProcSet procset = new ProcSet();
            procset.Add(new Name("PDF"));
            procset.Add(new Name("Text"));
            IndirectObject ioProcset = new IndirectObject(procset, doc.NextObjectID());
            doc.IndirectObjects.Add(ioProcset);
            // add the proc set to the resources
            page.Resources.Add(new Name("ProcSet"), new Reference(ioProcset));

            PDFStream content = new PDFStream();
            IndirectObject ioStream = new IndirectObject(content, doc.NextObjectID());
            doc.IndirectObjects.Add(ioStream);
            page.Content = new Reference(ioStream);
            Info info = new Info();
            IndirectObject ioInfo = new IndirectObject(info, doc.NextObjectID());
            doc.IndirectObjects.Add(ioInfo);
            doc.Trailer.Info = new Reference(ioInfo);

            //draw
            double unit = 2.834;
            PDFGraphics g = new PDFGraphics();
            g.state(1, 0, 0, 1, 0, 0);
            g.SetLineWidth(1f);
            g.SetRGBFillColor(Color.SteelBlue);
            g.SetRGBStrokeColor(Color.Black);
            g.DrawRectangle(20 * unit, paper.Height - 20 * unit, 10 * unit, 10 * unit);
            g.FillAndStrokePath();
            content.Write(g);

            //Set font and write
            // create the text object to write to
            TextObject text = new TextObject();
            text.SetFont(gb, 8);
            text.SetRGBFillColor(Color.Blue);
            text.SetRGBStrokeColor(Color.Blue);
            text.Move(10 * unit, paper.Height - 5 * unit);
            text.SetRGBFillColor(Color.Black);
            text.SetRGBStrokeColor(Color.Black);
            text.SetFont(gb, 9);
            Func<string, string> str2code = (string s) =>
            {
                StringBuilder o = new StringBuilder("<");
                foreach (var c in s)
                {
                    o.Append(Convert.ToString(c, 16).ToUpper().PadLeft(4, '0'));

                }
                o.Append('>');
                return o.ToString();
            };
            text.WriteBinary(str2code("绘制一个大小边长1厘米的正方形"));
            content.Write(text);

            doc.Save("demo.pdf");
        }
    }
}
