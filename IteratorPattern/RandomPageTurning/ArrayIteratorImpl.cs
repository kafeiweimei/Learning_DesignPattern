using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.RandomPageTurning
{
    internal class ArrayIteratorImpl : IAggregationIterator<PayModel>
    {
        //用来存放被迭代的数组
        private PayModel[] payModels = null;
        //用来记录当前迭代到的索引位置
        private int index = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salaryManager">薪资管理对象</param>
        public ArrayIteratorImpl(SalaryManager salaryManager)
        {
            this.payModels = salaryManager.GetPayModels();
        }

        public PayModel[] GetPageDatas(int pageNum, int pageShow)
        {
            PayModel[] payModelArray = new PayModel[pageShow];

            //需要先计算需获取的数据开始条数和结束条数
            int start = (pageNum - 1) * pageShow;
            int end = start + pageShow - 1;

            //控制start的边界，最小是0
            if (start<0)
            {
                start = 0;
            }

            //控制end的边界，最大是数组的最大索引
            if (end>this.payModels.Length-1)
            {
                end = this.payModels.Length - 1;
            }

            //每次取值都是从头开始循环，所以设置index=0
            index = 0;
            while (HasNext() && start<=end)
            {
                payModelArray[index] = payModels[start];
                start++;
                index++;
            }
            return payModelArray;
        }

        public bool HasNext()
        {
            if (payModels!=null && index<payModels.Length-1)
            {
                return true;
            }
            return false;
        }

        public bool HasPrevious()
        {
            if (payModels!=null && index>0)
            {
                return true;
            }
            return false;
        }

    }//Class_end
}
