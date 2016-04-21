using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDev.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 得到文件后缀所对应的 mime
        /// 如.jpg->image/jpeg
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static string GetMimeMapping(string fileExtension)
        {
            var mimeType = "application/octet-stream";
            if (!string.IsNullOrEmpty(fileExtension))
            {
                if (!fileExtension.StartsWith("."))
                {
                    fileExtension = "." + fileExtension;
                }
                var regKey = Registry.ClassesRoot.OpenSubKey(fileExtension);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                {
                    mimeType = regKey.GetValue("Content Type").ToString();
                }
            }
            return mimeType;
        }
        /// <summary>
        /// 得到 mime 对应的文件后缀(多个时，取第1个)
        /// 如image/jpeg->.jpg
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string GetExtension(string contentType)
        {
            var fileExtension = string.Empty;
            if (!string.IsNullOrEmpty(contentType))
            {
                var query = from item in Registry.ClassesRoot.GetSubKeyNames()
                            let key = Registry.ClassesRoot.OpenSubKey(item)
                            let value = key.GetValue("Content Type")
                            where value != null && value.ToString().Equals(contentType, StringComparison.OrdinalIgnoreCase)
                            select item;
                return query.FirstOrDefault();
            }
            return fileExtension;
        }

        public static int SaveAs(string path, bool createDir = true, bool overwrite = true)
        {
            //var dir = Path.GetDirectoryName(path);
            //var file = Path.GetFileName(path);
            //if (File.Exists(path) && !overwrite)
            //{
            //    return false;
            //}
            return 0;
        }

        /// <summary>
        /// 判断所给字符串是否是有效路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="absolute">为True时，仅判断绝对路径；为False时，判断绝对路径和相对路径</param>
        /// <returns>
        /// 1:绝对路径（目录）
        /// 2:绝对路径（文件）
        /// 3:相对路径（目录）
        /// 4:相对路径（文件）
        /// -1:无效路径
        /// </returns>
        public static int IsValidPath(string path)
        {
            if (path == null)
            {
                return -1;
            }
            var localPath = path.Replace(@"/", @"\");

            var fileEx = string.Empty;
            try
            {
                fileEx = Path.GetExtension(localPath);
            }
            catch
            {
                return -1;//无效路径
            }

            #region 绝对路径判断

            var isAbsolute = false;
            var az = new char[] { 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b' };
            foreach (var item in az)
            {
                if (path.StartsWith(item + ":", true, null))
                {
                    isAbsolute = true;
                    break;
                }
            }

            #endregion

            #region 目录or文件

            //1:目录;2:文件.
            ////无后缀，以为是目录；有后缀，以为是文件。
            var dirOrFile = 1;//目录
            if (!string.IsNullOrEmpty(fileEx))
            {
                dirOrFile = 2;//文件
            }

            #endregion

            if (isAbsolute && dirOrFile == 1)
            {
                return 1;//绝对路径（目录）
            }
            else if (isAbsolute && dirOrFile == 2)
            {
                return 2;//绝对路径（文件）
            }
            else if (!isAbsolute && dirOrFile == 1)
            {
                return 3;//相对路径（目录）
            }
            else if (!isAbsolute && dirOrFile == 2)
            {
                return 4;//相对路径（文件）
            }
            return 0;
        }
    }
}
