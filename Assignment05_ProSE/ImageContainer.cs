using System;
using System.Drawing;

namespace Assignment05_ProSE
{
    public class ImageContainer
    {
        public Bitmap OriginalImage { get; set; } 
        public Bitmap Result { get; set; }
        public double Threshold = 15;
        
        public ImageContainer(Bitmap originalImg) 
        { 
            this.OriginalImage = originalImg;
        } 

        public void GetFillteredImage()
        {
            Result = new Bitmap(OriginalImage.Width, OriginalImage.Height);
            
            //Red Channel
            FilterRedChannel();
            //Green Channel
            FilterGreenChannel();
            //Blue Channel
            FilterBlueChannel();
        }

        private void FilterRedChannel()
        {
            Console.WriteLine("Filltering Red channel... [Current image: {0}]", OriginalImage.Tag);
            for (int x = 1; x < OriginalImage.Width - 1; x++)
            {
                for (int y = 1; y < OriginalImage.Height - 1; y++)
                {
                    int gradiantX = (Convert.ToInt32(OriginalImage.GetPixel(x - 1, y).R - OriginalImage.GetPixel(x + 1, y).R)) / 2;
                    int gradiantY = (Convert.ToInt32(OriginalImage.GetPixel(x, y - 1).R - OriginalImage.GetPixel(x, y + 1).R)) / 2;

                    double magnitude = Math.Sqrt((gradiantX * gradiantX) + (gradiantY * gradiantY));

                    Color originalImgColor = OriginalImage.GetPixel(x, y);
                    CheckPixelsMagnitude(magnitude, x, y, originalImgColor);

                }
            }
        }
        private void FilterGreenChannel()
        {
            Console.WriteLine("Filltering Green channel... [Current image: {0}]", OriginalImage.Tag);
            for (int x = 1; x < OriginalImage.Width - 1; x++)
            {
                for (int y = 1; y < OriginalImage.Height - 1; y++)
                {
                    int gradiantX = (Convert.ToInt32(OriginalImage.GetPixel(x - 1, y).G - OriginalImage.GetPixel(x + 1, y).G)) / 2;
                    int gradiantY = (Convert.ToInt32(OriginalImage.GetPixel(x, y - 1).G - OriginalImage.GetPixel(x, y + 1).G)) / 2;

                    double magnitude = Math.Sqrt((gradiantX * gradiantX) + (gradiantY * gradiantY));

                    Color originalImgColor = OriginalImage.GetPixel(x, y);
                    CheckPixelsMagnitude(magnitude, x, y, originalImgColor);
                }
            }
        }
        private void FilterBlueChannel()
        {
            Console.WriteLine("Filltering Blue channel... [Current image: {0}]", OriginalImage.Tag);
            for (int x = 1; x < OriginalImage.Width - 1; x++)
            {
                for (int y = 1; y < OriginalImage.Height - 1; y++)
                {
                    int gradiantX = (Convert.ToInt32(OriginalImage.GetPixel(x - 1, y).B - OriginalImage.GetPixel(x + 1, y).B)) / 2;
                    int gradiantY = (Convert.ToInt32(OriginalImage.GetPixel(x, y - 1).B - OriginalImage.GetPixel(x, y + 1).B)) / 2;

                    double magnitude = Math.Sqrt((gradiantX * gradiantX) + (gradiantY * gradiantY));

                    Color originalImgColor = OriginalImage.GetPixel(x, y);
                    CheckPixelsMagnitude(magnitude, x, y, originalImgColor);
                }
            }
            
        }
        private void CheckPixelsMagnitude(double magnitude, int x, int y, Color originalImgColor)
        {
            Monitor.Enter(Result);
            if (Result.GetPixel(x, y) != Color.Black)
            {
                if (magnitude > Threshold)
                {
                    Result.SetPixel(x, y, originalImgColor);
                }
                else
                {
                    Result.SetPixel(x, y, Color.Black);
                }
            }
            Monitor.Exit(Result); 
        }
    }
}

