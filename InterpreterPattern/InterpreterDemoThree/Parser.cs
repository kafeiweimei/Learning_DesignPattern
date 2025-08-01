using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern.InterpreterDemoThree
{
    /// <summary>
    /// 根据语法来解析表达式【转换为相应的抽象语法树】
    /// </summary>
    internal class Parser
    {
        //定义几个常量，内部使用
        private const char BACKLASH = '/';
        private const char DOT = '.';
        private const string DOLLAR = "$";

        //按照分解的先后记录需要解析的元素名称
        private static List<string>elementList=null;

        /// <summary>
        /// 私有化构造器，避免外部无谓的创建对象实例
        /// </summary>
        private Parser()
        {
            
        }

        /// <summary>
        /// 传入一个字符串表达式（通过解析，组合成为一个抽象的语法树）
        /// </summary>
        /// <param name="expr">要取值的字符串表达式</param>
        /// <returns>对应的抽象语法树</returns>
        public static ReadXmlExpression Parse(string expr)
        {
            //先初始化记录需要解析的元素名称集合
            elementList=new List<string>();

            //1-分解表达式，得到需要解析的元素名称和该元素对应的解析模型
            Dictionary<string,ParserModel>dicPath=ParseDicPath(expr);

            //2-根据节点的属性转换为相应的解释器对象
            List<ReadXmlExpression> readXmlExpressionList = DicPathToInterpreter(dicPath);

            //3-组合抽象语法树，一定要按照先后顺序组合,否则对象的包含关系就混乱了
            ReadXmlExpression readXmlExpression =BuildTree(readXmlExpressionList);

            return readXmlExpression;

        }

        /// <summary>
        /// 按照从左到右的顺序来分解表达式，得到需要解析的元素名称
        /// </summary>
        /// <param name="expr">需要分解的表达式</param>
        /// <returns>得到需要解析的元素名称，还有该元素对应的解析模型</returns>
        private static Dictionary<string, ParserModel> ParseDicPath(string expr)
        {
            //按照/分割字符串
            string[] strTmp = expr.Split(BACKLASH);

            //初始化一个字典来存放分解出来的值
            Dictionary<string,ParserModel> DicPath=new Dictionary<string, ParserModel>();

            int len=strTmp.Length;
            for (int i = 0; i < len; i++)
            {
                if (i < len - 1)
                {
                    //说明这不是最后一个元素
                    //按照现在的语法，属性必然在最后，因此也不是属性
                    SetParsePath(false, strTmp[i], false, DicPath);
                }
                else
                {
                    //到最后
                    int dotIndex = strTmp[i].IndexOf(DOT);
                    if (dotIndex > 0)
                    {
                        //说明是要获取属性的值，那就按照"."来分割
                        //前面的就是元素的名称，后面的是属性的名字
                        string elementName = strTmp[i].Substring(0, dotIndex);
                        string propertyName = strTmp[i].Substring(dotIndex + 1);

                        //设置属性前面的元素（不是最后一个，也不是属性）
                        SetParsePath(false, elementName, false, DicPath);
                        //设置属性（按照现在的语法定义，属性只能是最后一个）
                        SetParsePath(true, propertyName, true, DicPath);

                    }
                    else
                    {
                        //说明是取元素的值，而且是最后一个元素的值
                        SetParsePath(true, strTmp[i],false,DicPath);
                    }
                    break;
                }
            }
            return DicPath;

        }

        /// <summary>
        /// 按照分解出来的位置和名称来设置需要解析的元素名称
        /// </summary>
        /// <param name="end">是否为最后一个</param>
        /// <param name="elementName">元素名称</param>
        /// <param name="propertyValue">是否取属性值</param>
        /// <param name="DicPath">设置需要解析的元素名称</param>
        private static void SetParsePath(bool end,string elementName,
            bool propertyValue,Dictionary<string,ParserModel>DicPath)
        {
            ParserModel pm = new ParserModel();
            pm.End = end;
            //如果带有$符号就说明不是一个值
            pm.SingleValue = (!(elementName.IndexOf(DOLLAR)>0));
            pm.PropertyValue = propertyValue;
            //去掉$
            elementName = elementName.Replace(DOLLAR,"");
            DicPath.Add(elementName, pm);
            elementList.Add(elementName);
            
        }


        /// <summary>
        /// 把分解出来的元素名称根据对应的解析模型转换为相应的解释器对象
        /// </summary>
        /// <param name="dicPath">分解出来的需要解析的元素名称，还有该元素对应的解析模型</param>
        /// <returns>把每个元素转换为相应的解释器对象后的集合</returns>
        private static List<ReadXmlExpression> DicPathToInterpreter(Dictionary<string,ParserModel>dicPath)
        {
            List<ReadXmlExpression> readXmlExpressionList=new List<ReadXmlExpression>();
            //一定要按照分解的先后顺序来转换成解释器对象
            foreach (var item in elementList)
            {
                ParserModel pm = dicPath[item];
                ReadXmlExpression obj = null;
                if (!pm.End)
                {
                    if (pm.SingleValue)
                    {
                        //不是最后一个，是一个值则转换
                        obj= new ElementExpression(item);
                    }
                    else
                    {
                        //不是最后一个，是多个值则转换
                        obj=new MutiElementExpression(item);
                    }
                }
                else
                {
                    if (pm.PropertyValue)
                    {
                        if (pm.SingleValue)
                        {
                            //是最后一个，是一个值，取属性的值
                            obj = new PropertyTerminalExpression(item);
                        }
                        else
                        {
                            //是最后一个，是多个值，取属性的值
                            obj = new MutiPropertyTerminalExpression(item);
                        }
                    }
                    else
                    {
                        if (pm.SingleValue)
                        {
                            //是最后一个，是一个值，取元素的值
                            obj = new ElementTerminalExpression(item);
                        }
                        else
                        {
                            //是最后一个，是多个值，取元素的值
                            obj = new MutiElementTerminalExpression(item);
                        }
                    }
                }

                //把转换后的对象添加到集合中
                readXmlExpressionList.Add(obj);
            }

            return readXmlExpressionList;
        }


        /// <summary>
        /// 构建语法树
        /// </summary>
        /// <param name="readXmlExpressionList">根据节点的属性转换为相应的解释器对象</param>
        /// <returns></returns>
        private static ReadXmlExpression BuildTree(List<ReadXmlExpression>readXmlExpressionList)
        {
            //第一个对象（返回去的对象，就是抽象语法树的根）
            ReadXmlExpression returnReadXmlExpression = null;

            //定义一个对象
            ReadXmlExpression parentReadXmlExpression = null;

            foreach (var item in readXmlExpressionList)
            {
                if (parentReadXmlExpression == null)
                {
                    //说明是第一个元素
                    parentReadXmlExpression = item;
                    returnReadXmlExpression = item;
                }
                else 
                {
                    //把元素添加到上一个对象下面，同时把本对象设置为oldReadXmlExpression,作为下一个对象的父节点
                    if (parentReadXmlExpression is ElementExpression)
                    {
                        ElementExpression elementExpression = (ElementExpression)parentReadXmlExpression;
                        elementExpression.AddElement(item);
                        parentReadXmlExpression = item;
                    }
                    else if (parentReadXmlExpression is MutiElementExpression)
                    {
                        MutiElementExpression mutiElementExpression = (MutiElementExpression)parentReadXmlExpression;
                        mutiElementExpression.AddElement(item);
                        parentReadXmlExpression = item;

                    }
                    
                }
            }

            return returnReadXmlExpression;
        }

    }//Class_end
}
