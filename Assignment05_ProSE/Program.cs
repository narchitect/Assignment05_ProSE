using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Assignment05_ProSE
{
    
    public class MainClass
    {

        public void ProcessImage()
        {
            while (true)
            {
                Monitor.Enter(this);
                SimplifiedSobel();
                Monitor.Exit(this);
            }            
        }

        public static void SimplifiedSobel(Bitmap image)
        {

        }
        public static void Main(string[] argArray)
        {

            // Start processing images
            Console.WriteLine("Processing the images starts!");//Thread Initializing

            
            //List of threads
            var imagesThreads = new List<Thread>();
            foreach (var image in images)
            {
                var imagesThread = new Thread(new ParameterizedThreadStart(image.ProcessImage));
                imagesThreads.Add(imagesThread);
                imagesThread.Start();
            }
            foreach (var thread in imagesThreads)
            {
                thread.Join();
            }
            // Done
            Console.WriteLine("Processing the images is over!");

           

        }
    }
}
