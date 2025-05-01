using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 导出数据到XML文件
    /// </summary>
    internal class ExportToXml
    {
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="ehm">文件头内容</param>
        /// <param name="dicDatas">数据内容</param>
        /// <param name="efm">文件尾内容</param>
        public void Export(ExportHeaderModel ehm, Dictionary<string, List<ExportDataModel>> dicDatas,
            ExportFooterModel efm)
        {
            StringBuilder sb = new StringBuilder();

            //1、先拼接文件头内容
            sb.Append($"<?xml version='1.0' encoding='utf-8'?>\n");
            sb.Append("<Report>\n");
            sb.Append("  <Header>\n");
            sb.Append($"    <DepId>{ehm.DepId}</DepId>\n");
            sb.Append($"    <ExportDate>{ehm.ExportDate}</ExportDate>\n");
            sb.Append("  </Header>\n");

            //2、拼接文件内容
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

            //3、拼接文件尾内容
            sb.Append("  <Footer>\n");
            sb.Append($"    <ExportUser>{efm.ExportUser}</ExportUser>\n");
            sb.Append("  </Footer>\n");
            sb.Append("</Report>\n");

            //4、保存文件
            string fileName = "XML内容.xml";
            bool result = SaveFile.Save(fileName,sb.ToString());

            Console.WriteLine($"保存内容到【{fileName}】结果是：{result}，具体内容如下：");
            Console.WriteLine($"{sb}\n\n");
        }


    }//Class_end
}
