using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    /// <summary>
    /// 叶子对象
    /// </summary>
    internal class Leaf
    {
        //叶子对象的名字
        private string name;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">叶子对象的名称</param>
        public Leaf(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 输出叶子对象的结构，叶子对象没有子对象【即只输出叶子对象的名称】
        /// </summary>
        /// <param name="preStr">前缀【主要是按照层级拼接的空格，实现向后缩进】</param>
        public void PrintStruct(string preStr)
        {
            Console.WriteLine($"{preStr}-{name}");
        }

    }//Class_end
}
