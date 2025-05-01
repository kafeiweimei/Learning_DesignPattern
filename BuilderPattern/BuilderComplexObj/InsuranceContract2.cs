/***
*	Title："设计模式" 项目
*		主题：生成器模式
*	Description：
*	    功能：将构建器与被构建对象合并在一起
*	    说明：在实际开发中，如果构建器对象和被构建的对象是分开的话，可能会导致同包内的对象不使用构建器来构建对象,
*	          这会导致错误；并且构建器就是为了创建被构建的对象，完全可以不用单独创建一个类【我们可以直接在被构建对象
*	          内使用内联类，这样一体化更加简单与直观，不容易出错，也更容易理解】
*	          
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.BuilderComplexObj
{
    internal class InsuranceContract2
    {
        //保险合同编号
        private string? contractId;
        /*被保险人员的名称，同一份保险合同，要么与人员签订，要么与公司签订
        * 也就是说：【被保险人员】和【被保险公司】这两个属性，不能同时有值
        */
        private string? personName;

        //被保险公司名称
        private string? companyName;

        //保险开始生效日期
        private DateTime beginDate;

        //保险失效日期,且一定要大于保险开始生效日期
        private DateTime endDate;

        //其他数据
        private string? otherData;

        private InsuranceContract2()
        {
                
        }

        /// <summary>
        /// 私有构造方法
        /// </summary>
        /// <param name="builder"></param>
        private InsuranceContract2(Builder builder)
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
            Console.WriteLine($"合同编号：{contractId} 被保人员名称：{personName} 被保公司名称：{companyName}" +
                $"合同生效日期：{beginDate} 合同失效日期：{endDate} 其他数据：{otherData}");
        }



        //保险合同构建器（用作保险合同的类级内部类）
        public class Builder
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
            public Builder(string contractId, DateTime beginDate, DateTime endDate)
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
            public Builder WithPersonName(string personName)
            {
                this.PersonName = personName;
                return this;
            }

            /// <summary>
            /// 选填数据，被保险公司的名称
            /// </summary>
            /// <param name="companyName">被保险公司名称</param>
            /// <returns></returns>
            public Builder WithCompanyName(string companyName)
            {
                this.CompanyName = companyName;
                return this;
            }

            /// <summary>
            /// 选填数据，其他数据
            /// </summary>
            /// <param name="otherData">其他数据</param>
            /// <returns></returns>
            public Builder WithOtherData(string otherData)
            {
                this.OtherData = otherData;
                return this;
            }

            //构建真正的对象并返回
            public InsuranceContract2 Build()
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
                if (!string.IsNullOrEmpty(PersonName) && !string.IsNullOrEmpty(CompanyName))
                {
                    throw new Exception("【被保险人】与【被保险公司】只能有一个");
                }

                if (BeginDate < DateTime.Now.Date || EndDate < DateTime.Now.Date)
                {
                    throw new Exception("保险生效日期与失效日期不能小于当前日期");
                }

                if (BeginDate >= EndDate)
                {
                    throw new Exception("合同的保险生效日期必须小于失效日期，请检查后重试！！！");
                }


                return new InsuranceContract2(this);
            }
        }


    }//Class_end
}
