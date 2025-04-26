using AbstractFactoryPattern.AbstractFactory;
using AbstractFactoryPattern.DAO;
using AbstractFactoryPattern.ExtandAbstractFactory;

namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InstallationEngineerTest();

            //InstallationEngineer2Test();

            //InstallationEngineer3Test();

            InstallationEngineer4Test();

            //DAOFactoryTest();

            Console.ReadLine();
        }

        /// <summary>
        /// 测试装机工程师组装的电脑
        /// </summary>
        private static void InstallationEngineerTest()
        {
            Console.WriteLine($"\n测试装机工程师组装电脑——未使用抽象工厂模式");
            //创建装机工程师对象
            InstallationEngineer installationEngineer=new InstallationEngineer();
            //客户告诉装机工程师自己选择的配件，让装机工程师组装
            installationEngineer.InstallComputer(1,1);
        }

        /// <summary>
        /// 测试装机工程师2组装的电脑
        /// </summary>
        private static void InstallationEngineer2Test()
        {
            Console.WriteLine($"\n测试装机工程师组装电脑——使用抽象工厂模式");
            //创建装机工程师对象
            InstallationEngineer2 installationEngineer2 = new InstallationEngineer2();

            Console.WriteLine($"\n测试装机工程师组装电脑——使用方案一");
            //获取客户选择的装机方案一
            IInstallationSchema installationSchema = new InstallationSchema1();
            //客户告诉装机工程师自己选择的配件，让装机工程师组装
            installationEngineer2.InstallComputer(installationSchema);

            Console.WriteLine($"\n测试装机工程师组装电脑——使用方案二");
            //获取客户选择的装机方案一
            IInstallationSchema installationSchema2 = new InstallationSchema2();
            //客户告诉装机工程师自己选择的配件，让装机工程师组装
            installationEngineer2.InstallComputer(installationSchema2);

        }

        /// <summary>
        /// 测试装机工程师3组装的电脑
        /// </summary>
        private static void InstallationEngineer3Test()
        {
            Console.WriteLine($"\n测试装机工程师组装电脑——使用拓展抽象工厂模式");
            //创建装机工程师对象
            InstallationEngineer3 installationEngineer3 = new InstallationEngineer3();

            Console.WriteLine($"\n使用客户选择的装机方案一【只有CPU与主板】");
            //获取客户选择的装机方案2
            IExtandAbstractFacoty installationSchema1 = new Schema1();
            //客户告诉装机工程师4自己选择的配件，让装机工程师组装(若此时没有对信息的memory判断就会报错)
            installationEngineer3.InstallComputer(installationSchema1);

            Console.WriteLine($"\n使用客户选择的装机方案二【只有CPU和主板");
            //获取客户选择的装机方案3
            IExtandAbstractFacoty installationSchema2 = new Schema2();
            //客户告诉装机工程师4自己选择的配件，让装机工程师组装
            installationEngineer3.InstallComputer(installationSchema2);

        }
        
        /// <summary>
        /// 测试装机工程师4组装的电脑
        /// </summary>
        private static void InstallationEngineer4Test()
        {
            Console.WriteLine($"\n测试装机工程师组装电脑——使用拓展抽象工厂模式");
            //创建装机工程师对象
            InstallationEngineer4 installationEngineer4 = new InstallationEngineer4();

            Console.WriteLine($"\n使用客户选择的装机方案二【只有CPU与主板】");
            //获取客户选择的装机方案2
            IExtandAbstractFacoty installationSchema2 = new Schema2();
            //客户告诉装机工程师4自己选择的配件，让装机工程师组装(若此时没有对信息的memory判断就会报错)
            installationEngineer4.InstallComputer(installationSchema2);

            Console.WriteLine($"\n使用客户选择的装机方案三【有CPU、主板和内存条】");
            //获取客户选择的装机方案3
            IExtandAbstractFacoty installationSchema3 = new Schema3();
            //客户告诉装机工程师4自己选择的配件，让装机工程师组装
            installationEngineer4.InstallComputer(installationSchema3);

        }

        /// <summary>
        /// 测试DAO抽象工厂
        /// </summary>
        private static void DAOFactoryTest()
        {
            Console.WriteLine($"\n------现在使用关系数据库来对主、子订单的数据进行存储------");
            //创建DAO抽象工厂
            DAOFactory df = new RdbDAOFactory();

            //通过抽象工厂来获取需要的具体DAO对象
            IOrderMainDAO orderMainDAO = df.CreateOrderMainDAO();
            IOrderDetailDAO orderDetailDAO = df.CreateOrderDetailDAO();

            //调用DAO对象的方法来完成存储功能
            orderMainDAO.SaveOrderMain();
            orderDetailDAO.SaveOrderDetail();

            Console.WriteLine($"\n\n------现在使用XML来对主、子订单的数据进行存储------");
            DAOFactory xmlDF= new XmlDAOFactory();

            //获取对应的主、子订单具体对象
            IOrderMainDAO orderMainDAO1 = xmlDF.CreateOrderMainDAO();
            IOrderDetailDAO orderDetailDAO1= xmlDF.CreateOrderDetailDAO();

            //保存主、子订单
            orderMainDAO1.SaveOrderMain();
            orderDetailDAO1.SaveOrderDetail();
        }

    }//Class_end
}
