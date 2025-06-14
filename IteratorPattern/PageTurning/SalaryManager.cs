using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.PageTurning
{
    /// <summary>
    /// 被客户方收购公司的工资管理类
    /// </summary>
    internal class SalaryManager
    {
        //用数组管理
        private PayModel[] payModels=new PayModel[5];

        /// <summary>
        /// 获取工资列表
        /// </summary>
        /// <returns></returns>
        public PayModel[] GetPayModels()
        {
            return payModels;
        }

        /// <summary>
        /// 计算工资(正常来说应该有很多参数，我们只是演示就从简了)
        /// </summary>
        public void CaculatePay()
        {
            //计算工资，把工资信息填充到工资条中
            //为了测试，需要一些测试数据
            PayModel payModel1 = new PayModel();
            payModel1.UserName = "赵六";
            payModel1.Pay = 9000;
            payModels[0]=payModel1;

            PayModel payModel2 = new PayModel();
            payModel2.UserName = "孙七";
            payModel2.Pay = 13000;
            payModels[1] = payModel2;

            PayModel payModel3 = new PayModel();
            payModel3.UserName = "李八";
            payModel3.Pay = 15000;
            payModels[2] = payModel3;
            
            PayModel payModel4 = new PayModel();
            payModel4.UserName = "孙七二";
            payModel4.Pay = 9000;
            payModels[3] = payModel4;

            PayModel payModel5 = new PayModel();
            payModel5.UserName = "李七二";
            payModel5.Pay = 9000;
            payModels[4] = payModel5;

        }

        public IAggregateIterator CreateIterator()
        {
            return new ArrayIteratorImpl(this); 
        }

    }//Class_end
}
