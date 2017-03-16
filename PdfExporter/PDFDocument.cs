// PDFDocument.cs
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
using System.Collections;
using System.Text;
using System.IO;
using PDFLib.Objects;
using PDFLib;
using PDFLib.Objects.DataTypes;

namespace PDFLib.Objects
{
    /// <summary>
    /// The document object
    /// </summary>
    public class PDFDocument
    {
        protected StringBuilder stringBuilder = new StringBuilder();

        private ArrayList _indirectObjects = new ArrayList();
        private Trailer _trailer = new Trailer();
        private CrossRefTable _referenceTable = new CrossRefTable();

        private int _maxGen = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        public PDFDocument()
        {
        }

        private int _versionMajor = 1;
        /// <summary>
        /// Major version number
        /// </summary>
        public int VersionMajor
        {
            get { return _versionMajor; }
            set { _versionMajor = value; }
        }

        private int _versionMinor = 4;
        /// <summary>
        /// Minor version number
        /// </summary>
        public int VersionMinor
        {
            get { return _versionMinor; }
            set { _versionMinor = value; }
        }

        /// <summary>
        /// Returns the header of the stream
        /// </summary>			
        public virtual string Header
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("%PDF-");
                sb.Append(VersionMajor);
                sb.Append(".");
                sb.Append(VersionMinor);
                sb.Append("\n\n");
                return sb.ToString();
            }
        }

        /// <summary>
        /// The cross reference table
        /// </summary>
        public CrossRefTable ReferenceTable
        {
            get { return _referenceTable; }
        }

        /// <summary>
        /// Generates a unique new id for an indirect object
        /// </summary>
        /// <returns></returns>
        public int NextObjectID()
        {
            return _maxGen++;
        }


        /// <summary>
        /// Array of indirect objects
        /// </summary>
        public ArrayList IndirectObjects
        {
            get { return _indirectObjects; }
        }

        /// <summary>
        /// The trailer object
        /// </summary>
        public Trailer Trailer
        {
            get { return _trailer; }
        }


        /// <summary>
        /// String representation of the PDF document
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Header);

            IEnumerator enu = _indirectObjects.GetEnumerator();
            while (enu.MoveNext())
            {
                IndirectObject iobj = (IndirectObject)enu.Current;
                iobj.Offset = sb.Length;
                ReferenceTable.Add(new CrossRef(iobj.Offset, 0));
                sb.Append(iobj.ToString());
            }
            Trailer.CrossRefStartOffset = sb.Length;

            sb.Append(ReferenceTable);
            Trailer.Size = this._indirectObjects.Count + 1;
            sb.Append(Trailer.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Saves the docment into a file
        /// </summary>
        /// <param name="filename">filename to save to</param>
        /// <returns></returns>
        public bool Save(string filename)
        {
            Stream fileStream = File.Create(filename);
            //var mystring = Encoding.Unicode.GetString(this.ToString());

            var myarray2 = Encoding.ASCII.GetBytes(this.ToString());
            for (int i = 0; i < myarray2.Length; i++)
            {
                fileStream.WriteByte(myarray2[i]);
            }

            return true;
        }
    }
}
