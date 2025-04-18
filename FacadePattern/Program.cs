using FacadePattern.CodeGenerationV1;

namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("客户端要实现功能需自己管理不同的子模块与逻辑");
            ///***
            // * 目前没有配置文件，直接使用默认配置（生成三层模块）
            // * 也就是说客户端必须要对这三个模块都有所了解，才能够正确使用;
            // * 且客户端为了使用生成代码的功能，需要与生成代码子系统内部的多个模块进行交互
            // * 【对客户端来说，这是比较麻烦的，且如果其中的某个模块发生了变化，还可能引起客户端要随着变化】
            // * （如何实现？才能让子系统外部的客户端在使用子系统的时候简单的使用子系统内部模块功能，而又不用与子系统内部的多个模块交互？）
            // * ***/
            //new Presentation().Generate();
            //new Business().Generate();
            //new DAO().Generate();


            Console.WriteLine("外观模式");
            //客户端直接调用外观对象的方法（简单便捷）
            Facade.Generate();

            Console.ReadLine();


        }//Class_end
    }
}
