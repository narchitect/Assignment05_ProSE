using System;
using System.Drawing;

namespace Assignment05_ProSE
{
    public class SoebelFilter
    {
        double Sum;
        double Threshold = 30;
        private int[][] SoebelX = {
                          new int[] {-1, 0, 1},
                          new int[] {-2, 0, 2},
                          new int[] {-1, 0, 1}};

        private int[][] SoebelY = {
                          new int[] {-1, -2, -1},
                          new int[] { 0, 0, 0},
                          new int[] { 1, 2, 1}};

        public Bitmap GetBoundary(Bitmap originalImg)
        {
            Bitmap res = new Bitmap(originalImg.Width, originalImg.Height);
           
            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    int gradiantX_R = (originalImg.GetPixel(x - 1, y).R - originalImg.GetPixel(x + 1, y).R)/2;
                    //int gradiantX_G = (originalImg.GetPixel(x - 1, y).G - originalImg.GetPixel(x + 1, y).G)/2;
                    //int gradiantX_B = (originalImg.GetPixel(x - 1, y).B - originalImg.GetPixel(x + 1, y).B)/2;

                    int gradiantY_R = (originalImg.GetPixel(x, y - 1).R - originalImg.GetPixel(x, y + 1).R) / 2;
                    //int gradiantY_G = (originalImg.GetPixel(x, y - 1).G - originalImg.GetPixel(x, y + 1).G) / 2;
                    //int gradiantY_B = (originalImg.GetPixel(x, y - 1).B - originalImg.GetPixel(x, y + 1).B) / 2;


                    //int gradiantX = originalImg.GetPixel(x - 1, y - 1).R * SoebelX[0][0]
                    //              + originalImg.GetPixel(x, y - 1).R * SoebelX[0][1]
                    //              + originalImg.GetPixel(x + 1, y - 1).R * SoebelX[0][2]
                    //              + originalImg.GetPixel(x - 1, y).R * SoebelX[1][0]
                    //              + originalImg.GetPixel(x, y).R * SoebelX[1][1]
                    //              + originalImg.GetPixel(x + 1, y).R * SoebelX[1][2]
                    //              + originalImg.GetPixel(x - 1, y + 1).R * SoebelX[2][0]
                    //              + originalImg.GetPixel(x, y + 1).R * SoebelX[2][1]
                    //              + originalImg.GetPixel(x + 1, y + 1).R * SoebelX[2][2];

                    //int gradiantY = originalImg.GetPixel(x - 1, y - 1).R * SoebelY[0][0]
                    //              + originalImg.GetPixel(x, y - 1).R * SoebelY[0][1]
                    //              + originalImg.GetPixel(x + 1, y - 1).R * SoebelY[0][2]
                    //              + originalImg.GetPixel(x - 1, y).R * SoebelY[1][0]
                    //              + originalImg.GetPixel(x, y).R * SoebelY[1][1]
                    //              + originalImg.GetPixel(x + 1, y).R * SoebelY[1][2]
                    //              + originalImg.GetPixel(x - 1, y + 1).R * SoebelY[2][0]
                    //              + originalImg.GetPixel(x, y + 1).R * SoebelY[2][1]
                    //              + originalImg.GetPixel(x + 1, y + 1).R * SoebelY[2][2];

                    double Magnitude_R = Math.Sqrt((gradiantX_R * gradiantX_R) + (gradiantY_R * gradiantY_R));
                    //double Magnitude_G = Math.Sqrt((gradiantX_G * gradiantX_G) + (gradiantY_G * gradiantY_G));
                    //double Magnitude_B = Math.Sqrt((gradiantX_B * gradiantX_B) + (gradiantY_B * gradiantY_B));
                    Sum += Magnitude_R;

                    if(res.GetPixel(x,y) != Color.Black)
                    {
                        if (Magnitude_R > Threshold)
                        {
                            res.SetPixel(x, y, originalImg.GetPixel(x, y));
                        }
                        else
                        {
                            res.SetPixel(x, y, Color.Black);
                        }
                    }
                }
               
            }

            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    int gradiantX_G = (originalImg.GetPixel(x - 1, y).G - originalImg.GetPixel(x + 1, y).G)/2;

                    int gradiantY_G = (originalImg.GetPixel(x, y - 1).G - originalImg.GetPixel(x, y + 1).G)/2;

                    double Magnitude_G = Math.Sqrt((gradiantX_G * gradiantX_G) + (gradiantY_G * gradiantY_G));
                    
                    Sum += Magnitude_G;

                    if (res.GetPixel(x, y) != Color.Black)
                    {
                        if (Magnitude_G > Threshold)
                        {
                            res.SetPixel(x, y, originalImg.GetPixel(x, y));
                        }
                        else
                        {
                            res.SetPixel(x, y, Color.Black);
                        }
                    }
                }

            }

            for (int x = 1; x < originalImg.Width - 1; x++)
            {
                for (int y = 1; y < originalImg.Height - 1; y++)
                {
                    int gradiantX_B = (originalImg.GetPixel(x - 1, y).B - originalImg.GetPixel(x + 1, y).B) / 2;

                    int gradiantY_B = (originalImg.GetPixel(x, y - 1).G - originalImg.GetPixel(x, y + 1).B) / 2;

                    double Magnitude_B = Math.Sqrt((gradiantX_B * gradiantX_B) + (gradiantY_B * gradiantY_B));

                    Sum += Magnitude_B;


                    if (res.GetPixel(x, y) != Color.Black)
                    {
                        if (Magnitude_B > Threshold)
                        {
                            res.SetPixel(x, y, originalImg.GetPixel(x, y));
                        }
                        else
                        {
                            res.SetPixel(x, y, Color.Black);
                        }
                    }
                }

            }
            //Threshold = Sum/(originalImg.Width*originalImg.Height);
            //Console.WriteLine(originalImg.Width);
            //Console.WriteLine(originalImg.Height);
            //Console.WriteLine(Sum);
            //Console.WriteLine(Threshold);
            return res;
        }

    }
}

