using System;
using System.Drawing;

namespace Assignment05_ProSE
{
    public class SoebelFilter
    {
        static Bitmap Result;
        static Color OriginalImgColor;
        
        double Threshold = 30;

        public Bitmap GetBoundary(Bitmap originalImg)
        {
            Result = new Bitmap(originalImg.Width, originalImg.Height);
            
            //Red Channel
            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    
                    int gradiantX_R = (Convert.ToInt32(originalImg.GetPixel(x - 1, y).R - originalImg.GetPixel(x + 1, y).R))/2;
                    int gradiantY_R = (Convert.ToInt32(originalImg.GetPixel(x, y - 1).R - originalImg.GetPixel(x, y + 1).R))/2;
                    
                    double Magnitude_R = Math.Sqrt((gradiantX_R * gradiantX_R) + (gradiantY_R * gradiantY_R));
                    
                    OriginalImgColor = originalImg.GetPixel(x, y);
                    CheckPixelsMagnitude(Magnitude_R, x, y);
                }
            }

            //Green Channel
            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    int gradiantX_G = (Convert.ToInt32(originalImg.GetPixel(x - 1, y).G - originalImg.GetPixel(x + 1, y).G))/2;
                    int gradiantY_G = (Convert.ToInt32(originalImg.GetPixel(x, y - 1).G - originalImg.GetPixel(x, y + 1).G))/2;

                    double Magnitude_G = Math.Sqrt((gradiantX_G * gradiantX_G) + (gradiantY_G * gradiantY_G));
                    
                    OriginalImgColor = originalImg.GetPixel(x, y);
                    CheckPixelsMagnitude(Magnitude_G, x, y);
                }
            }

            //Blue Channel
            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    int gradiantX_B = (Convert.ToInt32(originalImg.GetPixel(x - 1, y).B - originalImg.GetPixel(x + 1, y).B)) / 2;
                    int gradiantY_B = (Convert.ToInt32(originalImg.GetPixel(x, y - 1).G - originalImg.GetPixel(x, y + 1).B)) / 2;

                    double Magnitude_B = Math.Sqrt((gradiantX_B * gradiantX_B) + (gradiantY_B * gradiantY_B));

                    OriginalImgColor = originalImg.GetPixel(x, y);
                    CheckPixelsMagnitude(Magnitude_B, x, y);
                }
            }
            return Result;
        }

        private void CheckPixelsMagnitude(double magnitude, int x, int y )
        {
            if (Result.GetPixel(x, y) != Color.Black)
            {
                if (magnitude > Threshold)
                {
                    Result.SetPixel(x, y, OriginalImgColor);
                }
                else
                {
                    Result.SetPixel(x, y, Color.Black);
                }
            }
        }
    }
}

