using FactoryMethodPattern.FactoryMethodDemo;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethodTest();
            //FactoryMethodDemoTest();
            ParameterFactoryMethodTest();

            Console.ReadLine();
        }

        private static void FactoryMethodTest()
        {
            Console.WriteLine("------工厂方法测试------");
            //创建需要使用的对象
            ExportOperate exportOperate = new ExportTxtFileOperate(); ;
            //调用导出方法
            exportOperate.Export("测试导出数据到文本文件");

            ExportOperate exportOperate2 =new ExportDBOperate();
            exportOperate2.Export("测试导出数据到数据库");
        }

        private static void FactoryMethodDemoTest()
        {
            //直接使用C操作类实例化了具体的报警消息操作对象类
            ICOperate cOperate = new AlarmMSGOpearte();
            //调用消息通知方法
            cOperate.MSGNotify("测试消息");
        }

        private static void ParameterFactoryMethodTest()
        {
            Console.WriteLine("------参数化工厂方法测试------");
            //创建需使用的对象
            ParameterExportOperate parameterExportOperate = new ParameterExportOperate();
            //调用出书数据的功能方法
            parameterExportOperate.Export(1,"测试数据内容");
            parameterExportOperate.Export(2, "测试数据内容");

            Console.WriteLine("\n--使用拓展的方法--");
            ParameterExportOperate extandExportOperate = new ExtandParameterExportOperate();
            extandExportOperate.Export(1, "测试内容1");
            extandExportOperate.Export(2, "测试内容2");
            extandExportOperate.Export(3,"测试内容3");
        }


    }//Class_end
}
