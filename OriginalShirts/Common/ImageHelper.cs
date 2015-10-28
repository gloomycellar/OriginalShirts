using ImageProcessor;
using ImageProcessor.Imaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace OriginalShirts.Common
{
    public static class ImageHelper
    {
        public static string PatternBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["PatternBaseUrl"];
            }
        }

        public static string LogoBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["LogoBaseUrl"];
            }
        }

        public static byte[] GetTestImage(string path1, string path2)
        {
            //Standart functionality
            Image yellowImage = Image.FromFile(path1);
            Image redImage = Image.FromFile(path2);

            using (var memStream = new MemoryStream())
            {
                Bitmap bitmap = MergeTwoImages(yellowImage, redImage);
                bitmap.Save(memStream, ImageFormat.Png);

                return memStream.GetBuffer();
            }

            //------------

            //byte[] photoBytes = File.ReadAllBytes(path1); // change imagePath with a valid image path
            //int quality = 70;
            ////ImageFormat format = ImageFormat.Png; // we gonna convert a jpeg image to a png one
            //var size = new Size(200, 200);

            //using (var inStream = new MemoryStream(photoBytes))
            //{
            //    using (MemoryStream outStream = new MemoryStream())
            //    {
            //        // Initialize the ImageFactory using the overload to preserve EXIF metadata.
            //        using (var imageFactory = new ImageFactory(preserveExifData: true))
            //        {
            //            // Do your magic here
            //            imageFactory.Load(inStream)
            //                //.Rotate(new RotateLayer(90))
            //                //.RoundedCorners(new RoundedCornerLayer(190, true, true, true, true))
            //                .Watermark(new TextLayer()
            //                {
            //                    DropShadow = true,
            //                    //Font = "Arial",
            //                    Text = "Watermark",
            //                    Style = FontStyle.Bold,
            //                    //TextColor = Color.DarkBlue
            //                })
            //                .Resize(size)
            //                //.Format(format)
            //                .Quality(quality)
            //                .Save(outStream);
            //        }

            //        return outStream.GetBuffer();
            //    }
            //}

            //Imageprocessor
            //byte[] path1Bytes = File.ReadAllBytes(path1); 
            //Size size = new Size(478, 478);

            //using (MemoryStream inStream = new MemoryStream(path1Bytes))
            //{
            //    using (MemoryStream outStream = new MemoryStream())
            //    {
            //        using (var imageFactory = new ImageFactory(preserveExifData: true))
            //        {
            //            imageFactory
            //                .Load(inStream)
            //                .Overlay(new ImageLayer
            //                {
            //                    Image = Image.FromFile(path2),
            //                    Opacity = 100
            //                })
            //                .Quality(100)
            //                .Save(outStream);
            //        }

            //        return outStream.GetBuffer();
            //    }
            //}
        }

        public static Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }

            int outputImageWidth = 478;// firstImage.Width > secondImage.Width ? firstImage.Width : secondImage.Width;

            int outputImageHeight = 478;// firstImage.Height + secondImage.Height + 1;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                //graphics.DrawImage(
                //    firstImage,
                //    new Rectangle(new Point(), firstImage.Size),
                //    new Rectangle(new Point(), firstImage.Size),
                //    GraphicsUnit.Pixel);

                //graphics.DrawImage(
                //    secondImage,
                //    new Rectangle(new Point(0, firstImage.Height), secondImage.Size),
                //    new Rectangle(new Point(), secondImage.Size),
                //    GraphicsUnit.Pixel);

                //graphics.DrawImage(secondImage, 100, 100, secondImage.Width, secondImage.Height);

                //graphics.DrawImage(
                //     secondImage,
                //     new Rectangle(new Point(), secondImage.Size),
                //     new Rectangle(new Point(), secondImage.Size),
                //     GraphicsUnit.Pixel);

                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(firstImage, 0, 0, firstImage.Width, firstImage.Height);
                graphics.DrawImage(secondImage, 0, 0, secondImage.Width, secondImage.Height);
            }

            return outputImage;
        }

        public static class ImageUtilities
        {
            /// <summary>
            /// A quick lookup for getting image encoders
            /// </summary>
            private static Dictionary<string, ImageCodecInfo> encoders = null;

            /// <summary>
            /// A quick lookup for getting image encoders
            /// </summary>
            public static Dictionary<string, ImageCodecInfo> Encoders
            {
                //get accessor that creates the dictionary on demand
                get
                {
                    //if the quick lookup isn't initialised, initialise it
                    if (encoders == null)
                    {
                        encoders = new Dictionary<string, ImageCodecInfo>();
                    }

                    //if there are no codecs, try loading them
                    if (encoders.Count == 0)
                    {
                        //get all the codecs
                        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
                        {
                            //add each codec to the quick lookup
                            encoders.Add(codec.MimeType.ToLower(), codec);
                        }
                    }

                    //return the lookup
                    return encoders;
                }
            }

            /// <summary>
            /// Resize the image to the specified width and height.
            /// </summary>
            /// <param name="image">The image to resize.</param>
            /// <param name="width">The width to resize to.</param>
            /// <param name="height">The height to resize to.</param>
            /// <returns>The resized image.</returns>
            public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
            {
                //a holder for the result
                Bitmap result = new Bitmap(width, height);
                //set the resolutions the same to avoid cropping due to resolution differences
                result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                //use a graphics object to draw the resized image into the bitmap
                using (Graphics graphics = Graphics.FromImage(result))
                {
                    //set the resize quality modes to high quality
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //draw the image into the target bitmap
                    graphics.DrawImage(image, 0, 0, result.Width, result.Height);
                }

                //return the resulting bitmap
                return result;
            }

            /// <summary> 
            /// Saves an image as a jpeg image, with the given quality 
            /// </summary> 
            /// <param name="path">Path to which the image would be saved.</param> 
            /// <param name="quality">An integer from 0 to 100, with 100 being the 
            /// highest quality</param> 
            /// <exception cref="ArgumentOutOfRangeException">
            /// An invalid value was entered for image quality.
            /// </exception>
            public static void SaveJpeg(string path, Image image, int quality)
            {
                //ensure the quality is within the correct range
                if ((quality < 0) || (quality > 100))
                {
                    //create the error message
                    string error = string.Format("Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.", quality);
                    //throw a helpful exception
                    throw new ArgumentOutOfRangeException(error);
                }

                //create an encoder parameter for the image quality
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                //get the jpeg codec
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

                //create a collection of all parameters that we will pass to the encoder
                EncoderParameters encoderParams = new EncoderParameters(1);
                //set the quality parameter for the codec
                encoderParams.Param[0] = qualityParam;
                //save the image using the codec and the parameters
                image.Save(path, jpegCodec, encoderParams);
            }

            /// <summary> 
            /// Returns the image codec with the given mime type 
            /// </summary> 
            public static ImageCodecInfo GetEncoderInfo(string mimeType)
            {
                //do a case insensitive search for the mime type
                string lookupKey = mimeType.ToLower();

                //the codec to return, default to null
                ImageCodecInfo foundCodec = null;

                //if we have the encoder, get it to return
                if (Encoders.ContainsKey(lookupKey))
                {
                    //pull the codec from the lookup
                    foundCodec = Encoders[lookupKey];
                }

                return foundCodec;
            }
        }
    }
}