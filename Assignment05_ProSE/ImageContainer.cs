using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace Assignment05_ProSE
{
    
    public class ImageContainer
    {
        //Image1
        public Bitmap originalImage;
        public Bitmap newImage;

       
        public ImageContainer(Bitmap image)
        {
            originalImage = image;
            newImage = new Bitmap(image);
            
        }
        public void ProcessImage()
        {
            while (true)
            {
                Monitor.Enter(this);
                 
                SoebelFilter image1 = new SoebelFilter();
                Bitmap newImage = image1.GetBoundary(originalImage);

                Monitor.Exit(this);
            }
        }



    }
}
