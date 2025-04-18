using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.CodeGenerationV1
{
    /// <summary>
    /// 生产逻辑层模块示意
    /// </summary>
    internal class Business
    {
        public void Generate()
        {
            ConfigModel configModel = ConfigManager.GetInstance().GetConfigData();
            if (configModel.NeedGenBusiness)
            {
                Console.WriteLine("正在生成逻辑层的代码文件并保存");
            }
        }

    }//Class_end
}
