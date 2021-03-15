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
    class ExportPDF
    {
        public  string MachineID = "";
        public  string ChipID = "";
        public  string Data = "";
        public  string T1 = "";
        public  string T2 = "";
        public  string AG = "";
        public  string DG = "";
        public  string A0 = "";
        public  string A1 = "";
        public  string A2 = "";
        public  string A3 = "";
        public  string ROI_X = "";
        public  string ROI_W = "";
        public  string ROI_Y = "";
        public  string ROI_H = "";
        public  string OP = "";

        public  bool BT_Result = false;//藍芽測試 
        public  bool MT_Result = false;//馬達測試 
        public  bool LED_Result = false;//LED 測試
        public  bool SP_Result = false; // 光譜測試 

        public static string Note = "";
        public static string Path = "";


        public  void DoExport(string Path) {
            Document document = new Document();
            iTextSharp.text.Font title_font = new iTextSharp.text.Font(BaseFont.CreateFont(), 23);
            //    Chunk chunk1 = new Chunk("This text is underlined",FontFactory.GetFont(FontFactory.TIMES_ROMAN, "12", Font.Underline));
            Chunk chunk1 = new Chunk("Spectrochips", FontFactory.GetFont(FontFactory.TIMES_ROMAN, "32"));

            PdfWriter.GetInstance(document, new FileStream(ChipID + ".pdf", FileMode.Create));

            PdfPTable aTable = new PdfPTable(2);
            PdfPTable bTable = new PdfPTable(4);
            PdfPTable cTable = new PdfPTable(2);
            PdfPTable dTable = new PdfPTable(2);
            PdfPTable eTable = new PdfPTable(1);
            //-A-TABLE定義------------
            aTable.AddCell("Machine ID");
            aTable.AddCell(MachineID);
            aTable.AddCell("Chip ID ");
            aTable.AddCell(ChipID);
            aTable.AddCell("Date");
            aTable.AddCell(Data);
            //-B-TABLE定義------------
            bTable.AddCell("T1/T2 ");
            bTable.AddCell(T1+" / "+T2);
            bTable.AddCell("AG/DG ");
            bTable.AddCell(AG + " / " + DG);
            //-C-TABLE定義------------
            cTable.AddCell("A0 A1 A2 A3 ");
            cTable.AddCell(A0+","+ A1 + "," + A2 + "," + A3);
            cTable.AddCell("ROI ");
            cTable.AddCell("["+ROI_X+","+ ROI_W + "," + ROI_Y + "," + ROI_H +  "]");
            cTable.AddCell("Operator");
            cTable.AddCell(OP);

            //-D-TABLE定義------------
            dTable.AddCell("Test Items ");
            dTable.AddCell("Test Result");
            dTable.AddCell("Blue Tooth Test ");
            dTable.AddCell(BT_Result?"Pass":"NG");
            dTable.AddCell("Motor Test ");
            dTable.AddCell(MT_Result ? "Pass" : "NG");
            dTable.AddCell("LED Test");
            dTable.AddCell(LED_Result ? "Pass" : "NG");
            dTable.AddCell("Spectral Test");
            dTable.AddCell(SP_Result ? "Pass" : "NG");

            //-E-TABLE定義------------
            eTable.AddCell("Note: "+ Note);



            //--寫入檔案---------------------
            document.Open();
            document.Add(new iTextSharp.text.Paragraph("Spectrochips", title_font));
            document.Add(new iTextSharp.text.Paragraph("\n\n"));
            document.Add(aTable);
            document.Add(bTable);
            document.Add(cTable);
            document.Add(new iTextSharp.text.Paragraph("\n\n"));
            document.Add(dTable);
            document.Add(eTable);
            document.Close();

        }
    }
}
