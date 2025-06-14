using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    /// <summary>
    /// 客户方已有的工资管理对象
    /// </summary>
    internal class PayManager
    {
        //聚合对象
        private List<PayModel> payModels = new List<PayModel>();

        /// <summary>
        /// 获取工资列表
        /// </summary>
        /// <returns></returns>
        public List<PayModel> GetPayModels()
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
            payModel1.UserName = "张三";
            payModel1.Pay = 9600;
            payModels.Add(payModel1);

            PayModel payModel2 = new PayModel();
            payModel2.UserName = "李四";
            payModel2.Pay = 10000;
            payModels.Add(payModel2);

            PayModel payModel3 = new PayModel();
            payModel3.UserName = "王五";
            payModel3.Pay = 12000;
            payModels.Add(payModel3);

        }


    }//Class_end
}
