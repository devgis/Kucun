//引用命名空间  
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System;

namespace CY.express
{
    class  pic
    {
        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片</param>
        /// <param name="dFile">压缩后保存位置</param>
        /// <param name="dHeight">高度</param>
        /// <param name="dWidth"></param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>

        public static Image GetPicThumbnail(string sFile, string dFile)
        {
            int dHeight; 
            int dWidth;
            int flag= 100;
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);

            ImageFormat tFormat = iSource.RawFormat;

             int sW = 0, sH = 0;

            //按比例缩放

            Size tem_size = new Size(iSource.Width, iSource.Height);
            dHeight = iSource.Height;
            dWidth=iSource.Width;
            if (iSource.Width > 600)
            { 
                double dRate=600.0000000/Convert.ToDouble(iSource.Width);
                dWidth=System.Convert.ToInt32(iSource.Width*dRate);
                dHeight=System.Convert.ToInt32(iSource.Height*dRate);
            }
            if (dHeight > 600)
            {
                double dRate =600.0000000 / Convert.ToDouble(dHeight);
                dWidth=System.Convert.ToInt32(iSource.Width*dRate);
                dHeight = System.Convert.ToInt32(dHeight * dRate);
            }


            if (tem_size.Width > dHeight || tem_size.Width > dWidth) //将**改成c#中的或者操作符号
            {

                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {

                    sW = dWidth;

                    sH = (dWidth * tem_size.Height) / tem_size.Width;

                }

                else
                {

                    sH = dHeight;

                    sW = (tem_size.Width * dHeight) / tem_size.Height;

                }

            }

            else
            {

                sW = tem_size.Width;

                sH = tem_size.Height;

            }

            Bitmap ob = new Bitmap(dWidth, dHeight);

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);

            g.CompositingQuality = CompositingQuality.HighQuality;

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量

            EncoderParameters ep = new EncoderParameters();

            long[] qy = new long[1];

            qy[0] = flag;//设置压缩的比例1-100

            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

            ep.Param[0] = eParam;

            try
            {

                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();

                ImageCodecInfo jpegICIinfo = null;

                for (int x = 0; x < arrayICI.Length; x++)
                {

                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {

                        jpegICIinfo = arrayICI[x];

                        break;

                    }

                }

                if (jpegICIinfo != null)
                {

                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径

                }

                else
                {

                    ob.Save(dFile, tFormat);

                }
               Image img=  Image.FromFile(dFile);
               return img;

            }

            catch(System.Exception ex)
            {
                throw ex;
            }

            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
    }
}
