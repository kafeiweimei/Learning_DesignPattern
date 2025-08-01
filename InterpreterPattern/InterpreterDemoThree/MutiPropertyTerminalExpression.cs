using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 以多个元素属性作为终结符对应的解释器
    /// </summary>
    internal class MutiPropertyTerminalExpression : ReadXmlExpression
    {
        //属性名称
        private string propertyName = string.Empty;

        public MutiPropertyTerminalExpression(string propertyName)
        {
            this.propertyName = propertyName;
        }

        public override string[] Interpret(Context c)
        {
            //直接获取最后的多个元素属性值
            List<XElement> elementList = c.PreElementList;
            string[] ss = new string[elementList.Count];

            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = elementList[i].Attribute(propertyName).Value;
            }
            return ss;
        }
    }//Class_end
}
