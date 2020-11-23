using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FileConverter
{
    static class FileConversionManager
    {
         
        static private Jpg2BmpConverter jpg2Bmp = new Jpg2BmpConverter();
        static private Png2jpgConverter png2Jpg = new Png2jpgConverter();
        static private List<IFileConverter> fileConverters = new List<IFileConverter>() { null, jpg2Bmp, png2Jpg };

        static byte[,] arr = { { 0, 0, 0 },     //bmp,jpg,png 
                               { 1, 0, 0 },     //jpg
                               { 0, 1, 0 } };   //png 


        static List<string> convertersNames =new List<string>{ "bmp", "jpg", "png" };

        static GraphFileConverter graphFileConvert = new GraphFileConverter(arr);

        public static object Convert(object input, string inputFileFormat, string outputFileFormat){
           
            int source= convertersNames.FindIndex(a => a.Contains(inputFileFormat));
            int dest= convertersNames.FindIndex(a => a.Contains(outputFileFormat));

            if (source == -1) {
                throw new Exception("inputFileFormat doesmn't exist");
            }

            if (dest == -1) {
                throw new Exception("outputFileFormat doesmn't exist");
            }

            LinkedList<int> pathReverse= graphFileConvert.getShortestPath(source, dest);

            if (pathReverse.Count == 0) {
                throw new FileConveterNotFoundException("FileConverter doesn't exist");
            }

            object output = null;

            if (pathReverse.Count == 2) {
                output = fileConverters[pathReverse.ElementAt(1)].Convert(input);
                return output;
            }

            for (int i = pathReverse.Count - 1; i > 0; i--)
            {
                output = fileConverters[pathReverse.ElementAt(i)].Convert(input);
                input = output;
            }

            return output;
        }

    }
}
