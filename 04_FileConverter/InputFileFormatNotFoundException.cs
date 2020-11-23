using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    class InputFileFormatNotFoundException : Exception
    {
        public InputFileFormatNotFoundException(String message):base(message)
        {
            Console.WriteLine("Input File Format Not Found Exception");
        }
    }
}
