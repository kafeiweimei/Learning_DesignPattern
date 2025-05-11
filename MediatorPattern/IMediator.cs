using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    internal interface IMediator
    {
        /// <summary>
        /// 同事对象在自身改变的时候来通知中介者方法，让中介者去负责相应的与其他同事对象的交互 
        /// </summary>
        /// <param name="colleague">同事类对象自己，让中介者对象通过同事类对象实例获取同事对象的状态</param>
        void Changed(Colleague colleague);


    }//Interface_end
}
