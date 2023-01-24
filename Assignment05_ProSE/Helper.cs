using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment05_ProSE
{
    
    public class Helper
    {
        public static List<ImageContainer> ImportImages()
        {
            List<string> paths = new List<string>();
            List<Bitmap> Images = new List<Bitmap>();
            List<ImageContainer> imageContainers = new List<ImageContainer>();
            for (int i = 0; i < 5; i++)
            {
                // add an image path to the list
                paths.Add(string.Format("C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image{0}.jpg", i + 1));
                // create an image as bitmap with a path
                Bitmap aImage = new Bitmap(paths[i]);
                // set a tag of the image
                aImage.Tag = string.Format("image{0}", i + 1);
                // add an bitmap image to bitmap list
                Images.Add(aImage);
                // add an imageContainer in the imageContainer List
                imageContainers.Add(new ImageContainer(Images[i]));
            }
            return imageContainers;
        }

        public static void ExportImages(List<ImageContainer> imageContainers)
        {
            for (int i = 0; i < 5; i++)
            {
                string resultPath = string.Format("C:\\Users\\Anwender\\Documents\\GitHub\\Assignment05_ProSE\\sampleImages\\image{0}_result.jpg", i + 1);
                imageContainers[i].Result.Save(resultPath);
            }
        }
    }
}
