using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.AggregateOne
{
    /// <summary>
    /// 用来实现访问Collection集合的迭代接口，为了外部统一访问
    /// </summary>
    internal class CollectionIteratorImplFilter : Itetator
    {
        //用来存放被迭代的列表
        private List<PayModel> payModels=null;
        //用来记录当前迭代的位置索引
        private int index=0;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="payManager">客户方已有的工资管理对象</param>
        public CollectionIteratorImplFilter(PayManager payManager)
        {
            /*迭代器过滤示意*/
            //可以先在这里对聚合对象的数据进行过滤（比如：工资必须在10000以下）
            List<PayModel> tmpPayModels = new List<PayModel>();
            foreach (var item in payManager.GetPayModels())
            {
                if (item.Pay < 10000)
                {
                    tmpPayModels.Add(item);
                }
            }
            //然后把符合要求的数据存放到迭代的列表
            this.payModels= tmpPayModels;
            foreach (var item in tmpPayModels)
            {
                payModels.Add(item);
            }

        }

        public object CurrentItem()
        {
            return this.payModels[index];
        }

        public void First()
        {
            index = 0;
        }

        public bool IsDone()
        {
            if (index == this.payModels.Count)
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (index<this.payModels.Count)
            {
                index = index + 1;
            }
        }

    }//Class_end
}
