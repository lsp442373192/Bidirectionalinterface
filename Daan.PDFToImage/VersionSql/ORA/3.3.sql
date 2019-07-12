alter table dbo.da_result add  resultflag char(1) NULL

/*添加字段 da_testmap.LASTUPDATE */
alter table da_testmap add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_result.LASTUPDATE */
alter table da_result add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_dictuser.LASTUPDATE */
alter table da_dictuser add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_config.LASTUPDATE */
alter table da_config add  Lastupdate [datetime] NULL DEFAULT getdate()


insert into da_dictmaxid(tablename,idvalue,remark) 
values('DAAN_LIS_REPORT','1','获取PDF转图片表主键，tableName为客户服务器存储图片表名')