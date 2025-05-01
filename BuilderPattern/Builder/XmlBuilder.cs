using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuilderPattern.Builder
{
    /// <summary>
    /// 实现导出数据到XML的生成器对象
    /// </summary>
    internal class XmlBuilder : IExportBuilder
    {
        //定义用来组装数据的对象
        private StringBuilder sb = new StringBuilder();

        public void BuildHeader(ExportHeaderModel ehm)
        {
            sb.Append($"<?xml version='1.0' encoding='utf-8'?>\n");
            sb.Append("<Report>\n");
            sb.Append("  <Header>\n");
            sb.Append($"    <DepId>{ehm.DepId}</DepId>\n");
            sb.Append($"    <ExportDate>{ehm.ExportDate}</ExportDate>\n");
            sb.Append("  </Header>\n");
        }
        public void BuildBody(Dictionary<string, List<ExportDataModel>> dicDatas)
        {
            sb.Append("  <body>\n");
            foreach (var tableName in dicDatas.Keys)
            {
                //先拼接表名称
                sb.Append($"    <Datas TableName=\"{tableName}\">\n");
                //循环拼接具体数据
                foreach (ExportDataModel item in dicDatas[tableName])
                {
                    sb.Append("      <Data>\n");
                    sb.Append($"        <ProductId>{item.ProductId}</ProductId>\n");
                    sb.Append($"        <Price>{item.Price}</Price>\n");
                    sb.Append($"        <Amount>{item.Amount}</Amount>\n");
                    sb.Append("      </Data>\n");
                }
                sb.Append($"    </Datas>\n");
            }
            sb.Append("  </body>\n");
        }

        public void BuildFooter(ExportFooterModel efm)
        {
            sb.Append("  <Footer>\n");
            sb.Append($"    <ExportUser>{efm.ExportUser}</ExportUser>\n");
            sb.Append("  </Footer>\n");
            sb.Append("</Report>\n");
        }

        public string NeedSaveFileContent => sb.ToString();

    }//Class_end
}
