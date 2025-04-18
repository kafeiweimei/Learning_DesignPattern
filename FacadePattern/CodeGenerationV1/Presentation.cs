using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.CodeGenerationV1
{
    /// <summary>
    /// 生成表现层模块示意
    /// </summary>
    internal class Presentation
    {
        public void Generate()
        {
            //1、从配置管理里面获取相应的配置信息
            ConfigModel configModel=ConfigManager.GetInstance().GetConfigData();

            if (configModel.NeedGenPresentation)
            {
                //2、按照要求生成对应的表现层代码，并保存为文件
                Console.WriteLine("正在生成表现层代码文件并保存");
            }
        }


    }//Class_end
}
