﻿/***
*	Title："设计模式" 项目
*		主题：迭代器模式
*	Description：
*	    基础概念：迭代器模式的本质是【控制访问聚合对象中的元素】
*	    
*	    迭代器模式的功能：主要在于提供对聚合对象的迭代访问。迭代器就围绕着这个【访问】做文章，延伸出很多功能来，如：
*	        1、以不同的方式遍历聚合对象（如：向前、向后等）；
*	        2、对同一个聚合同时进行多个遍历；
*	        3、以不同的遍历策略来遍历集合（如是否需要过滤等）；
*	        4、多态迭代（即：为不同的聚合结构提供统一的迭代接口，也就是说通过一个迭代接口可以访问不同的聚合结构）
*	        注意：多态迭代可能会带来类型安全问题，可以考虑使用泛型
*	    
*	    迭代器模式的关键思想：就是把聚合对象的遍历和访问从聚合对象中分离出来，放入单独的迭代器中（这样聚合对象会变得
*	        简单一些；而且迭代器和聚合对象可以独立地变化和发展，会加强系统的灵活性）
*	       
*	    内部迭代器和外部迭代器：
*	        1、内部迭代器：指的是由迭代器自己来控制迭代下一个元素的步骤，客户端无法干预（因此，如果想要在迭代的过程中
*	            完成工作的话，客户端就需要把操作传递给迭代器，迭代器在迭代的时候会在每个元素上执行这个操作）
*	        2、外部迭代器：指的是由客户端来控制迭代下一个元素的步骤；
*	        总体来说外部迭代器比内部迭代器要灵活一些，因此我们常见的实现也多属于外部迭代器
*	        
*	    带迭代策略的迭代器：
*	        1、带迭代策略的迭代器【最典型的就是实现过滤功能的迭代器】（即：在实际的开发中，对于经常被访问的一些数据
*	            可以使用缓存，把这些数据存放在内存中。但是不同的业务功能需要访问的数据是不同的，还有不同的业务访问权限
*	            能访问的数据也是不同的。对于这种情况，就可以使用实现过滤功能的迭代器，让不同功能使用不同的迭代器来访问。
*	            也可以结合策略模式来实现）
*	        2、谁定义遍历算法的问题：在迭代器模式中，常见的可用来定义遍历算法的地方是【聚合对象本身】【迭代器负责遍历算法】
*	            【聚合对象本身】定义遍历算法的情况下，通常会在遍历过程中，用迭代器来存储当前迭代的状态，这种迭代器被称为游标（
*	                因为它被用来指示当前的位置）
*	            【迭代器中定义遍历算法】情况下，如果实现遍历算法需要访问聚合对象的私有遍历，那么将遍历算法放入迭代器中会破坏聚合对象的封装性
*	            现实开发中，具体使用哪一种方式，需要根据具体的问题具体分析
*	      
*	     双向迭代器：可以同时向前向后遍历数据的迭代器
*	        
*	     迭代器模式的优点：
*	        1、更好的封装性（
*	            迭代器模式可以让你访问一个聚合对象的内容，而无须暴露该聚合对象的内部表示，从而提高聚合对象的封装性；
*	            可以以不同的遍历方式来遍历一个聚合；
*	            使用迭代器模式，使得聚合对象的内容和具体的迭代算法分离开；
*	            有了迭代器的接口，则聚合本身就不需要再定义这些接口了，从而简化了聚合的接口定义）
*	        2、简化客户端调用（迭代器为遍历不同的聚合对象提供了一个统一的接口，使得客户端遍历聚合对象的内容变得更简单；
*	            同一个聚合上可以有多个遍历；每个迭代器保持它自己的遍历状态，因此可以对同一个聚合对象同时进行多个遍历）
*	            
*	     何时选用迭代器模式？
*	        1、希望提供访问一个聚合对象的内容，但是又不想暴露它的内部表示时候，可使用迭代器模式来提供迭代器接口，从而让
*	            客户端只是通过迭代器的接口来访问聚合对象，而无须关系聚合对象的内部实现。
*	        2、希望有多种遍历方式可以访问聚合对象；
*	        3、希望为遍历不同的聚合对象提供一个统一的接口
*	        
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

namespace IteratorPattern.AggregateOne
{
    /// <summary>
    /// 用来实现访问Collection集合的迭代接口，为了外部统一访问
    /// </summary>
    internal class CollectionIteratorImpl : Itetator
    {
        //用来存放被迭代的聚合对象
        private PayManager payManager=null;
        //用来记录当前迭代的位置索引-1表示刚开始时，迭代器指向聚合对象第一个对象之前
        private int index=-1;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="payManager">客户方已有的工资管理对象</param>
        public CollectionIteratorImpl(PayManager payManager)
        {
            this.payManager = payManager;

        }

        public object CurrentItem()
        {
            return this.payManager.Get(index);
        }

        public void First()
        {
            index = 0;
        }

        public bool IsDone()
        {
            if (index == this.payManager.Size())
            {
                return true;
            }
            return false;
        }

        public void Next()
        {
            if (index<this.payManager.Size())
            {
                index = index + 1;
            }
        }

    }//Class_end
}
