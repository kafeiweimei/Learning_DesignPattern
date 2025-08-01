using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoTwo
{
    /// <summary>
    /// xml的工具类
    /// </summary>
    internal class XmlUtil
    {
        /// <summary>
        /// 获取到xml文件的XDocument
        /// </summary>
        /// <param name="filePathName">xml路径和文件(如：D:\\testfile\\xmlfile.xml)</param>
        /// <returns></returns>
        public static XDocument GetXDocument(string filePathName)
        {
            if (string.IsNullOrEmpty(filePathName)) return null;

            try
            {
                XDocument xDoc = XDocument.Load(filePathName);
                return xDoc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }//Class_end
}
