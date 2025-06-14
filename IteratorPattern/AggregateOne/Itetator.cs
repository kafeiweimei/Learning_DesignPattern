using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.AggregateOne
{
    /// <summary>
    /// 迭代器接口，定义访问和遍历元素的操作
    /// </summary>
    internal interface Itetator
    {
        /// <summary>
        /// 移动到聚合对象的第一个位置
        /// </summary>
        void First();

        /// <summary>
        /// 移动到聚合对象的下一个位置
        /// </summary>
        void Next();

        /// <summary>
        /// 判断是否已经移动到聚合对象的最后一个位置
        /// </summary>
        /// <returns>true:表示已经移动到聚合对象的最后一个位置</returns>
        bool IsDone();

        /// <summary>
        /// 获取迭代的当前元素
        /// </summary>
        /// <returns></returns>
        object CurrentItem();

    }//Interface_end
}
