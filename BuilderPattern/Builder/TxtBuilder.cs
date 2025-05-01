using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuilderPattern.Builder
{
    /// <summary>
    /// 实现导出数据到文件文件的生成器对象
    /// </summary>
    internal class TxtBuilder : IExportBuilder
    {
        //定义用来组装数据的对象
        private StringBuilder sb = new StringBuilder();


        public void BuildHeader(ExportHeaderModel ehm)
        {
            sb.Append($"{ehm.DepId},{ehm.ExportDate}\n");
        }

        public void BuildBody(Dictionary<string, List<ExportDataModel>> dicDatas)
        {
            if (dicDatas == null || dicDatas.Count <= 0) return;

            foreach (var tableName in dicDatas.Keys)
            {
                //先拼接表名称
                sb.Append($"{tableName}\n");
                //然后在循环拼接具体数据
                if (dicDatas.ContainsKey(tableName))
                {
                    foreach (ExportDataModel item in dicDatas[tableName])
                    {
                        sb.AppendJoin(',', item.ProductId, item.Price, item.Amount);
                        sb.Append("\n");
                    }
                }
            }
        }

        public void BuildFooter(ExportFooterModel efm)
        {
            sb.Append(efm.ExportUser);
        }

        public string NeedSaveFileContent =>sb.ToString();

    }//Class_end
}
