using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RandomPageTurning
{
    /// <summary>
    /// 定义随机翻页访问聚合元素的迭代接口
    /// </summary>
    internal interface IAggregationIterator<T> where T : class
    {
        /// <summary>
        /// 判断是否还有下一个元素，无所谓是否够一页的数据，因为最后哪怕只有一条数据也是算作一页
        /// </summary>
        /// <returns>如果有下一个元素则返回true,否则返回false</returns>
        public bool HasNext();

        /// <summary>
        /// 判断是否还有上一个元素，无所谓是否够一页的数据，因为最后哪怕只有一条数据也是算作一页
        /// </summary>
        /// <returns>如果有上一个元素则返回true,否则返回false</returns>
        public bool HasPrevious();

        /// <summary>
        /// 取指定页的数据
        /// </summary>
        /// <param name="pageNum">需获取数据的页码</param>
        /// <param name="pageShow">每页展示的数据条数</param>
        /// <returns></returns>
        public T[] GetPageDatas(int pageNum,int pageShow);

    }//Interface_end
}
