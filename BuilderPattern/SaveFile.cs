using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 保存文件
    /// </summary>
    internal class SaveFile
    {
        private static string path=AppDomain.CurrentDomain.BaseDirectory+"Builder";

        //文件输出路径
        public static string Path 
        {
            get 
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;       
            }
        
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="fileInfo">文件内容信息</param>
        /// <returns></returns>
        public static bool Save(string fileName,string fileInfo)
        {
            bool result = false;
            if (string.IsNullOrEmpty(fileName)||string.IsNullOrEmpty(fileInfo)) 
            { 
                return result;
            }

            string filePathAndName = $"{Path}\\{fileName}";
            File.WriteAllText(filePathAndName, fileInfo,Encoding.UTF8);
            result = true;
            return result;
        }

    }//Class_end
}
