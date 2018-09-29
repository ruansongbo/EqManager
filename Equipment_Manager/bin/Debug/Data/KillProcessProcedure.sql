 
use master
go
if exists (select * from sysobjects where name = 'proc_Kill')
drop Procedure proc_Kill
go
create Procedure proc_Kill
(
  @dbname varchar(50)
  
)
as
begin
	declare @sql nvarchar(500)
	declare @spid int--SPID 值是当用户进行连接时指派给该连接的一个唯一的整数
	set @sql='declare getspid cursor for 
             select spid from sysprocesses where dbid=db_id('''+@dbname+''')'
	exec (@sql)
	open getspid
	fetch next from getspid into @spid
	while @@fetch_status<>-1--如果FETCH 语句没有执行失败或此行不在结果集中。
	begin
	exec('kill '+@spid)--终止正常连接
	fetch next from getspid into @spid
	end
	close getspid
	deallocate getspid
    
end
