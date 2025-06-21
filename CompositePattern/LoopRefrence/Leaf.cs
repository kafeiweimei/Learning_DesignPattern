using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.LoopRefrence
{
    /// <summary>
    /// 叶子对象
    /// </summary>
    internal class Leaf : Component
    {
        //叶子对象名称
        private string name = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">叶子对象名称</param>
        public Leaf(string name)
        {
            this.name = name;
        }

        public override void Add(Component child)
        {
            throw new NotImplementedException();
        }

        public override List<Component> GetAllChildren()
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 输出叶子对象的结构【由于叶子对象没有子对象，也就是说可以直接输出对象名称】
        /// </summary>
        /// <param name="preStr">前缀，主要是按照层级拼接的空格，向后缩进</param>
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
