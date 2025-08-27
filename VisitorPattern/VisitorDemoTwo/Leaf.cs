using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.VisitorDemoTwo
{
    /// <summary>
    /// 叶子对象，相当于访问者模式的具体Element实现对象
    /// </summary>
    internal class Leaf : Component
    {
        //叶子对象的名称
        private string name = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">需传入的叶子对象名称</param>
        public Leaf(string name)
        {
            this.name = name;
        }

        public string GetName
        {
            get { return name; }
        }

        public override void Accept(IVisitor visitor)
        {
            //回调访问者对象的相应方法
            visitor.VisitLeaf(this);
        }
    }//Class_end
}
