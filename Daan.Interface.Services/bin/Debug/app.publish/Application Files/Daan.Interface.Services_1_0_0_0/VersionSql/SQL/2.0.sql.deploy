--添加字段 da_outspecimen.Customercode 
if not exists(select * from syscolumns where id=object_id('da_outspecimen') and name='Customercode') 
BEGIN
alter table [da_outspecimen] add  [Customercode] varchar(50) NULL
END

--添加字段 da_outspecimentest.SampleType 
if not exists(select * from syscolumns where id=object_id('da_outspecimentest') and name='SampleType') 
BEGIN
alter table [da_outspecimentest] add  [SampleType] varchar(50) NULL
END

--添加字段 da_dicttestitem.SampleType
if not exists(select * from syscolumns where id=object_id('da_dicttestitem') and name='SampleType') 
BEGIN
alter table [da_dicttestitem] add  [SampleType] varchar(50) NULL
END