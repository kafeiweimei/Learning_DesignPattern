using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 用来封装每一个解析出来的元素对应的属性
    /// </summary>
    internal class ParserModel
    {
        /// <summary>
        /// 是否单个值
        /// </summary>
        public bool SingleValue { get; set; }

        /// <summary>
        /// 是否是属性（不是就是元素）
        /// </summary>
        public bool PropertyValue { get; set; }

        /// <summary>
        /// 是否是终结符
        /// </summary>
        public bool End { get; set; }

    }//Class_end
}
