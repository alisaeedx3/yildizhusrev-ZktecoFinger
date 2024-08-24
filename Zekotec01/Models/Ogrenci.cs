using System;
using System.Drawing;
using System.IO;

namespace Zekotec01.Models
{
    class Ogrenci
    {
        public string ResimBase64String;
        public Image ResimImage;
        public byte[] ResimByte;

        public string ConvertImageToBase64()// System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                ResimImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                return Convert.ToBase64String(imageBytes);
                
            }
        }

        public Image ConvertBase64ToImage()
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(ResimBase64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            return Image.FromStream(ms, true);
            
        }

        public byte[] ConvertImageToByte()// System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                ResimImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                return imageBytes;
                // Convert byte[] to Base64 String
                //return Convert.ToBase64String(imageBytes);

            }
        }

        public Image ConvertByteToImage()
        {
            // Convert Base64 String to byte[]
            //byte[] imageBytes = Convert.FromBase64String(ResimBase64String);
            byte[] imageBytes = ResimByte;
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            return Image.FromStream(ms, true);

        }
    }
}
