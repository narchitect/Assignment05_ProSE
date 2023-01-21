using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            string path = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image3.jpg";
            Bitmap originalImage = new Bitmap(path);

            SoebelFilter image1 = new SoebelFilter();
            Bitmap newImage = image1.GetBoundary(originalImage);

            string newPath = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image3-result.jpg";
            newImage.Save(newPath);
        }
    }
}