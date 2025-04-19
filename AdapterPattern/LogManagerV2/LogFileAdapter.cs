/***
*	Title："设计模式" 项目
*		主题：适配器模式(单向适配器)
*	Description：
*	    基础概念：本质是【转换匹配，复用功能】
*	    适配器模式：将一个类的接口转换为客户希望的另外一个接口；适配器模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
*	    
*	    适配器模式的目的：复用已有的功能，进行转换匹配现有接口（即：负责把不兼容的接口转换为客户端期望的样子）
*	    
*	    适配器模式优点：
*	                    1、更好的复用性（功能已经有了，只是接口不兼容，通过适配器模式就可以让这些已有功能得到更好复用）
*	                    2、更好的可扩展性（实现适配器的时候，可以调用已经开发的功能，更加自然的扩展系统功能）
*	    
*	    适配器模式的缺点：
*	                    1、过多使用适配器，会让系统非常零乱，不容易进行整体把握（即：明明看到调用的是A接口，
*	                    但其实内部被适配成了B接口来实现；或系统中出现太多这种情况，是一场灾难；若无必要，建议直接重构）
*		    
*		何时选用适配器模式？
*		                1、想要使用一个已经存在的类，但是它的接口不符合你的需求
*		                2、想创建一个可以复用的类，这个类和一些不兼容的类一起工作
*		                3、想使用一些已经存在的类，但是不可能对每一个子类进行适配（直接适配这些子类的父类）
*		    
*	Date：2025
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
 ***/

using AdapterPattern.LogManagerV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.LogManagerV2
{
    /// <summary>
    /// 单向适配器类（继承第二版的日志操作接口【然后使用第一版的日志操作实现来完成第二版的增、删、改、查】方法
    /// </summary>
    internal class LogFileAdapter : ILogDBOperate
    {
        //持有需要被适配的接口对象（第一版文件日志接口）
        private ILogFileOpereate logFileOpereate;

        public LogFileAdapter(ILogFileOpereate logFileOpereate)
        {
            this.logFileOpereate = logFileOpereate;
        }


        public bool CreateLog(LogModel logModel)
        {

            List<LogModel> logModels=new List<LogModel>();
            //1、加入新的日志对象
            logModels.Add(logModel);
            //2、重新写入文件
            logFileOpereate.WriteLogFile(logModels);

            return true;
        }

        public bool DeleteLog(LogModel logModel)
        {
            //1、读取日志文件内容
            List<LogModel> logModels = new List<LogModel>();
            //2、移除对应的日志对象
            logModels.Remove(logModel);
            //重新写入日志文件
            logFileOpereate.WriteLogFile(logModels);

            return true;
        }

        public List<LogModel> QueryAllLog()
        {
            return logFileOpereate.ReadLogFile();
        }

        public bool UpdateLog(LogModel logModel)
        {
            //1、先读取文件内容
            List<LogModel> logModels=logFileOpereate.ReadLogFile();
            //2、修改相应地日志对象
            int count=logModels.Count;
            for (int i = 0; i < count; i++)
            {
                if (logModels[i].LogId.Equals(logModel.LogId))
                {
                    logModels[i] = logModel;
                    break;
                }
            }
            //3、重新写入文件
            logFileOpereate.WriteLogFile(logModels);

            return true;
        }

    }//Class_end
}
