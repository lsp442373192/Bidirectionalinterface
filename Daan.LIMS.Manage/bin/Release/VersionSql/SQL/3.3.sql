alter table dbo.da_result add  resultflag char(1) NULL

/*添加字段 da_testmap.LASTUPDATE */
alter table da_testmap add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_result.LASTUPDATE */
alter table da_result add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_dictuser.LASTUPDATE */
alter table da_dictuser add  Lastupdate [datetime] NULL DEFAULT getdate()


/*添加字段 da_config.LASTUPDATE */
alter table da_config add  Lastupdate [datetime] NULL DEFAULT getdate()