using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.CodeGenerationV1
{
    internal class ConfigManager
    {
        private static ConfigManager configManager = null;
        private static ConfigModel configModel = null;

        public ConfigManager()
        {

        }

        public static ConfigManager GetInstance() 
        {
            if (configManager==null)
            {
                configManager = new ConfigManager();
                configModel = new ConfigModel();
                //读取配置文件，把值设置到ConfigModel中
            }
            return configManager;
        }

        //获取配置的数据
        public ConfigModel GetConfigData()
        {
            return configModel;
        }


    }//Class_end
}
