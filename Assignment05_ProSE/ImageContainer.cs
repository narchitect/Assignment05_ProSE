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
       
        
        static void Images()
        {
            List<Bitmap> imageList = new List<Bitmap>();
            string pathImage1 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image1.jpg";
            Bitmap originalImage1 = new Bitmap(pathImage1);
            imageList.Add(originalImage1);
            string newPathImage1 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image1Modified.jpg";
            Bitmap newImage1 = new Bitmap(originalImage1);
            string pathImage2 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image2.jpg";
            string newPathImage2 = "D:\\001_ITBE-Master\\ProSE\\Assignment-5\\Assignment-5-21-01-2023\\ImagesAssignment5\\image2Modified.jpg";
            

            Bitmap originalImage2 = new Bitmap(pathImage2);
            Bitmap newImage2 = new Bitmap(originalImage2);
        }

        


        //Image2
        

        

    }
}
