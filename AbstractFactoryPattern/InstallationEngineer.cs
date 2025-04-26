/***
*	Title："设计模式" 项目
*		主题：装机工程师
*	Description：
*	    功能：客户告诉装机工程师自己选择的配件，让装机工程师组装；这样存在两个问题：
*           1、对于装机工程师，只知道CPU和主板的接口，但是不知道具体的实现
*           2、CPU与主板是需要相互匹配接口的，否则无法安装使用；但目前并没有维护这种关系，是客户随意选择的
*Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 装机工程师
    /// </summary>
    internal class InstallationEngineer
    {
        //定义装机需要的CPU
        private ICPU cpu = null;
        //定义装机需要的主板
        private IMainboard mainboard = null;

        /// <summary>
        /// 组装电脑
        /// </summary>
        /// <param name="cpuType">cpu类型</param>
        /// <param name="mainboardType">主板类型</param>
        public void InstallComputer(int cpuType,int mainboardType)
        {
            //1、准备装机所需的配件
            PrepareHardwares(cpuType,mainboardType);
            //2、组装电脑

            //3、测试组装电脑的各个功能是否正常

            //4、交付客户
        }

        //准备装机的配件
        private void PrepareHardwares(int cpuType, int mainboardType)
        {
            //直接找工厂获取对应的CPU与主板
            this.cpu = CPUFactory.CreateCPU(cpuType);
            this.mainboard=MainboardFactory.CreateMainboard(mainboardType);

            //测试配件是否可用
            this.mainboard.InstallCPU();
            this.cpu.Calculate();
        }


    }//Class_end
}
