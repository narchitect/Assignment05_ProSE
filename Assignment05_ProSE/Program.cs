using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            string path = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image2.jpg";
            Bitmap originalImage = new Bitmap(path);

            SoebelFilter image1 = new SoebelFilter();
            Bitmap newImage = image1.GetBoundary(originalImage);

            string newPath = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image2-result(without GB).jpg";
            newImage.Save(newPath);
        }
    }
}