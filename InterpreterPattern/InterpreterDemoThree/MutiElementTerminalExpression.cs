using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 多元素作为终结符对应的解释器
    /// </summary>
    internal class MutiElementTerminalExpression : ReadXmlExpression
    {
        //元素的名字
        private string elementName = string.Empty;

        public MutiElementTerminalExpression(string elementName)
        {
            this.elementName = elementName;
        }

        public override string[] Interpret(Context c)
        {
            //先取出上下文中的当前元素作为父级元素
            List<XElement> parentElementList = c.PreElementList;
            //获取当前的多个元素
            List<XElement> currentElementList = new List<XElement>();

            foreach (XElement element in parentElementList)
            {
                currentElementList.AddRange(c.GetCurrentEle(element, elementName));
            }

            //获取这些元素值
            string[] ss = new string[currentElementList.Count];
            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = currentElementList[i].FirstNode.ToString();
            }
            return ss;
        }
    }//Class_end
}
