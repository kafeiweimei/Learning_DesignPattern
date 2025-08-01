using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern.InterpreterDemoTwo
{
    /// <summary>
    /// 读取xml取值表达式
    /// </summary>
    abstract class ReadXmlExpression
    {
        /// <summary>
        /// 解释表达式
        /// </summary>
        public abstract string[] Interpret(Context c);

    }//Class_end
}
