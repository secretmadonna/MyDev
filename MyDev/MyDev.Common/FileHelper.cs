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

        /// <summary>
        /// 将流保存为文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path">必须是文件全称(包含绝对路径，如：d:\abc\abc.jpg)</param>
        /// <param name="createDir"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static int SaveAs(Stream stream, string path, bool createDir = true, bool overwrite = true)
        {
            var result = -1;
            try
            {
                var fileResult = IsValidPath(path);
                if (fileResult == 111)
                {
                    if (overwrite)
                    {
                        File.Delete(path);
                        using (var fs = File.Create(path))
                        {
                            stream.CopyTo(fs);
                        }
                        result = 1;//文件存在，先删除，再创建
                    }
                    result = -2;//文件存在，不覆盖
                }
                else if (fileResult == 101)
                {
                    using (var fs = File.Create(path))
                    {
                        stream.CopyTo(fs);
                    }
                    result = 3;//文件被创建
                }
                else if (fileResult == 100 && createDir)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    using (var fs = File.Create(path))
                    {
                        stream.CopyTo(fs);
                    }
                    result = 4;//文件被创建，且目录被先创建
                }
            }
            catch (Exception ex)
            {
                result = -99;
                //记录日志？？？
            }
            return result;
        }
        /// <summary>
        /// 将字节数组保存为文件
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="path">必须是文件全称(包含绝对路径，如：d:\abc\abc.jpg)</param>
        /// <param name="createDir"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static int SaveAs(byte[] bytes, string path, bool createDir = true, bool overwrite = true)
        {
            var result = -1;
            try
            {
                var fileResult = IsValidPath(path);
                if (fileResult == 111)
                {
                    if (overwrite)
                    {
                        File.Delete(path);
                        using (var fs = File.Create(path))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }
                        result = 1;//文件存在，先删除，再创建
                    }
                    result = -2;//文件存在，不覆盖
                }
                else if (fileResult == 101)
                {
                    using (var fs = File.Create(path))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    result = 3;//文件被创建
                }
                else if (fileResult == 100 && createDir)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    using (var fs = File.Create(path))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                    result = 4;//文件被创建，且目录被先创建
                }
            }
            catch (Exception ex)
            {
                result = -99;
                //记录日志？？？
            }
            return result;
        }

        /// <summary>
        /// 判断所给字符串是否是有效路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// 111：有效的绝对文件路径，文件存在，目录存在
        /// 101：有效的绝对文件路径，文件不存在，目录存在
        /// 100：有效的绝对文件路径，文件不存在，目录不存在
        /// 21：有效的绝对目录路径，目录存在
        /// 20：有效的绝对目录路径，目录不存在
        /// 3：有效的相对文件路径（不一定是相对当前目录，所以无法做文件存在、目录存在的判断）
        /// 4：有效的相对目录路径（不一定是相对当前目录，所以无法做目录存在的判断）
        /// -1：无效路径
        /// </returns>
        public static int IsValidPath(string path)
        {
            try
            {
                var localPath = path.Replace(@"/", @"\");

                #region 文件or目录判断

                var isFile = false;
                var fileExist = false;
                var dirExist = false;
                if (File.Exists(localPath))
                {
                    fileExist = true;
                    isFile = true;
                }
                else if (Directory.Exists(localPath))
                {
                    dirExist = true;
                    isFile = false;
                }
                else if (Path.HasExtension(localPath))
                {
                    isFile = true;
                }

                #endregion

                #region 绝对路径判断

                var isAbsolute = false;
                var az = new char[] { 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b' };
                foreach (var item in az)
                {
                    if (localPath.StartsWith(item + ":", true, null))
                    {
                        isAbsolute = true;
                        break;
                    }
                }

                #endregion

                #region return

                if (isAbsolute && isFile)//绝对路径（文件）
                {
                    if (fileExist)
                    {
                        return 111;
                    }
                    else if (Directory.Exists(Path.GetDirectoryName(localPath)))
                    {
                        return 101;
                    }
                    return 100;
                }
                else if (isAbsolute && !isFile)//绝对路径（目录）
                {
                    if (dirExist)
                    {
                        return 21;
                    }
                    return 20;
                }
                else if (!isAbsolute && isFile)//相对路径（文件）
                {
                    return 3;
                }
                else if (!isAbsolute && !isFile)//相对路径（目录）
                {
                    return 4;
                }

                #endregion
            }
            catch (Exception ex)
            {
                //记录日志？？？
            }
            return -1;
        }

        /// <summary>
        /// 判断所给字符串是否是有效的相对路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="absolutePath">相对于该目录进行检查，该目录必须存在</param>
        /// <param name="dealPath">处理“相对路径”后返回的“绝对路径”</param>
        /// <returns>
        /// -1：无效相对路径
        /// -2：参数absolutePath非绝对路径
        /// -3：参数absolutePath所对应的目录必须存在
        /// -4：参数path是绝对路径
        /// 111:path相对于absolutePath，路径是有效的文件路径，且文件存在，目录存在
        /// 101:path相对于absolutePath，路径是有效的文件路径，且文件不存在，目录存在
        /// 100:path相对于absolutePath，路径是有效的文件路径，且文件不存在，目录不存在
        /// 21：path相对于absolutePath，路径是有效的目录路径，且目录存在
        /// 20：path相对于absolutePath，路径是有效的目录路径，且目录不存在
        /// </returns>
        public static int IsValidRelativePath(string path, string absolutePath, out string dealPath)
        {
            dealPath = null;
            try
            {
                var localAbsolutePath = absolutePath.Replace(@"/", @"\");

                #region 绝对路径判断

                var isAbsolute = false;
                var az = new char[] { 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b' };
                foreach (var item in az)
                {
                    if (localAbsolutePath.StartsWith(item + ":", true, null))
                    {
                        isAbsolute = true;
                        break;
                    }
                }
                if (!isAbsolute)
                {
                    return -2;
                }

                #endregion

                if (!Directory.Exists(localAbsolutePath))
                {
                    return -3;
                }


                var localPath = path.Replace(@"/", @"\");

                #region 绝对路径判断

                isAbsolute = false;
                foreach (var item in az)
                {
                    if (localPath.StartsWith(item + ":", true, null))
                    {
                        isAbsolute = true;
                        break;
                    }
                }
                if (isAbsolute)
                {
                    return -4;
                }

                #endregion

                var realPath  = localAbsolutePath.TrimEnd('\\') + "\\" + localPath.TrimStart('\\');

                #region 文件or目录判断

                var isFile = false;
                var fileExist = false;
                var dirExist = false;
                if (File.Exists(realPath))
                {
                    fileExist = true;
                    isFile = true;
                }
                else if (Directory.Exists(realPath))
                {
                    dirExist = true;
                    isFile = false;
                }
                else if (Path.HasExtension(realPath))
                {
                    isFile = true;
                }

                #endregion

                #region return

                if (isFile)
                {
                    if (fileExist)
                    {
                        dealPath = realPath;
                        return 111;
                    }
                    else if (Directory.Exists(Path.GetDirectoryName(realPath)))
                    {
                        dealPath = realPath;
                        return 101;
                    }
                    dealPath = realPath;
                    return 100;
                }
                else
                {
                    if (dirExist)
                    {
                        dealPath = realPath;
                        return 21;
                    }
                    dealPath = realPath;
                    return 20;
                }

                #endregion
            }
            catch (Exception ex)
            {
                //记录日志？？？
            }
            return -1;
        }
    }
}
