using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.CompositeDemo
{
    /// <summary>
    /// 叶子对象
    /// </summary>
    internal class Leaf : Component
    {
        //叶子对象名称
        private string name=string.Empty;

        public Leaf(string name)
        {
            this.name = name;
        }

        public override void Add(Component child)
        {
            throw new NotImplementedException();
        }

        public override Component GetComponent(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 输出叶子对象结构【由于叶子对象没有子对象即只用输出叶子对象的名称】
        /// </summary>
        /// <param name="preStr">前缀，主要是按照层级拼接的</param>
        public override void PrintStruct(string preStr)
        {
            Console.WriteLine($"{preStr}-{name}");
        }

        public override void Remove(Component child)
        {
            throw new NotImplementedException();
        }
    }//Class_end
}
