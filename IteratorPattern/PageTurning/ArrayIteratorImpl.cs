using IteratorPattern.AggregateOne;
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
    /// 用来实现访问数组的迭代接口
    /// </summary>
    internal class ArrayIteratorImpl : IAggregateIterator
    {
        //用来存放被迭代的数组
        private PayModel[] payModels = null;
        //用来记录当前迭代的位置索引
        private int index = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salaryManager">被客户方收购公司的工资管理类</param>
        public ArrayIteratorImpl(SalaryManager salaryManager)
        {
            this.payModels = salaryManager.GetPayModels();
        }

        public bool hasNext()
        {
            if (payModels!=null && index<=(payModels.Length-1))
            {
                return true;
            }
            return false;
        }

        public bool hasPrevious()
        {
            if (payModels!=null && index>0)
            {
                return true;
            }
            return false;
        }

        public List<object> Next(int totalNum)
        {
            List<object> list = new List<object>();
            int count = 0;

            while (hasNext() && count<totalNum)
            {
                list.Add(payModels[index]);
                //每取走一个值索引就添加1
                index++;
                count++;
            }

            return list;
        }

        public List<object> Previous(int totalNum)
        {
            List<object> list = new List<object>();
            int count = 0;

            //简单的实现就是把索引退回去totalNum个，然后在取值；但事实上这种实现是有可能多退回数据的，
            //比如：已经到了最后一页，而且最后一页的数据不够一页的数据，那么退回totalNum个索引就退多了
            //为了示例的简洁性，我们就不去处理了
            index = index - totalNum;
            while (hasPrevious() && count<totalNum)
            {
                list.Add(payModels[index]);
                index++;
                count++;
            }
            return list;
        }


    }//Class_end
}
