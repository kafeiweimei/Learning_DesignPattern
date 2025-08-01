using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoTwo
{
    /// <summary>
    /// 上下文【用来包含解释器需要的一些全局信息】
    /// </summary>
    internal class Context
    {
        //上一次被处理的多个元素
        private List<XElement> preElementList = new List<XElement>();
        //Dom解析xml的Document对象
        private XDocument document = null;

        public List<XElement> PreElementList { get=>preElementList; set=>preElementList=value; }
        public XDocument Document { get=>document; }


        /// <summary>
        /// 构造方法
        /// </summary>
        public Context(string filePathName)
        {
            if (string.IsNullOrEmpty(filePathName))
            {
                return;
            }

            document = XmlUtil.GetXDocument(filePathName);
        }

        /// <summary>
        /// 重新初始化上下文
        /// </summary>
        public void ReInit()
        {
            preElementList = new List<XElement>();
        }

        /// <summary>
        /// 各个Expression公共使用的方法(根据父元素和当前元素名称获取到当前的元素)
        /// </summary>
        /// <param name="parentElement">父元素</param>
        /// <param name="curElementName">当前元素名称</param>
        /// <returns>找到的当前元素</returns>
        public List<XElement> GetCurrentEle(XElement parentElement, string curElementName)
        {
            List<XElement> xElements = new List<XElement>();
            if (parentElement == null || string.IsNullOrEmpty(curElementName))
            {
                return xElements;
            }
            
            IEnumerable<XElement> tmpElementList = parentElement.Elements();
            foreach (XElement element in tmpElementList)
            {
                if (element is XElement)
                {
                    if (element.Name.LocalName.Equals(curElementName))
                    {
                       xElements.Add(element);
                    }
                }
            }

            return xElements;
        }

    }//Class_end
}
