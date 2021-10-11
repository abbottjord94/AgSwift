using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;

namespace AgSwift_PdfImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) print_usage();
            else
            {
                int dpi = 96;
                using (GhostscriptRasterizer rasterizer = new GhostscriptRasterizer())
                {
                    try
                    {
                        byte[] inputFileBuffer = File.ReadAllBytes(Path.GetFullPath(args[0]));
                        MemoryStream ms = new MemoryStream(inputFileBuffer);

                        rasterizer.Open(ms);

                        string outpath = "Page-" + args[1] + ".tiff";
                        int pageNumber = Convert.ToInt32(args[1]);

                        Image img = rasterizer.GetPage(dpi, pageNumber);
                        img.Save(Path.GetFullPath(outpath), ImageFormat.Tiff);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        print_usage();
                    }
                }
            }
        }

        static void print_usage()
        {
            Console.WriteLine("usage: agswift-pdfimport <path to pdf file> <page number>");
        }
    }
}
