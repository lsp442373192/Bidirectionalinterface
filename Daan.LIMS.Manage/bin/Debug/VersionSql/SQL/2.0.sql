/*添加字段 da_outspecimen.Customercode */
alter table da_outspecimen add  Customercode varchar(50) NULL

/*添加字段 da_outspecimentest.SampleType */
alter table da_outspecimentest add  SampleType varchar(50) NULL

/*添加字段 da_dicttestitem.SampleType */
alter table da_dicttestitem add  SampleType varchar(50) NULL