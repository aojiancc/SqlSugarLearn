using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarLearn
{
    [SplitTable(SplitType.Year)]//按年分表 （自带分表支持 年、季、月、周、日）
    [SugarTable("SplitTestTable_{year}{month}{day}")]//生成表名格式 3个变量必须要有
    public class SplitTestTable
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        public string Name { get; set; }

        [SplitField] //分表字段 在插入的时候会根据这个字段插入哪个表，在更新删除的时候用这个字段找出相关表
        public DateTime CreateTime { get; set; }
    }
}
