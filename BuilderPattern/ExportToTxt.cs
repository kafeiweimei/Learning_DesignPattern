using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 导出数据到文本文件
    /// </summary>
    internal class ExportToTxt
    {
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="ehm">文件头内容</param>
        /// <param name="dicDatas">数据内容</param>
        /// <param name="efm">文件尾内容</param>
        public void Export(ExportHeaderModel ehm,Dictionary<string,List<ExportDataModel>> dicDatas,
            ExportFooterModel efm)
        {
            StringBuilder sb=new StringBuilder();

            //1、先来拼接文件头的内容
            sb.Append($"{ehm.DepId},{ehm.ExportDate}\n");

            //2、拼接文件体内容
            foreach (var tableName in dicDatas.Keys)
            {
                //先拼接表名称
                sb.Append($"{tableName}\n");
                //然后在循环拼接具体数据
                if (dicDatas.ContainsKey(tableName))
                {
                    foreach (ExportDataModel item in dicDatas[tableName])
                    {
                        sb.AppendJoin(',',item.ProductId,item.Price,item.Amount);
                        sb.Append("\n");
                    }
                }
            }

            //3、构建文件尾部内容
            sb.Append(efm.ExportUser);

            //4、保存文件
            string fileName = "文本内容.txt";
            bool result = SaveFile.Save(fileName,sb.ToString());

            Console.WriteLine($"保存内容到【{fileName}】结果是：{result}，具体内容如下：");
            Console.WriteLine($"{sb}\n\n");
            
        }

    }//Class_end
}
