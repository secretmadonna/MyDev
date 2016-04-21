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
