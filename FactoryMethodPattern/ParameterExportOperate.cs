using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    internal class ParameterExportOperate
    {
        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="type">对象导出的类型</param>
        /// <param name="data">需要保存的数据</param>
        /// <returns>true：表示导出成功</returns>
        public bool Export(int type,string data)
        {
            IExportFile exportFile = FactoryMethod(type);
            return exportFile.Export(data);
        }

        /// <summary>
        /// 工厂方法，创建导出内容的接口对象
        /// </summary>
        /// <param name="type">对象导出类型</param>
        /// <returns></returns>
        protected virtual IExportFile FactoryMethod(int type)
        {
            IExportFile exportFile = null;
            switch (type)
            {
                case 1:
                    exportFile = new ExportTxtFile();
                    break;
                case 2:
                    exportFile = new ExportDB();
                    break;
                default:
                    break;
            }
            return exportFile;

        }

    }//Class_end
}
