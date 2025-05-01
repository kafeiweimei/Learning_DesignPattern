using BuilderPattern.Builder;
using BuilderPattern.BuilderComplexObj;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ExportFormatterTest();

            //ExportBuilderTest();

            //InsuranceContractBuilderTest();
            //InsuranceContractBuilderTest2();

            InsuranceContractBuilderTest3();

            Console.ReadLine();
        }


        /// <summary>
        /// 导出格式测试
        /// </summary>
        private static void ExportFormatterTest()
        {
            Console.WriteLine($"------导出格式测试------\n");

            ExportHeaderModel ehm=new ExportHeaderModel();
            ehm.DepId = "XXX一分公司";
            ehm.ExportDate=DateTime.Now.ToLongDateString();

            Dictionary<string, List<ExportDataModel>> dicDatas = new Dictionary<string, List<ExportDataModel>>();
            List<ExportDataModel> listDatas = new List<ExportDataModel>();

            ExportDataModel edm1 =new ExportDataModel();
            edm1.ProductId = "产品01";
            edm1.Price = 100;
            edm1.Amount = 101;

            ExportDataModel edm2 = new ExportDataModel();
            edm2.ProductId = "产品02";
            edm2.Price = 200;
            edm2.Amount = 202;

            listDatas.Add(edm1);
            listDatas.Add(edm2);
            dicDatas.Add("XXX记录表",listDatas);

            ExportFooterModel efm =new ExportFooterModel();
            efm.ExportUser = "Coffee";

            //测试导出为文本文件
            ExportToTxt toTxt =new ExportToTxt();
            toTxt.Export(ehm,dicDatas,efm);

            //导出为XML文件
            ExportToXml toXml =new ExportToXml();
            toXml.Export(ehm,dicDatas,efm);
        }

        /// <summary>
        /// 导出生成器测试
        /// </summary>
        private static void ExportBuilderTest()
        {
            Console.WriteLine($"------导出生成器测试------\n");

            ExportHeaderModel ehm = new ExportHeaderModel();
            ehm.DepId = "XXX一分公司";
            ehm.ExportDate = DateTime.Now.ToLongDateString();

            Dictionary<string, List<ExportDataModel>> dicDatas = new Dictionary<string, List<ExportDataModel>>();
            List<ExportDataModel> listDatas = new List<ExportDataModel>();

            ExportDataModel edm1 = new ExportDataModel();
            edm1.ProductId = "产品01";
            edm1.Price = 100;
            edm1.Amount = 101;

            ExportDataModel edm2 = new ExportDataModel();
            edm2.ProductId = "产品02";
            edm2.Price = 200;
            edm2.Amount = 202;

            listDatas.Add(edm1);
            listDatas.Add(edm2);
            dicDatas.Add("XXX记录表", listDatas);

            ExportFooterModel efm = new ExportFooterModel();
            efm.ExportUser = "Coffee";

            //测试导出为文本文件
            ExportDirector exportDirector1 = new ExportDirector(new TxtBuilder());
            exportDirector1.BuildExportFlow(ehm,dicDatas,efm,"指导者构建导出流程保存TXT文件.txt");


            //导出为XML文件
            ExportDirector exportDirector2 = new ExportDirector(new XmlBuilder());
            exportDirector2.BuildExportFlow(ehm, dicDatas, efm, "指导者构建导出流程保存XML文件.xml");
        }

        //保险合同构建器对象测试
        private static void InsuranceContractBuilderTest()
        {
            //创建构建器对象
            InsuranceContractBuilder builder = new InsuranceContractBuilder("CK250429001",
               Convert.ToDateTime(DateTime.Now.ToLongDateString()), Convert.ToDateTime(DateTime.Now.ToLongDateString()));

            //设置需要的数据，然后构建合同对象
            InsuranceContract insuranceContract = builder
                .WithPersonName("张三")
                .WithCompanyName("XXX科技有限公司")
                .WithOtherData("测试内容")
                .Build();

            //打印合同信息
            insuranceContract.PrintInfo();
        }

        //保险合同构建器对象测试
        private static void InsuranceContractBuilderTest2()
        {
            //创建构建器对象
            InsuranceContractBuilder builder = new InsuranceContractBuilder("CK250429001",
               Convert.ToDateTime(DateTime.Now.ToLongDateString()), Convert.ToDateTime(DateTime.Now.AddDays(1).ToLongDateString()));

            //设置需要的数据，然后构建合同对象
            InsuranceContract insuranceContract = builder
                .WithPersonName("张三")
                //.WithCompanyName("XXX科技有限公司")
                .WithOtherData("测试内容")
                .Build();

            //打印合同信息
            insuranceContract.PrintInfo();
        }

        //保险合同构建器对象测试
        private static void InsuranceContractBuilderTest3()
        {

            //创建构建器对象
            InsuranceContract2.Builder insuranceContract2Bulider = new InsuranceContract2.Builder("CK250429001",
                Convert.ToDateTime(DateTime.Now.ToLongDateString()), Convert.ToDateTime(DateTime.Now.AddDays(1).ToLongDateString()));

            //设置需要的数据，然后构建合同对象
            InsuranceContract2 insuranceContract = insuranceContract2Bulider
                .WithPersonName("张三")
                //.WithCompanyName("XXX科技有限公司")
                .WithOtherData("测试内容")
                .Build();

            //打印合同信息
            insuranceContract.PrintInfo();
        }

    }//Class_end
}
