using System.Drawing;

namespace Assignment05_ProSE
{
    class Program
    {
        static void Main()
        {
            string path1 = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image1.jpg";
            Bitmap originalImage1 = new Bitmap(path1);
            string path2 = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image2.jpg";
            Bitmap originalImage2 = new Bitmap(path2);


            string resultPath = "C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image3-result(Threshold15).jpg";


            //Threading

            ParameterizedThreadStart del = new ParameterizedThreadStart(ImageContainer.ImageProcess);

            Thread t1 = new Thread(del);
            t1.Start(originalImage1);
            
            for()
        }
    }
}