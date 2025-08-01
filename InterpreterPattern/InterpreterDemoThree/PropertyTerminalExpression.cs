using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 属性作为终结符对应的解释器
    /// </summary>
    internal class PropertyTerminalExpression : ReadXmlExpression
    {
        //属性
        private string propertyName = string.Empty;

        public PropertyTerminalExpression(string propertyName)
        {
            this.propertyName = propertyName;
        }

        public override string[] Interpret(Context c)
        {
            //直接获取最后的元素属性值
            string[] ss = new string[1];

            XElement element = c.PreElementList[0];
            IEnumerable<XAttribute> xAttributeList = element.Attributes();
            foreach (XAttribute xAttribute in xAttributeList)
            {
                if (xAttribute.Name.LocalName.Equals(propertyName))
                {
                    ss[0] = xAttribute.Value;
                }
            }
            return ss;
        }
    }//Class_end
}
