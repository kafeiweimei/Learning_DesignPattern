using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AbstractFactory
{
    internal class InstallationEngineer2
    {
        //定义获取组装电脑所需的CPU
        private ICPU cpu;

        //定义获取组装电脑所需的主板
        private IMainboard mainboard;

        /// <summary>
        /// 装机工程师组装电脑
        /// </summary>
        /// <param name="installationSchema">装机方案</param>
        public void InstallComputer(IInstallationSchema installationSchema)
        {
            //1、准备好装机所需的配件
            PrepareHardwares(installationSchema);
            //2、组装电脑

            //3、测试电脑

            //4、交付客户
        }

        //准备装机所需的配件
        private void PrepareHardwares(IInstallationSchema installationSchema)
        {
            //这里需要CPU与主板的具体对象，可工程师并不知道如何创建，该怎么办？

            //可以使用抽象工厂来获取相应的对象
            this.cpu=installationSchema.CreateCPU();
            this.mainboard=installationSchema.CreateMainboard();

            //测试配件是否正常
            this.mainboard.InstallCPU();
            this.cpu.Calculate();
        }

    }//Class_end
}
