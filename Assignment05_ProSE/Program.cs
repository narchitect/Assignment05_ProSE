using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            string path = "file:///Users/kimnayun/Projects/Assignment05_ProSE/sampleImages/image1.jpg";
            Bitmap originalImage = new Bitmap(path);

            SoebelFilter image1 = new SoebelFilter();
            Bitmap newImage = image1.GetBoundary(originalImage);

            string newPath = "./Users/kimnayun/Projects/Assignment05_ProSE/sampleImages/image1-result.jpg";
            newImage.Save(newPath);
        }
    }
}