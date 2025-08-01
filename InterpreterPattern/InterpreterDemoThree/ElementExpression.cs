using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 单元素作为非终结符对应的解释器，解释并执行中间元素【面向多个父元素】
    /// </summary>
    internal class ElementExpression : ReadXmlExpression
    {
        //用来记录组合的ReadXmlExpression元素
        private List<ReadXmlExpression> readXmlExpressionList = new List<ReadXmlExpression>();

        //元素名称
        private string elementName = string.Empty;

        public ElementExpression(string elementName)
        {
            this.elementName = elementName;
        }

        public bool AddElement(ReadXmlExpression readXmlExpression)
        {
            readXmlExpressionList.Add(readXmlExpression);
            return true;
        }

        public bool RemoveElement(ReadXmlExpression readXmlExpression)
        {
            readXmlExpressionList.Remove(readXmlExpression);
            return true;
        }

        public override string[] Interpret(Context c)
        {
            /*1-获取上下文的当前元素作为父级元素*/
            List<XElement> parentElementList = c.PreElementList;
            XElement xElement = null;
            //查找到当前元素名称所对应的xml元素，并设置回到上下文中
            List<XElement> currentElementList = new List<XElement>();

            if (parentElementList == null || parentElementList?.Count <= 0)
            {
                //说明现在获取的是根元素
                xElement = c.Document.Root;
                parentElementList.Add(xElement);
                c.PreElementList = parentElementList;
            }
            else
            {
                //根据父级元素和要查找的元素名称来获取当前的元素
                foreach (var item in parentElementList)
                {
                    currentElementList.AddRange(c.GetCurrentEle(item, elementName));
                    if (currentElementList != null && currentElementList?.Count > 0)
                    {
                        //找到一个就停止查找了
                        break;
                    }
                }
                List<XElement> tmpElementList = new List<XElement>();
                tmpElementList.Add(currentElementList[0]);
                c.PreElementList = tmpElementList;
            }

            //循环调用子元素的Interparet方法
            string[] ss = null;
            foreach (var item in readXmlExpressionList)
            {
                ss = item.Interpret(c);
            }
            return ss;
        }

    }//Class_end
}
