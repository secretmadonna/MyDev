using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyDev.Common
{
    //public class Path
    //{
    //    /// <summary>
    //    /// 是否是有效路径
    //    /// </summary>
    //    public bool IsValid { get; }
    //    /// <summary>
    //    /// 1:相对路径;2:绝对路径
    //    /// </summary>
    //    public int? AbsoluteOrRelative { get; }
    //    /// <summary>
    //    /// 驱动器(不包含: \ /)
    //    /// </summary>
    //    public string Driver { get; }
    //    /// <summary>
    //    /// 1:目录;2:文件
    //    /// </summary>
    //    public int? DirOrFile { get; }
    //    /// <summary>
    //    /// 目录是否存在
    //    /// </summary>
    //    public bool? DirExist { get; }
    //    /// <summary>
    //    /// 文件是否存在
    //    /// </summary>
    //    public bool? FileExist { get; }

    //    /// <summary>
    //    /// 文件夹名字只能包含a-zA-z
    //    /// </summary>
    //    /// <param name="path"></param>
    //    public Path(string path)
    //    {
    //    }
    //}

    public class StringHelper
    {
        /// <summary>
        /// 判断所给字符串是否是有效路径
        /// 1:成功
        /// -99:异常
        /// -1:绝对路径必须以a:-z:或A:-Z:开头
        /// -2:path和realPath不相等
        /// </summary>
        /// <param name="path"></param>
        /// <param name="absolute">为True时，仅判断绝对路径；为False时，判断绝对路径和相对路径</param>
        /// <returns></returns>
        private static int IsValidPath(string path, bool absolute = true)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("参数{0}不能是null或空", "path");
            }
            try
            {
                #region 绝对路径判断

                var startOk = false;
                if (absolute)
                {
                    var az = new char[] { 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b' };
                    foreach (var item in az)
                    {
                        if (path.StartsWith(item + ":", true, null))
                        {
                            startOk = true;
                            break;
                        }
                    }
                    if (!startOk)
                    {
                        //记录日志？？？
                        return -1;
                    }
                }

                #endregion

                var dirName = Path.GetDirectoryName(path);
                var fileName = Path.GetFileName(path);

                var realPath = string.Empty;
                if (!string.IsNullOrEmpty(fileName))
                {
                    realPath = Path.Combine(dirName, fileName);
                }
                else
                {
                    realPath = dirName + "\\";
                }
                if (path.Replace(@"\", @"/") != realPath.Replace(@"\", @"/"))
                {
                    //记录日志？？？
                    return -2;
                }
                if (startOk)
                {
                    return 2;
                }
                return 1;
            }
            catch
            {
                //记录日志？？？
                return -99;
            }
        }

        public static bool IsValidPath(string path)
        {
            var strlist = path.Split(new char[] { '\\', '/' });
            for (int i = 0; i < strlist.Length; i++)
            {
                
            }
            return false;
        }
    }
}
