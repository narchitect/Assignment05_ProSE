using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            //Import original images
            List<ImageContainer> imageContainers = Helper.ImportImages();

            //Multi Threading
            List<Thread> imageThreads = new List<Thread>();

            foreach(ImageContainer imageContainer in imageContainers)
            {
                var imageThread = new Thread(new ThreadStart(imageContainer.GetFillteredImage));
                imageThreads.Add(imageThread);
                imageThread.Start();
            }

            foreach(Thread thread in imageThreads)
            {
                thread.Join(); 
            }

            //Export images
            Helper.ExportImages(imageContainers);
        }
    }
}