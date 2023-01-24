using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            //helper parts
            List<string> paths = new List<string>();
            List<Bitmap> originalImgs = new List<Bitmap>();
            List<ImageContainer> imageContainers = new List<ImageContainer>();

            List<Thread> imageThreads = new List<Thread>();

            for (int i = 0; i < 5; i++)
            {
                paths.Add(string.Format("C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image{0}.jpg", i + 1));
                Bitmap origianlImg = new Bitmap(paths[i]);
                origianlImg.Tag = string.Format("image{0}",i+1);
                originalImgs.Add(origianlImg);
            }

            foreach(Bitmap originalImg in originalImgs)
            {
                imageContainers.Add(new ImageContainer(originalImg));
            }

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

            //Helper part2
            for (int i = 0; i < 5; i++)
            {
                string resultPath = string.Format("C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image{0}_resultT2.jpg", i + 1);
                imageContainers[i].Result.Save(resultPath);
            }
        }
    }
}