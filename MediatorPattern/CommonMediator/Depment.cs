using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.CommonMediator
{
    /// <summary>
    /// 部门类对象
    /// </summary>
    internal class Depment
    {
        //描述部门编号
        public string? DepmentId;
        //部门名称
        public string? DepmentName;

        /// <summary>
        /// 撤销部门
        /// </summary>
        /// <returns></returns>
        public bool DeleteDepment()
        {
            Console.WriteLine($"\n撤销部门,ID是【{this.DepmentId}】名称是【{this.DepmentName}】");
            //1、要先去除掉所有与部门相关的部门与人员关系（通过中介者）
            DepmentUserMediator depmentUserMediator = DepmentUserMediator.GetInstance();
            bool retult = depmentUserMediator.DeleteDepment(this.DepmentId);

            /*2、关系解绑完成后才能够清除该部门*/
            //注意：在实际的开发中，这些业务功能是会做到业务层；
            //且实际开发中对于已经使用的业务数据通常是不会删除的，而是会被作为历史数据保留

            return true;
        }


    }//Class_end
}
