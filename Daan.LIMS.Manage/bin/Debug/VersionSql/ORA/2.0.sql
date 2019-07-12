/*添加字段 da_outspecimen.Customercode */
execute immediate 'alter table DA_OUTSPECIMEN add Customercode  VARCHAR2(50) null';

/*添加字段 da_outspecimentest.SampleType */
execute immediate 'alter table DA_OUTSPECIMENTEST add SampleType  VARCHAR2(50) null';

/*添加字段 da_dicttestitem.SampleType */
execute immediate 'alter table da_dicttestitem add SampleType  VARCHAR2(50) null';