using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace _04_FileConverter
{
    class Png2jpgConverter : IFileConverter
    {
        public string InputFileFormat
        {
            get
            {
                return "png";
            }
        }

        public string OutputFileFormat
        {
            get
            {
                return "jpg";
            }
        }

        public object Convert(object input)
        {
            
            var stream = new MemoryStream();

            (input as Image).Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);            
            return new Bitmap(stream);
        }
    }
}
