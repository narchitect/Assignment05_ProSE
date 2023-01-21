using System;
using System.Drawing;

namespace Assignment05_ProSE
{
    public class SoebelFilter
    {

        private int[][] sobelx = {new int[] {-1, 0, 1},
                          new int[] {-2, 0, 2},
                          new int[] {-1, 0, 1}};

        private int[][] sobely = {new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};


        public Bitmap GetBoundary(Bitmap originalImg)
        {
            Bitmap res = new Bitmap(originalImg.Width, originalImg.Height);

            for (int i = 1; i < originalImg.Width - 1; i++)
            {
                for (int j = 1; j < originalImg.Height - 1; j++)
                {
                    int dx = originalImg.GetPixel(i - 1, j - 1).R * sobelx[0][0] + originalImg.GetPixel(i, j - 1).R * sobelx[0][1] + originalImg.GetPixel(i + 1, j - 1).R * sobelx[0][2]
                              + originalImg.GetPixel(i - 1, j).R * sobelx[1][0] + originalImg.GetPixel(i, j).R * sobelx[1][1] + originalImg.GetPixel(i + 1, j).R * sobelx[1][2]
                              + originalImg.GetPixel(i - 1, j + 1).R * sobelx[2][0] + originalImg.GetPixel(i, j + 1).R * sobelx[2][1] + originalImg.GetPixel(i + 1, j + 1).R * sobelx[2][2];

                    int dy = originalImg.GetPixel(i - 1, j - 1).R * sobely[0][0] + originalImg.GetPixel(i, j - 1).R * sobely[0][1] + originalImg.GetPixel(i + 1, j - 1).R * sobely[0][2]
                           + originalImg.GetPixel(i - 1, j).R * sobely[1][0] + originalImg.GetPixel(i, j).R * sobely[1][1] + originalImg.GetPixel(i + 1, j).R * sobely[1][2]
                           + originalImg.GetPixel(i - 1, j + 1).R * sobely[2][0] + originalImg.GetPixel(i, j + 1).R * sobely[2][1] + originalImg.GetPixel(i + 1, j + 1).R * sobely[2][2];
                    double derivata = Math.Sqrt((dx * dx) + (dy * dy));

                    if (derivata > 255)
                    {
                        res.SetPixel(i, j, originalImg.GetPixel(i,j));
                    }
                    else
                    {
                        res.SetPixel(i, j, Color.FromArgb(255, (int)derivata, (int)derivata, (int)derivata));
                    }
                }
            }
            return res;
        }

    }
}

