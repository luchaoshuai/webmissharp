using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBHelper
{
    public class SQLCmds
    {
        //获取所有的表、视图、存储过程
        public static string S_GETTables = "select name,xtype from dbo.sysobjects where (xtype='U' or xtype='V' or xtype='P') and category=0 order by xtype,name";
        public static string S_GETDBName = "SELECT DB_NAME()";
        public static string S_GETDBBasic = "Select suser_name(sid) owner,name,dbid,crdate,cmptlevel,filename FROM sys.sysdatabases where name=(select DB_NAME());";
        public static string S_GETDBFiles = "select name,size,max_size,physical_name from sys.master_files where database_id=(select DB_ID());";
        public static string S_GETPVUcount = "select xtype,COUNT(*) from dbo.sysobjects where (xtype='U' or xtype='V' or xtype='P') and category=0 group by xtype";
        public static string S_GETTableSize = "exec sp_spaceused '{0}'";
        public static string S_GETTableBasic = "select o.name,suser_name(ObjectProperty(object_id, 'ownerid')) owner,o.create_date from sys.all_objects o, master.dbo.spt_values v where o.name='{0}' and o.type = substring(v.name,1,2) collate database_default and v.type = 'O9T'";
        public static string S_GETTableStruct = "Select   'True' as ID,'TextField' as Form,"
                                            + "  Tid  = a.id, "
                                            + "  Cid  = a.colid, "
                                            + "  序号=a.colorder,   "
                                            + "  字段名=a.name,   "
                                            + "  标识=case when COLUMNPROPERTY(a.id,a.name,'IsIdentity')=1 then '√' else '' end,   "
                                            + "  主键=case when exists(Select 1 FROM sysobjects where xtype='PK' and name in (Select name FROM sysindexes Where indid in(Select indid FROM sysindexkeys Where id=a.id AND colid=a.colid))) then '√' else '' end,      "
                                            + "  字段类型=b.name,   "
                                            + "  长度=a.length,   "
                                            + "  占用字节数=COLUMNPROPERTY(a.id,a.name,'PRECISION'),   "
                                            + "  小数位数=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),   "
                                            + "  允许为空=case when a.isnullable=1 then '√'else '' end,   "
                                            + "  默认值=isnull(e.text,''),   "
                                            + "  说明=isnull(g.[value],a.name)   "
                                            + "FROM syscolumns a   "
                                            + "left join systypes b on a.xusertype=b.xusertype   "
                                            + "inner join sysobjects d on (a.id=d.id)and(d.xtype='U')and(d.name<>'dtproperties')   "
                                            + "left join syscomments e on a.cdefault=e.id   "
                                            + "left join sys.extended_properties g on (a.id=g.major_id)and(a.colid=g.minor_id)   "
                                            + "left join sys.extended_properties f on (d.id=f.major_id)and(f.minor_id=0)   "
                                            + "where d.name='{0}' "
                                            + "order by a.id,a.colorder   ";
        public static string S_SETFieldRemark = "if exists (select * from sys.extended_properties where major_id={0} and minor_id={1}) "
                                             + " EXEC sys.sp_updateextendedproperty @name=N'MS_Description', @value=N'{4}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{2}', @level2type=N'COLUMN',@level2name=N'{3}' "
                                             + " else "
                                             + " EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'{4}' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{2}', @level2type=N'COLUMN',@level2name=N'{3}' ";
        public static string S_GETTableAndViews = "select name TableName from dbo.sysobjects where (xtype='U' or xtype='V') and category=0 order by xtype,name";
        public static string S_GETTableViewStruct = "Select a.name FROM syscolumns a inner join sysobjects d on (a.id=d.id) where d.name='{0}' order by a.id,a.colorder;";

        public static string S_CreatePageProc = ""
                                        + ("if exists( select 1 from sys.all_objects where [type]='p' and [name]='P_FindByPage') ")
                                        + ("drop proc [P_FindByPage] ;");
        public static string S_CreatePageProc2 = ("create proc [P_FindByPage] ")
                                        + ("( ")
                                        + ("	@tablename varchar(100),")
                                        + ("	@id varchar(50) , ")
                                        + ("	@start varchar(10), ")
                                        + ("	@limit varchar(10), ")
                                        + ("	@conditions varchar(1000), ")
                                        + ("	@orderby int ")
                                        + (") ")
                                        + ("as ")
                                        + ("begin ")
                                        + ("	declare @strsql varchar(6000); ")
                                        + ("	")
                                        + ("	if(@orderby=0) ")
                                        + ("		begin ")
                                        + ("			set @strsql='select top '+@limit+' * from '+@tablename+' where '+@id+'>( select isnull(MAX('+@id+'),0) from (select top '+@start+' ' + @id + ' from ' + @tablename + ' order by '+@id+' asc) as Temp ) order by '+@id+' asc'; ")
                                        + ("			if(@conditions!='') ")
                                        + ("				set @strsql='select top ' + @limit + ' * from ' + @tablename + ' where ' + @id+ '>( select isnull(MAX(' + @id + '),0) from (select top ' + @start + ' ' + @id + ' from ' + @tablename + '  where ' + @conditions + ' order by ' + @id + ' asc) as Temp ) and ' + @conditions + ' order by ' + @id + ' asc'; ")
                                        + ("		end ")
                                        + ("	")
                                        + ("	if(@orderby=1) ")
                                        + ("		begin ")
                                        + ("			set @strsql='select top ' + @limit + ' * from ' + @tablename + ' where ' + @id + '<( select isnull(MIN(' + @id + '),(select max(' + @id + ')+1 from ' + @tablename + ')) from (select top ' + @start + ' ' + @id + ' from ' + @tablename + ' order by ' + @id + ' desc) as Temp ) order by ' + @id + ' desc'; ")
                                        + ("			if(@conditions!='') ")
                                        + ("				set @strsql='select top ' + @limit + ' * from ' + @tablename + ' where ' + @id + ' <( select isnull(MIN(' + @id + '),(select max(' + @id + ')+1 from ' + @tablename + ')) from (select top ' + @start + ' ' + @id + ' from ' + @tablename + '  where ' + @conditions + ' order by ' + @id + ' desc) as Temp ) and (' + @conditions + ') order by ' + @id + ' desc'; ")
                                        + ("		end ")
                                        + ("	exec (@strsql); ")
                                        + ("end ");

        public static string S_GetTableColumnsDesc = ""
                                                + ("Select  ")
                                                + ("  'FieldName'=a.name, ")
                                                + ("  'FieldDesc'=isnull(g.[value],'') ")
                                                + ("FROM syscolumns a ")
                                                + ("inner join sysobjects d on (a.id=d.id) and(d.name<>'dtproperties') ")
                                                + ("left join sys.extended_properties g on (a.id=g.major_id)and(a.colid=g.minor_id)    ")
                                                + ("left join sys.extended_properties f on (d.id=f.major_id)and(f.minor_id=0)    ")
                                                + ("where d.name='{0}' ")
                                                + ("order by a.id,a.colorder  ; ");
    }
}