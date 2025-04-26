using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ExtandAbstractFactory
{
    internal class InstallationEngineer3
    {
        //定义组装电脑所需的CPU对象
        private ICPU cpu = null;
        //定义组装电脑所需的主板对象
        private IMainboard mainboard = null;

        public void InstallComputer(IExtandAbstractFacoty schema)
        {
            //1、准备好装机所需的配件
            PrepareHardwares(schema);

            //2、组装电脑

            //3、测试电脑

            //4、交付客户
        }

        //准备装机所需的配件
        private void PrepareHardwares(IExtandAbstractFacoty schema)
        {
            //这里使用方案获取需要的配件对象
            this.cpu = (ICPU)schema.CreateProduct(1);
            this.mainboard=(IMainboard)schema.CreateProduct(2);

            //测试配件是否正常
            this.mainboard.InstallCPU();
            this.cpu.Calculate();
        }

    }//Class_end
}
