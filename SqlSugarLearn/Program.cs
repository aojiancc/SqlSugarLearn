using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlSugarLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建数据库对象
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=.;uid=sa;pwd=123456;database=oa",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });

            //调试SQL事件，可以删掉
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);//输出sql,查看执行sql
            };

            //查询表的所有
            // var list = db.Queryable<Student>().ToPageList(1, 3);

            //var datas = new List<SplitTestTable>(){
            //new SplitTestTable(){CreateTime=Convert.ToDateTime("2019-12-1"),Name="jack2"} ,
            //new SplitTestTable(){CreateTime=Convert.ToDateTime("2022-02-1"),Name="vv2"},
            //new SplitTestTable(){CreateTime=Convert.ToDateTime("2020-02-1"),Name="mm2"},
            //new SplitTestTable(){CreateTime=Convert.ToDateTime("2021-12-1"),Name="gg2"}
            //};

            // db.Insertable(datas).SplitTable().ExecuteReturnSnowflakeIdList();//插入返回雪花ID集合

            //var list = db.Queryable<SplitTestTable>().SplitTable(DateTime.Now.Date.AddYears(-2), DateTime.Now).ToPageList(1, 5);



            var name = db.SplitHelper<SplitTestTable>().GetTableName(DateTime.Parse("2022-1-1"));//根据时间获取表名


            var result = db.Queryable<SplitTestTable>().Where(it => it.Id == 1620678150914707456).SplitTable(tas => tas.InTableNames(name)).ToList();


            Console.ReadLine();

        }
    }
}
