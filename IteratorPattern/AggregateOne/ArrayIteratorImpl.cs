
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.AggregateOne
{
    /// <summary>
    /// 用来实现访问数组的迭代接口
    /// </summary>
    internal class ArrayIteratorImpl : Itetator
    {
        //用来存放被迭代的聚合对象
        private SalaryManager salaryManager = null;
        //用来记录当前迭代的位置索引-1表示刚开始时，迭代器指向聚合对象第一个对象之前
        private int index = -1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salaryManager">被客户方收购公司的工资管理类</param>
        public ArrayIteratorImpl(SalaryManager salaryManager)
        {
            this.salaryManager = salaryManager;
        }

        public object CurrentItem()
        {
            return this.salaryManager.Get(index);
        }

        public void First()
        {
            index = 0;
        }

        public bool IsDone()
        {
            if (index==this.salaryManager.Size())
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (index<salaryManager.Size())
            {
                index=index+1;
            }
        }
    }//Class_end
}
