using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 配置文件类（不使用模式）
    /// </summary>
    internal class AppConfig
    {
        private string appConfigPathAndName = $"{Directory.GetCurrentDirectory()}\\AppConfig.txt";
        //存放配置文件中参数A的值
        private string parameterA;
        //存放配置文件中参数B的值
        private string parameterB;

        public AppConfig()
        {
            CreateConfig();
            ReadConfig();
        }

        public string AppConfigPathAndName { get => appConfigPathAndName; }
        public string ParameterA { get => parameterA; }
        public string ParameterB { get => parameterB; }


        /// <summary>
        /// 读取配置文件，将配置文件中的内容读取出来设置到属性上
        /// </summary>
        private void ReadConfig()
        {
            List<string> configList= new List<string>();
            using (FileStream fs=new FileStream(appConfigPathAndName,FileMode.Open))
            {
                using (StreamReader sr=new StreamReader(fs))
                {
                    string strLine=sr.ReadLine();
                    while (!string.IsNullOrEmpty(strLine))
                    {
                        configList.Add(strLine);
                        strLine = sr.ReadLine();
                    }
                }
                if (configList!=null && configList.Count==2)
                {
                    parameterA = configList[0];
                    parameterB = configList[1];
                }

            }

        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        private void CreateConfig()
        {
            if (File.Exists(appConfigPathAndName)) return;

            using (FileStream fs = new FileStream(appConfigPathAndName, FileMode.Create))
            {
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    sw.WriteLine("参数A");
                    sw.WriteLine("参数B");
                    sw.AutoFlush = true;
                }
            }
        }

    }//Class_end
}
