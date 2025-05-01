using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderComplexObj
{
    /// <summary>
    /// 保险合同对象
    /// </summary>
    internal class InsuranceContract
    {
        //保险合同编号
        private string contractId;

        /*被保险人员的名称，同一份保险合同，要么与人员签订，要么与公司签订
         * 也就是说：【被保险人员】和【被保险公司】这两个属性，不能同时有值
         */
        private string personName;

        //被保险公司名称
        private string companyName;

        //保险开始生效日期
        private DateTime beginDate;

        //保险失效日期,且一定要大于保险开始生效日期
        private DateTime endDate;

        //其他数据
        private string otherData;

        private InsuranceContract()
        {
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="builder">合同构建器</param>
        public InsuranceContract(InsuranceContractBuilder builder)
        {
            this.contractId = builder.ContractId;
            this.personName = builder.PersonName;
            this.companyName = builder.CompanyName;
            this.beginDate = builder.BeginDate;
            this.endDate = builder.EndDate;
            this.otherData = builder.OtherData;
        }

        /// <summary>
        /// 打印合同信息
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"合同编号：{contractId} 被保人员名称：{personName} 被保公司名称：{companyName} " +
                $"合同生效日期：{beginDate} 合同失效日期：{endDate} 其他数据：{otherData}");
        }

    }//Class_end
}
