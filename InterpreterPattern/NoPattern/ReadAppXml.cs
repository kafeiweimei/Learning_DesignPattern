using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InterpreterPattern.NoPattern
{
    internal class ReadAppXml
    {

        //读取配置文件内容
        public void Read(string filePathName,string rootName)
        {
            if (string.IsNullOrEmpty(filePathName) || string.IsNullOrEmpty(rootName)) return;

            XmlDocument xmlDoc= new XmlDocument();
            xmlDoc.Load(filePathName);
            //获取根节点
            XmlNode rootNode = xmlDoc.SelectSingleNode(rootName);
            //得到根节点下的节点集合
            XmlNodeList xmlNodeList = rootNode.ChildNodes;

            //获取根节点下的所有子节点
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                switch (xmlNode.Name)
                {
                    case "jdbc":
                        foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
                        {
                            Console.WriteLine($"{xmlNode2.Name}={xmlNode2.InnerText}");
                        }
                        break;
                    case "application-xml":
                            Console.WriteLine($"{xmlNode.Name}={xmlNode.InnerText}");
                        break;

                    default:
                        break;
                }
            }
            
        }


    }//Class_end
}
