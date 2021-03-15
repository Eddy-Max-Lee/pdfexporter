using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Documents;

namespace pdfexport
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Document document = new Document();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            iTextSharp.text.Font title_font = new iTextSharp.text.Font(BaseFont.CreateFont(),23);
        //    Chunk chunk1 = new Chunk("This text is underlined",FontFactory.GetFont(FontFactory.TIMES_ROMAN, "12", Font.Underline));
            Chunk chunk1 = new Chunk("Spectrochips", FontFactory.GetFont(FontFactory.TIMES_ROMAN, "32"));

            PdfWriter.GetInstance(document, new FileStream("Chap0101.pdf",   FileMode.Create));

            PdfPTable aTable = new PdfPTable(2);
            PdfPTable bTable = new PdfPTable(4);
            PdfPTable cTable = new PdfPTable(2);
            //-A-TABLE------------
            aTable.AddCell("機台");
            aTable.AddCell("V6-1001 ");
            aTable.AddCell("晶片 ");
            aTable.AddCell("20B4-116-XX  ");
            aTable.AddCell("日期  ");
            aTable.AddCell("2021.03.10  ");
            //-B-TABLE------------
            bTable.AddCell("T1/T2 ");
            bTable.AddCell("12/12 ");
            bTable.AddCell("AG/DG ");
            bTable.AddCell("88/88 ");
            //-C-TABLE------------
            cTable.AddCell("A0 A1 A2 A3 ");
            cTable.AddCell("1.25, 454,64 ");
            cTable.AddCell("ROI ");
            cTable.AddCell("[20,20,20,20]");
            cTable.AddCell("操作者 ");
            cTable.AddCell("邱宏swag  ");


            document.Open();
            document.Add(new iTextSharp.text.Paragraph("Spectrochips", title_font));
            document.Add(new iTextSharp.text.Paragraph(chunk1));
            document.Add(aTable);
            document.Add(bTable);
            document.Add(cTable);
            document.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportPDF pdf = new ExportPDF();
            
            pdf.MachineID = "V6-1001";
            pdf.ChipID = "20B4-116-XX";
            pdf.Data = "2021.03.10";
            pdf.T1 = "12";

            pdf.A2 = "5";

            pdf.SP_Result = true;

            pdf.DoExport("path");




        }
    }
}
