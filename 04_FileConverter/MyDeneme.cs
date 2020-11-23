using System;
using System.Collections.Generic;

namespace _04_FileConverter
{
    static class MyDeneme
    {
        static private Jpg2BmpConverter jpg2Bmp = new Jpg2BmpConverter();
        static private Png2jpgConverter png2Jpg = new Png2jpgConverter();
        static private Dictionary<string, IFileConverter> fileConverters = registeringFileConverters();
        static Graph graph = createGraph(); //Creating graph 
        
        static List<string> convertersNames =new List<string>{ "bmp", "jpg", "png" }; // 0 1 2

        public static object Convert(object input, string inputFileFormat, string outputFileFormat){

            int source= convertersNames.FindIndex(a => a.Contains(inputFileFormat)); // as 0 1 2
            int dest= convertersNames.FindIndex(a => a.Contains(outputFileFormat)); // as 0 1 2
            object output = null;
            List<int> path = graph.BFS(source, dest);

            if (source == -1 || dest == -1) {
                throw new Exception("inputFileFormat doesn't exist"
                    +"or outputFileFormat doesn't exist");
            }
            if (path.Count <= 1)
            {
                throw new FileConveterNotFoundException("FileConverter doesn't exist");
            }

            String myKey; // Converter's key 
 
            for (int i=0; i < path.Count-1; i++) // path.Count-1 is end of vertex does not go to other vertex
            {
                myKey = convertersNames[path[i]] + "2" + convertersNames[path[i + 1]];
                IFileConverter currentConverter = fileConverters[myKey];
                output=currentConverter.Convert(input);
                input = output; //refresh input                        
            }

            return output;
        }

        //  the method for registering file converters.
        public static Dictionary<string, IFileConverter> registeringFileConverters()
        {
            fileConverters = new Dictionary<string, IFileConverter>();
            fileConverters.Add("jpg2bmp", jpg2Bmp);
            fileConverters.Add("png2jpg", png2Jpg);

            return fileConverters;
        }

        // create a graph with adjancency
        public static Graph createGraph()
        {
            graph = new Graph(3);
            graph.AddEdge(1, 0);
            graph.AddEdge(2, 1);
            return graph;
        }
    }
}
