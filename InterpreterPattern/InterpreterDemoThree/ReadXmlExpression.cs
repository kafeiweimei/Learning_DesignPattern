using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 用于处理自定义xml取值表达式的【抽象解释器】
    /// </summary>
    abstract class ReadXmlExpression
    {
        /// <summary>
        /// 解释表达式
        /// </summary>
        public abstract string[] Interpret(Context c);

    }//Class_end
}
