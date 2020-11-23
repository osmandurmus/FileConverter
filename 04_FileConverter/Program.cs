using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;

namespace _04_FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // get project directory
            var startDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Create an input image
            Image image = Image.FromFile(startDirectory+"\\04_FileConverter\\Images\\eagle.png");

            /* try
             {
                 Image newImage = FileConversionManager.Convert(image, "png", "bmp") as Image;
                 Console.WriteLine("\nFile Converted");


                 if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                 {
                     Console.WriteLine("Gelen resim png.");

                 }


                 if (newImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                 {
                     Console.WriteLine("Bmp ye çevrildi.");

                 }

             }
             catch (FileConveterNotFoundException e) {

                 Console.WriteLine(e.Message);
             }
             catch (InputFileFormatNotFoundException e)
             {
                 Console.WriteLine(e.Message);
             }
             catch (OutputFileFormatNotFoundException e)
             {
                 Console.WriteLine(e.Message);
             }*/

            try
            {
                Image newImage = MyDeneme.Convert(image, "bmp", "bmp") as Image;
                Console.WriteLine("\nFile Converted");


                if (image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                {
                    Console.WriteLine("Gelen resim png.");

                }


                if (newImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                {
                    Console.WriteLine("Bmp ye çevrildi.");

                }

            }
            catch (FileConveterNotFoundException e)
            {

                Console.WriteLine(e.Message);
            }
            catch (InputFileFormatNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutputFileFormatNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }


        }       
    }
}
