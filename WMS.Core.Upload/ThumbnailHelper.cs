using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WMS.Common.Utility;
using WMS.Core.Config;

namespace WMS.Core.Upload
{
    public class ThumbnailHelper
    {
        /// <summary>
        /// 转换如/upload/unit/day_111121/201111211132325858.jpg成/upload/unit/day_111121/Thumb/201111211132325858_400_300.jpg或...400_300.jpg.axd
        /// </summary>
        /// <param name="rawUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string GetThumbnailUrl(string rawUrl, int width, int height)
        {
            var m = Regex.Match(rawUrl, @"^(.*)/upload/(.+)/(day_\d+)/(\d+)(\.[A-Za-z]+)$", RegexOptions.IgnoreCase);

            if (!m.Success)
                return string.Empty;

            var root = m.Groups[1].Value;
            var folder = m.Groups[2].Value;
            var subFolder = m.Groups[3].Value;
            var fileName = m.Groups[4].Value;
            var ext = m.Groups[5].Value;

            string key = string.Format("{0}_{1}_{2}", folder, width, height).ToLower();
            bool isOnDemandSize = UploadConfigContext.ThumbnailConfigDic.ContainsKey(key) && UploadConfigContext.ThumbnailConfigDic[key].Timming == Timming.OnDemand;
            if (isOnDemandSize)
                ext += ".axd";

            var url = string.Format("{0}/upload/{1}/{2}/thumb/{3}_{4}_{5}{6}", root, folder, subFolder, fileName, width, height, ext);

            return url;
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, ThumbnailSize size)
        {
            try
            {
                ImageUtil.MakeThumbnail(originalImagePath, thumbnailPath, 
                    size.Width, 
                    size.Height, 
                    size.Mode, 
                    size.AddWaterMarker, 
                    size.WaterMarkerPosition, 
                    size.WaterMarkerPath, 
                    size.Quality);

                Console.WriteLine("生成成功:{0}", thumbnailPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("生成失败，非标准图片:{0}", thumbnailPath);
                //_Logger.Error(string.Format("{0} 生成失败，非标准图片", thumbnailPath), e);
            }
        }

        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode = "Cut", bool isaddwatermark = false, int quality = 88)
        {
            var size = new ThumbnailSize() { Width = width, Height = height, Mode = mode, AddWaterMarker = isaddwatermark, Quality = quality};
            MakeThumbnail(originalImagePath, thumbnailPath, size);
        }

        /// <summary>
        /// 获取文件类型
        /// 通过base64过滤后的第一个字符串
        /// </summary>
        /// <param name="base64_0"></param>
        /// <returns></returns>
        public static string GetExtType(string base64_0)
        {
            base64_0 = base64_0.ToLower();
            switch(base64_0)
            {
                    case "data:image/jpg;base64":
                    return "jpg";
                case "data:image/jpeg;base64":
                    return "jpeg";
                case "data:image/png;base64":
                    return "png";
                    case "data:image/gif;base64":
                    return "gif";
                    case "data:text/plain":
                case "data:":
                    return "txt";
                default :
                    return "";
            }
            //data:,文本数据
            //data:text/plain,文本数据
            //data:text/html,HTML代码
            //data:text/html;base64,base64编码的HTML代码
            //data:text/css,CSS代码
            //data:text/css;base64,base64编码的CSS代码
            //data:text/javascript,Javascript代码
            //data:text/javascript;base64,base64编码的Javascript代码
            //data:image/gif;base64,base64编码的gif图片数据
            //data:image/png;base64,base64编码的png图片数据
            //data:image/jpeg;base64,base64编码的jpeg图片数据
            //data:image/x-icon;base64,base64编码的icon图片数据
        }
    }
}
