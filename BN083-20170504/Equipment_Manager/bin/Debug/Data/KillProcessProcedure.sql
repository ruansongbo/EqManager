 
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
	declare @spid int--SPID ֵ�ǵ��û���������ʱָ�ɸ������ӵ�һ��Ψһ������
	set @sql='declare getspid cursor for 
             select spid from sysprocesses where dbid=db_id('''+@dbname+''')'
	exec (@sql)
	open getspid
	fetch next from getspid into @spid
	while @@fetch_status<>-1--���FETCH ���û��ִ��ʧ�ܻ���в��ڽ�����С�
	begin
	exec('kill '+@spid)--��ֹ��������
	fetch next from getspid into @spid
	end
	close getspid
	deallocate getspid
    
end
