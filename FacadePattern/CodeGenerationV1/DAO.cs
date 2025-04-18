using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.CodeGenerationV1
{
    /// <summary>
    /// 生成数据层模块示意
    /// </summary>
    internal class DAO
    {
        public void Generate()
        {
            ConfigModel configModel=ConfigManager.GetInstance().GetConfigData();
            if (configModel.NeedGenDAO)
            {
                Console.WriteLine("正在生成数据层的代码文件并保存");
            }
        }

    }//Class_end
}
