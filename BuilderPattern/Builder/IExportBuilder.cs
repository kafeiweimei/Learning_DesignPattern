using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builder
{
    /// <summary>
    /// 导出流程接口，定义构建一个输出文件对象所需的各个部件操作
    /// </summary>
    internal interface IExportBuilder
    {
        /// <summary>
        /// 构建输出文件的Header部分
        /// </summary>
        /// <param name="ehm">文件头对象</param>
        void BuildHeader(ExportHeaderModel ehm);

        /// <summary>
        /// 构建输出文件的Body部分
        /// </summary>
        /// <param name="dicDatas">文件内容主体</param>
        void BuildBody(Dictionary<string,List<ExportDataModel>> dicDatas);

        /// <summary>
        /// 构建输出文件的Footer部分
        /// </summary>
        /// <param name="ehm">文件尾部对象</param>
        void BuildFooter(ExportFooterModel efm);

        /// <summary>
        /// 需保存的文件内容
        /// </summary>
        string NeedSaveFileContent { get; }

    }//Interface_end
}
