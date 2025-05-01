using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderComplexObj
{
    /// <summary>
    /// 保险合同构建器
    /// </summary>
    internal class InsuranceContractBuilder
    {
       public string? ContractId { get; set; }
       public string? PersonName { get; set; }
       public string? CompanyName { get; set; }
       public DateTime BeginDate { get; set; }
       public DateTime EndDate { get; set; }
       public string? OtherData { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contractId">合同编号</param>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        public InsuranceContractBuilder(string contractId,DateTime beginDate,DateTime endDate)
        {
            this.ContractId = contractId;
            this.BeginDate = beginDate;
            this.EndDate = endDate;     
        }

        /// <summary>
        /// 选填数据，被保险人人员名称
        /// </summary>
        /// <param name="personName"></param>
        /// <returns></returns>
        public InsuranceContractBuilder WithPersonName(string personName)
        {
            this.PersonName = personName;
            return this;
        }

        /// <summary>
        /// 选填数据，被保险公司的名称
        /// </summary>
        /// <param name="companyName">被保险公司名称</param>
        /// <returns></returns>
        public InsuranceContractBuilder WithCompanyName(string companyName)
        {
            this.CompanyName = companyName;
            return this;
        }

        /// <summary>
        /// 选填数据，其他数据
        /// </summary>
        /// <param name="otherData">其他数据</param>
        /// <returns></returns>
        public InsuranceContractBuilder WithOtherData(string otherData)
        {
            this.OtherData = otherData;
            return this;
        }

        //构建真正的对象并返回
        public InsuranceContract Build()
        {
            /*在构建这里添加合同内容的校验逻辑*/
            if (string.IsNullOrEmpty(ContractId))
            {
                throw new Exception($"合同编号不能为空");
            }

            if (string.IsNullOrEmpty(PersonName) && string.IsNullOrEmpty(CompanyName))
            {
                throw new Exception("一份保险合同不能没有签订对象");
            }
            if (!string.IsNullOrEmpty(PersonName)&&!string.IsNullOrEmpty(CompanyName))
            {
                throw new Exception("【被保险人】与【被保险公司】只能有一个");
            }

            if (BeginDate<DateTime.Now.Date || EndDate<DateTime.Now.Date)
            {
                throw new Exception("保险生效日期与失效日期不能小于当前日期");
            }

            if (BeginDate>=EndDate)
            {
                throw new Exception("合同的保险生效日期必须小于失效日期，请检查后重试！！！");
            }
            

            return new InsuranceContract(this);
        }


    }//Class_end
}
