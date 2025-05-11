/***
*	Title："设计模式" 项目
*		主题：中介者模式
*	Description：
*	    基础概念：中介者模式的本质是【封装交互】
*	    
*	    定义：用一个中介者对象来封装一系列的对象交互；中介者使得各个对象不需要显式地相互引用，
*	          从而使其耦合松散，而且可以独立地改变它们之间的交互
*	          
*	    功能：【封装对象之间的交互】（如果一个对象的操作会引起其他相关对象的变化，
*	          或者某个操作需要引起其他对象的后续或者连带操作，而这个对象又不希望自己来处理这些关系，就可以找
*	          中介者，把所有麻烦扔给它，只在需要的时候通知中介者，其他的就让中介者去处理就可以了） 
*	          【把所有对象之间的交互都封装到中介者之中，还有一个好处就是可以集中的控制这些对象的交互关系，这样当有
*	          变化的时候，修改起来就很方便】
*	          
*	          1、需要中介者接口吗？（需要先弄清楚接口是做什么的【接口是用来实现封装隔离的】
*	                                而中介者接口就是用来封装中介者对象的，使得使用中介者对象的客户
*	                                跟具体的中介者实现对象分离开）【至于是否使用中介者接口还需要看是否需要有多个不同的
*	                                中介者实现；如果只有一个中介者实现，且没有扩展要求，就可以不用中介者接口；否则需要】
*	                                
*	          2、同事关系：在标准的中介者模式中【使用中介者对象来交互的那些对象称为同事类】，因为这些类都要继承相同的类；
*	          
*	          3、同事和中介者的关系：中介者模式中，当一个同事对象发生了改变，需要主动通知中介者，
*	             让中介者去处理与其他同事对象相关的交互（这就导致了同事对象和中介者对象之间必须有关系
*	             【先是同事对象要知道中介者是谁；反过来，中介者也需要知道相关的同事对象，二者是相关依赖的关系】）
*	          
*	          4、如何实现同事和中介者通信？《1》一种实现方式是在中介者接口中定义一个特殊的通知方法作为通用方法，让各个
*	                                        同事类来调用这个方法；
*	                                       《2》另一种实现方式是可以采用观察者模式，把中介者实现为观察者，而各个同事类
*	                                       实现为主题,这样同事类发生改变，就会通知中介者对象，中介者在接到通知后会与相对应的同事对象交互
*	    
*	    广义中介者：（我们仔细分析一下标准中介者模式会发现存在几个问题）
*	           1、是否有必要为同事对象定义一个公共的父类？【C#是单继承的，为了使用中介者模式就让所有同事对象继承一个父类不是很好，且该父类也没有什么特别公共的功能】
*	           2、同事类有必要持有中介者对象吗？【同事类是需要知道中介者对象，用做当它自己发生改变的时候能够通知中介者对象；但是否一定需要通过构造方法出入到同事类中这么强的依赖关系呢？（其他也可以使用简单的方式通知中介者如：将中介者作为单例直接调用）】
*	           3、是否需要中介者接口？【实际开发中，通常是不需要中介者接口的，且中介者对象也不需要创建多个实例；因为中介者主要就是用来封装和处理同事对象的关系，一般是没有状态需要维护的，可实现为单例】
*	           4、中介者对象是否需要持有所有的同事？【虽然中介者对象需要知道所有的同事类对象，这样才能够与它们进行交互；但是否需要这么强烈的依赖关系呢？且中介者对象在不同的关系维护上，可能会需要不同的同事对象实例，因此可以在中介者对象的方法传入、创建同事对象】
*	           5、中介者对象只是提供一个公共的方法来接受同事对象的通知吗？【实际开发中，通常会提供具体的业务通知方法，这样就不用判断是什么对象，什么业务了】
*	          基于上面的五种考虑，在实际的开发中，经常会简化中介者模式，从而使得开发变得简单（变化如下）：
*	            《1》去掉同事对象的父类（这样做可以让任意对象，只需要相互交互，就可成为同事）；
*	            《2》同事对象不再持有中介者，而是在需要的时候直接获取中介者对象并调用；
*	                 中介者也不再持有同事对象，而是在具体的处理方法通过传参去获取创建；
*	          经过以上两点的改造，变化的情况成为广义中介者       
*	    
*	   优点：
*	          1、松散耦合（通过把多个对象之间的交互封装到中介者对象里面，从而使得同事对象之间松散耦合，基本上做到互不依赖）
*	          2、集中控制交互（多个对象的交互，都在中介者对象里面集中管理；使得这些交互行为在发生变化的时候，只需要修改中介者就可以了；若是已经做好的系统，那就直接扩展中介者对象就行，而不用修改各个同事类）
*	          3、多对多变成一对多（没有使用中介者模式的时候，同事对象之间的关系是多对多的，引入中介者对象后，中介者对象和同事对象之间就是双向的一对多的关系了，更容易理解）
*	   缺点： 
*	          1、过度集中化；若同事对象的交互非常多，而且十分复杂，这些复杂性会全部集中到中介者的时候，会导致中介者变得十分复杂，且难以管理维护
*	      
*	   何时选用中介者？
*	          1、如果一组对象之间的通信方式比较复杂，导致相互依赖、结构混乱，可以采用中介者模式，把这些对象相互的交互管理起来，每个对象只与中介者对象交互
*	          2、如果一个对象引用很多的对象，并直接跟这些对象交互，导致难以复用该对象，可以采用中介者模式，把这个对象与其他对象的交互封装到中介者对象中，该对象只与中介者对象交互即可
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

namespace MediatorPattern
{
    /// <summary>
    /// 主板类（作为中介者实现中介者接口，且负责与各个同事类交互）
    /// </summary>
    internal class MainBoard : IMediator
    {
        //需要知道具体交互的同事类——光驱
        private CdDriver cDDriver = null;
        //需要知道交互的同事类——CPU
        private Cpu cpu = null;
        //需要知道交互的同事类——显卡
        private VideoCard videoCard = null;
        //需要知道交互的同事类——声卡
        private SoundCard soundCard = null;


        public void SetCDDriver(CdDriver cDDriver)
        {
            this.cDDriver = cDDriver;
        }

        public void SetCpu(Cpu cpu)
        {
            this.cpu = cpu;
        }

        public void SetVideoCard(VideoCard videoCard)
        {
            this.videoCard = videoCard;
        }

        public void SetSoundCard(SoundCard soundCard)
        {
            this.soundCard = soundCard;
        }

        /// <summary>
        /// 处理光驱读取数据后与其他对象的交互
        /// </summary>
        /// <param name="cdDriver">光驱对象</param>
        private void HandleCdDriverReadDatas(CdDriver cdDriver)
        {
            //1、获取光驱读取数据
            string tmpDatas = cdDriver.GetReadData();
            //2、将数据传递个CPU处理
            this.cpu.HandleDatas(tmpDatas);

        }

        /// <summary>
        /// 处理CPU解析数据后与其他对象的交互
        /// </summary>
        /// <param name="cpu">cpu对象</param>
        private void HandleCPUAnalyData(Cpu cpu)
        {
            //CPU解析视频与音频数据
            string tmpVideoDatas = cpu.GetVideoDatas();
            string tmpSoundDatas = cpu.GetSoundDatas();
            //将解析后的数据传递给显卡、声卡展现
            this.videoCard.ShowDatas(tmpVideoDatas);
            this.soundCard.SoundDatas(tmpSoundDatas);
        }

        /// <summary>
        /// 中介者处理各个同事之间的交互
        /// </summary>
        /// <param name="colleague">同事对象</param>
        public void Changed(Colleague colleague)
        {
            //判断是否为光驱
            if (colleague == cDDriver)
            {
                HandleCdDriverReadDatas((CdDriver)colleague);
            }
            //判断是否为CPU
            if (colleague == cpu)
            {
                HandleCPUAnalyData((Cpu)colleague);
            }
        }

    }//Class_end
}
