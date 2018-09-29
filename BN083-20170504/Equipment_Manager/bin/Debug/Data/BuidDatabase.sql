use master
go
exec sp_attach_db @dbname='Equipment_Manage',
   @filename1=N'C:\Solut_EquipentMgr_Data\Equipment_Manage_dat.mdf',
   @filename2=N'C:\Solut_EquipentMgr_Data\Equipment_Manage_log.ldf'
go