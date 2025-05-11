using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.CommonMediator
{
    /// <summary>
    /// 用户对象
    /// </summary>
    internal class User
    {
        //人员编号
        public string? UserId;
        //人员名称
        public string? UserName;

        //人员离职
        public bool Resign()
        {
            Console.WriteLine($"\n人员离职,ID是【{this.UserId}】名称是【{this.UserName}】");
            //1、需要先去除掉所有与这个人员相关的部门和人员关系(通过中介者)
            DepmentUserMediator depmentUserMediator = DepmentUserMediator.GetInstance();
            depmentUserMediator.DeleteUser(this.UserId);

            /*2、关系解绑完成后才能够真正清除掉这个人员*/
            //注意：在实际开发中，人员离职是不会真正的删除人员记录的；
            //通常只是把人员记录的状态或删除标记设置为已删除；
            //只是不再参加新的业务，但是已经发生的业务记录内容是不会被清除掉的

            return true;
        }

    }//Class_end
}
