using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Assignment05_ProSE
{    
    public class MainClass
    {                       
        public static void Main(string[] argArray)
        {
            string pathImage1 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image1.jpg";
            string pathImage2 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image2.jpg";
            string newPathImage1 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image1Modified.jpg";
            string newPathImage2 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image2Modified.jpg";

            var images = new Bitmap[]
            {
                new Bitmap(pathImage1),
                new Bitmap(pathImage2),
            };
            // Start processing images
            Console.WriteLine("Processing the images starts!");//Thread Initializing

            
            //List of threads
            var imagesThreads = new List<Thread>();

            foreach ( var image in images)
            {
                //SoebelFilter image1 = new SoebelFilter();
                
                var imageContainer = new ImageContainer(image);
                //var imagesThread = new Thread(new ParameterizedThreadStart(image1.GetBoundary(image));
                var imagesThread = new Thread(new ThreadStart(imageContainer.ProcessImage));
                
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
