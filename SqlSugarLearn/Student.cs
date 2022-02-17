using SqlSugar;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace SqlSugarLearn
{
    //实体与数据库结构一样
    public class Student
    {
        //数据是自增需要加上IsIdentity 
        //数据库是主键需要加上IsPrimaryKey 
        //注意：要完全和数据库一致2个属性
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
    }
}
