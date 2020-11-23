using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    class OutputFileFormatNotFoundException : Exception
    {
        public OutputFileFormatNotFoundException(String message):base(message)
        {
            Console.WriteLine("Output File Format Not Found Exception");
        }
    }
}
