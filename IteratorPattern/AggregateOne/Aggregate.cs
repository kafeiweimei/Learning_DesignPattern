using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.AggregateOne
{
    /// <summary>
    /// 聚合对象，定义创建相应迭代器对象的接口
    /// </summary>
    internal abstract class Aggregate
    {
        //工厂方法，场景相应迭代器对象的接口
        public abstract Itetator CreateIterator();

        //获取对象
        public abstract object Get(int index);

        //获取对象大小
        public abstract int Size();

    }//Class_end
}
