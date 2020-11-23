using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    class Jpg2BmpConverter : IFileConverter
    {
        public string InputFileFormat
        {
            get
            {
                return "jpg";
            }
        }

        public string OutputFileFormat
        {
            get
            {
                return "bmp";
            }
        }

        public object Convert(object input)
        {
            var stream = new MemoryStream();

            (input as Image).Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

            return new Bitmap(stream);
        }
    }
}
