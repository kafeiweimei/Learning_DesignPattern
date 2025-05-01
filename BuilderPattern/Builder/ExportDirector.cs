/***
*	Title："设计模式" 项目
*		主题：生成器模式
*	Description：
*	    基础概念：生成器模式的本质是【分离整体构建算法和部件构造】
*	              生成器模式的重心还是在于【分离整体构建算法】和【部件构造】，而分步骤构建对象不过是整体构建算法的一个简单表现
*	              ，或者说是一个附带产物。
*	              
*	    生成器模式定义：将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示          
*	        
*	    生成器模式的功能：主要是用于构建复杂的产品，而且是细化的、分步骤的构建产品【更为重要的是：
*	                       这个构建过程是统一的，固定不变的；变化的部分都放到生成器部分了，只要配置
*	                       不同的生成器，那么同样的构建过程，就能构建出不同的产品来】
*	                       （简单地说：生成器模式在于分离构建算法和具体的构造实现；从而使得构建算法可以重用，
*	                       具体的构造实现可以很方便的扩展和切换，从而可以灵活的组合来构造出不同的产品对象）
*	    
*	    生成器模式的构成：
*	                    1、生成器接口（Builder），定义了如何构建各个部件（也就知道了每个部件功能如何实现，以及如何装配这些部件到产品中去）
*		                2、指导者（Director）,知道如何组合构建产品（也就是指导者负责整体的构建算法，而且是分步骤执行）
*		
*		生成器模式的使用：可以让客户端创建指导者，在指导者里面封装整体构建算法，让指导者去调用生成器接口来封装具体部件的构建功能
*		                
*		指导者和生成器的交互：真正指导者的实现，并不仅仅是简单的按照一定顺序调用生成器的方法来构建对象；
*		                      通常是会实现较为复杂的算法或者运算过程，在实际情况下可能会有以下情况：
*		                      《1》在运行指导者的时候，会按照整体构建算法的步骤进行运算（可能先运行几步运算，到某一步骤，
*		                            需要具体创建某个部件对象了，然后在调用生成器接口中创建相应部件的方法来创建具体的部件，
*		                            然后在把前面运算的数据传递个生成器接口，因为在生成器内部实现创建和组装部件的时候，可能需要这些数据）
*		                            
*		                      《2》生成器接口创建完具体部件对象后，会把创建好的部件对象返回给指导者，指导者继续后续的算法运算，
*		                            可能会用到已经创建好的对象
*		                        
*		                      《3》如此反复下去，知道整个构建算法运行完成，那么最终的产品对象也就创建完成了 
*		 
*		 关于被构建的产品接口：在使用生成器模式的时候，大多数情况下不知道最终构建出来的产品是什么样的，
*		                       所以在标准的生成器模式里面，一般是不需要对产品定义抽象接口的（因为最终构造的产品千差万别，
*		                       刚给这些产品定义公共接口几乎没有意义）
*		 
*		 生成器模式的优点：
*		                1、松散耦合（可用同一个构建算法构建出表现上完全不同的产品，实现产品构建和产品表现上的分离）
*		                2、可以很容易地改变产品的内部表示（在生成器模式中，由于Builder对象只是提供接口给Director使用
*		                    那么具体的部件创建和装配方式是被Builder接口隐藏了，Director并不知道这些具体的实现细节；
*		                    这样一来，要想改变产品的内部表示，只需要切换Builder的具体实现即可，不用管Director，因此变得很容易）
*		                3、更好的复用性（生成器模式实现构建算法和具体产品实现分离，使得构建产品算法可以复用；同理，具体产品的实现
*		                    也可以复用，同一个产品的实现，可以配合不同的构建算法使用）    
*		 
*		 何时选用生成器模式：
*		                1、如果创建对象的算法，应该独立于该对象的组成部分以及它们的装配方式时；
*		                2、如果同一个构建过程有着不同的表示时
*		 
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Builder
{
    /// <summary>
    /// 指导者，指导使用生成器的接口来构建输出的文件对象
    /// </summary>
    internal class ExportDirector
    {
        //持有当前需使用的生成器对象
        private IExportBuilder builder;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="exportBuilder">导出的生成器对象</param>
        public ExportDirector(IExportBuilder exportBuilder)
        {
            this.builder = exportBuilder;
        }

        /// <summary>
        /// 指导生成器构建流程并输出
        /// </summary>
        /// <param name="ehm">文件头对象</param>
        /// <param name="dicDatas">文件内容</param>
        /// <param name="efm">文件尾对象</param>
        /// <param name="fileName">导出的文件名称</param>
        public void BuildExportFlow(ExportHeaderModel ehm,Dictionary<string,List<ExportDataModel>> dicDatas,
            ExportFooterModel efm,string fileName)
        {
            //1、先构建Header
            builder.BuildHeader(ehm);

            //2、构建Body
            builder.BuildBody(dicDatas);

            //3、构建Footer
            builder.BuildFooter(efm);

            //4、保存文件
            bool result = SaveFile.Save(fileName,builder.NeedSaveFileContent);

            Console.WriteLine($"保存内容到【{fileName}】结果是：{result}，具体内容如下：");
            Console.WriteLine($"{builder.NeedSaveFileContent}\n\n");
        }


    }//Class_end
}
