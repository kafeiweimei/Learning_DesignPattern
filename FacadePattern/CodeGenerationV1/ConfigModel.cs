using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.CodeGenerationV1
{
    /// <summary>
    /// 配置模型示意
    /// </summary>
    internal class ConfigModel
    {
        //是否需要生产表现层
        private bool needGenPresentation = true;

        //是否需要生成逻辑层
        private bool needGenBusiness=true;

        //是否需要生成数据层（DAO表示Data Access Object）
        private bool needGenDAO = true;

        public bool NeedGenPresentation { get => needGenPresentation; set => needGenPresentation = value; }
        public bool NeedGenBusiness { get => needGenBusiness; set => needGenBusiness = value; }
        public bool NeedGenDAO { get => needGenDAO; set => needGenDAO = value; }

    }//Class_end
}
