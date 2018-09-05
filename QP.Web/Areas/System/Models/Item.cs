using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//直接连接  MYSQL
using MySql.Data.MySqlClient;
using QP.Cashier_Service;


namespace CeShi.Models
{
    ///<summary> 
    ///节点的实体类，记录了数据库中的3个字段 
    ///为的是方便操作
    /// </summary>

    public class Item
    {
        public int Id;
        public string Name;
        public int ParentId;
        public string IocCss;
        //  public string ContentText;
    }

    /// <summary>
    ///  节点类 ，基础类
    /// </summary>

    public class JieDian
    {
        public string Name = "";
        public int Id = 0;
        public int ParentId = 0;
        public string IocCss;
        // public string ContentText = "";
        public JieDian[] children = null;
    }

    /// <summary>
    /// 数据转Json格式
    /// </summary>
    public class Cliet
    {
        //根据parentId获取相应的子目录集合
        public Item[] GetTheItems(string parentId)
        {
            var db = GlobalDBContext.Instance();
            var dr = db.Navs.Where(u => u.Parentid == parentId);
            List<Item> items = new System.Collections.Generic.List<Item>();

            foreach (var item in dr)
            {
                Item i = new Item();
                i.Id = int.Parse(item.Id);
                i.Name = item.NavName;
                i.IocCss = item.IcoCss;
                i.ParentId = int.Parse(item.Parentid);
                //i.ContentText = item.Descrition;
                items.Add(i);
            }
            return items.ToArray();
        }

        //生成树的方法
        public void creatTheTree(string parentId, JieDian jd, out List<JieDian> outlist)
        {
            //获取
            Item[] items = GetTheItems(parentId);
            //如果没有字节点了，那就返回空
            if (items.Length == 0)
            {
                outlist = null;
                return;
            }
            List<JieDian> jdList = new List<JieDian>();
            for (int i = 0; i < items.Length; i++)
            {
                JieDian jiedian = new JieDian();
                jiedian.Id = items[i].Id;
                jiedian.Name = items[i].Name;
                jiedian.ParentId = items[i].ParentId;
                jiedian.IocCss = items[i].IocCss;
                //jiedian.ContentText = items[i].ContentText;
                //递归循环
                creatTheTree(items[i].Id.ToString(), jiedian, out outlist);
                jdList.Add(jiedian);
            }
            jd.children = jdList.ToArray(); //由于对象是引用类型，因为可以改变参数的值
            outlist = new List<JieDian>() { jd };
        }
    }
}
