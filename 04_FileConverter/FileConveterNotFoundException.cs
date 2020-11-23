using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    class FileConveterNotFoundException : Exception
    {
        public FileConveterNotFoundException(String message):base(message)
        {
            Console.WriteLine("File Converter Not Found Exception");
        }
    }
}
