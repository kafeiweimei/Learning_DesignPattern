using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.PageTurning
{
    /// <summary>
    /// 定义翻页访问聚合元素的迭代接口
    /// </summary>
    internal interface IAggregateIterator
    {
        /// <summary>
        /// 判断是否还有下一个元素（无论是否足够一页的数据）因为最后哪怕只有一条数据也算一页
        /// </summary>
        /// <returns>若有下一个元素则返回true；否则就返回false</returns>
        bool hasNext();

        /// <summary>
        /// 取出后面的几个元素
        /// </summary>
        /// <param name="totalNum">需取出的记录条数</param>
        /// <returns></returns>
        List<object> Next(int totalNum);

        /// <summary>
        /// 判断是否有上一个元素（无论是否够一页的数据）因为最后哪怕只有一条数据也要算一页
        /// </summary>
        /// <returns>若有上一个元素则返回true；否则返回false</returns>
        bool hasPrevious();

        /// <summary>
        /// 取出前面的几个元素
        /// </summary>
        /// <param name="totalNum">需获取的记录条数</param>
        /// <returns></returns>
        List<object> Previous(int totalNum);


    }//Interface_end
}
