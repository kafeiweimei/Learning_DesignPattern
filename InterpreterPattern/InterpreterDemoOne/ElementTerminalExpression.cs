using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoOne
{
    /// <summary>
    /// 元素作为终结符对应的解释器
    /// </summary>
    internal class ElementTerminalExpression:ReadXmlExpression
    {
        //元素的名字
        private string elementName=string.Empty;

        public ElementTerminalExpression(string elementName)
        {
            this.elementName = elementName;
        }

        public override string[] Interpret(Context c)
        {
            //先取出上下文中的当前元素作为父级元素
            XElement parentElement = c.PreEle;
            //查找到当前元素名称对应的xml元素
            XElement element = null;

            if (parentElement == null)
            {
                //说明现在获取的是根元素
                element = c.Document.Root;
                c.PreEle = element;
            }
            else
            {
                //根据父级元素和要查找的元素名称来获取当前的元素
                element = c.GetCurrentEle(parentElement,elementName);
                //把当前获取到的元素放到上下文中
                c.PreEle = element;
            }
            //然后根据需要去获取这个元素的值
            string[] ss=new string[1];
            ss[0] = element.FirstNode.ToString();
            return ss;

        }
    }//Class_end
}
