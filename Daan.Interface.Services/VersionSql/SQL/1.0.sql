--没有脚本则留空
--1、初始化创建表

--开始创建表
/****** Object:  Table [dbo].[da_config]    Script Date: 09/27/2012 15:03:09 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_config]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_config](
	[da_configid] [decimal](18, 0)  NOT NULL PRIMARY KEY,
	[dbversion] [varchar](200)  NULL,
	[hospname] [varchar](200) NOT NULL,
	[conveta4] [varchar](200) NULL,
	[address] [varchar](200) NULL,
	[username] [varchar](200) NULL,
	[password] [varchar](200) NULL,
	[interval] [varchar](200) NULL,
	[downreports] [varchar](200) NULL,
	[usehospcode] [varchar](200) NULL,
	[sitecode] [varchar](50) NULL,
	[model] [varchar](50) NULL,
);

--END

/****** Object:  Table [dbo].[da_dictmaxid]    Script Date: 10/24/2012 09:14:38 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_dictmaxid]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_dictmaxid](
	[tablename] [varchar](50) NOT NULL PRIMARY KEY,
	[idvalue] [bigint] NULL DEFAULT 0,
	[remark] [varchar](500) NULL,
) ;
--END


/****** Object:  Table [dbo].[da_dicttestitem]    Script Date: 09/27/2012 15:16:35 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_dicttestitem]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_dicttestitem](
	[datestitemid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[datestcode] [varchar](30) NOT NULL,
	[datestname] [varchar](500) NULL,
	[englishname] [varchar](200) NULL,
	[engshortname] [varchar](100) NULL,
	[isgroup] [char](1) NOT NULL,
	[testmethod] [varchar](80) NULL,
	[testtype] [varchar](80) NULL,
	[createtime] [datetime] NULL DEFAULT getdate(),
	[fastcode] [varchar](80) NULL,
);
--END	



/****** Object:  Table [dbo].[da_dictuser]    Script Date: 09/27/2012 15:21:19 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_dictuser]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_dictuser](
	[dictuserid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[usercode] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[remark] [varchar](500) NULL,
	[isactive] [char](1) NULL  DEFAULT 1,
	[createdate] [datetime] NULL DEFAULT getdate(),
);
--END	



/****** Object:  Table [dbo].[da_errorlog]    Script Date: 09/27/2012 15:23:13 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_errorlog]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_errorlog](
	[errorlogid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[dictuserid] [decimal](18, 0) NOT NULL,
	[usercode] [varchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[opcontent] [varchar](4000) NULL,
	[usertype] [char](1) NULL DEFAULT 0,
	[ipaddress] [varchar](50) NULL,
	[machinename] [varchar](50) NULL,
);

--END	



/****** Object:  Table [dbo].[da_lis_picture]    Script Date: 09/27/2012 15:26:28 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_lis_picture]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_lis_picture](
	[lis_pictureid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NULL,
	[indexno] [numeric](5, 0) NULL,
	[description] [varchar](200) NULL,
	[imagedata] [image] NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
);

--END



/****** Object:  Table [dbo].[da_micantiresult]    Script Date: 09/27/2012 15:29:29 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_micantiresult]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_micantiresult](
	[micantiresultid]  [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[hospsamplenumber] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NULL,
	[requestcode] [varchar](20) NOT NULL,
	[micorgresultid] [numeric](10, 0) NOT NULL,
	[anticode] [varchar](100) NULL,
	[antiname] [varchar](100) NULL,
	[engantiname] [varchar](200) NULL,
	[displayorder] [numeric](10, 0) NULL DEFAULT 0,
	[resultvalue] [varchar](50) NULL,
	[testresult] [varchar](50) NULL,
	[srange] [decimal](18, 2) NULL DEFAULT 0,
	[rrange] [decimal](18, 2) NULL DEFAULT 0,
	[createdate] [datetime] NULL DEFAULT getdate(),
);

--END	



/****** Object:  Table [dbo].[da_micantiresult]    Script Date: 09/27/2012 15:29:29 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_micorgresult]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_micorgresult](
	[micorgresultid]  [decimal](18, 0) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NOT NULL,
	[hospsampleid] [varchar](20) NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[engorgname] [varchar](200) NULL,
	[organismcode] [varchar](50) NULL,
	[organismname] [varchar](200) NULL,
	[tips] [varchar](200) NULL,
	[quantity] [varchar](200) NULL,
	[quantitycomment] [varchar](500) NULL,
	[displayorder] [numeric](10, 0) NULL DEFAULT 0,
	[status] [varchar](50) NULL,
	[reportoption] [char](1) NULL DEFAULT 0,
);
--END


/****** Object:  Table [dbo].[da_operationlog]    Script Date: 10/10/2012 14:52:28 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_operationlog]') AND type in (N'U'))
--BEGIN
	
CREATE TABLE [dbo].[da_operationlog](
	[operationlogid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NOT NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[dictuserid] [numeric](10, 0) NOT NULL,
	[usercode] [varchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[optype] [varchar](50) NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[opcontent] [varchar](4000) NULL,
	[usertype] [char](1) NULL DEFAULT 0,
);
--END	

/****** Object:  Table [dbo].[da_outspecimen]    Script Date: 09/27/2012 15:29:29 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_outspecimen]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_outspecimen](
	[outspecimenid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NOT NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[patientnumber] [varchar](30) NULL,
	[bednumber] [varchar](30) NULL,
	[samplingdate] [datetime] NULL,
	[patientsource] [varchar](50) NULL,
	[patientname] [varchar](100) NULL,
	[sex] [char](1) NULL,
	[caculateage] [numeric](10, 0) NULL,
	[patienttel] [varchar](30) NULL,
	[location] [varchar](30) NULL,
	[patientid] [varchar](20) NULL,
	[doctor] [varchar](30) NULL,
	[doctortel] [varchar](30) NULL,
	[birthday] [datetime] NULL,
	[age] [numeric](10, 0) NULL,
	[ageunit] [char](1) NULL,
	[samstate] [varchar](30) NULL,
	[diagnostication] [varchar](500) NULL,
	[customertestcodes] [varchar](500) NULL,
	[customertestnames] [varchar](500) NULL,
	[datestcodes] [varchar](500) NULL,
	[datestnames] [varchar](500) NULL,
	[status] [char](1) NULL,
	[remark] [varchar](200) NULL,
	[babycount] [varchar](50) NULL,
	[lmp] [varchar](50) NULL,
	[lmpdate] [varchar](50) NULL,
	[uninevolumn] [varchar](50) NULL,
	[weight] [varchar](50) NULL,
	[height] [varchar](50) NULL,
	[bultrasonic] [varchar](50) NULL,
	[pregnant] [varchar](50) NULL,
	[enterby] [varchar](50) NULL,
	[enterbydate] [datetime] NULL,
	[lastupdatedate] [datetime] NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[usertype] [char](1) NULL DEFAULT 0,
	[BodyStyle] [varchar](50) NULL,
);
--END




/****** Object:  Table [dbo].[da_outspecimentest]    Script Date: 09/27/2012 15:42:55 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_outspecimentest]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_outspecimentest](
	[outspecimentestid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NOT NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[customertestcode] [varchar](500) NULL,
	[customertestname] [varchar](500) NULL,
	[datestcode] [varchar](500) NULL,
	[datestname] [varchar](500) NULL,
	[createdate] [datetime] NULL  DEFAULT getdate(),
	[status] [char](1) NULL,
);
--END



/****** Object:  Table [dbo].[da_pathologyresult]    Script Date: 09/27/2012 15:46:33 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_pathologyresult]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_pathologyresult](
	[pathologyresultid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[hospsampleid] [varchar](20) NOT NULL,
	[testid] [numeric](10, 0) NULL,
	[parentid] [numeric](10, 0) NULL,
	[treelevel] [numeric](10, 0) NULL,
	[itemname] [varchar](50) NULL,
	[result] [varchar](200) NULL,
	[displayorder] [numeric](10, 0) NULL,
	[createdate] [datetime] NULL  DEFAULT getdate(),
);

--END	


/****** Object:  Table [dbo].[da_report]    Script Date: 09/27/2012 15:48:57 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_report]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_report](
	[reportid] [decimal](18, 0) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](50) NOT NULL,
	[hospsamplenumber] [varchar](50) NULL,
	[hospsampleid] [varchar](50) NULL,
	[reportdata] [image] NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[printcount] [numeric](5, 0) NULL,
	[printtime] [datetime] NULL,
	[reporttype] [varchar](50) NULL,
	[status] [char](1) NULL,
	[papersize] [varchar](50) NULL,
);
--END	



/****** Object:  Table [dbo].[da_result]    Script Date: 09/27/2012 15:48:57 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_result]') AND type in (N'U'))
--BEGIN
CREATE TABLE [dbo].[da_result](
	[resultid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[requestcode] [varchar](20) NOT NULL,
	[hospsampleid] [varchar](20) NULL,
	[hospsamplenumber] [varchar](20) NULL,
	[testtype] [varchar](80) NULL,
	[customergroupcode] [varchar](100) NULL,
	[customergroupname] [varchar](200) NULL,
	[customertestcode] [varchar](100) NULL,
	[customertestname] [varchar](200) NULL,
	[dagroupcode] [varchar](100) NOT NULL,
	[dagroupname] [varchar](200) NOT NULL,
	[datestcode] [varchar](100) NOT NULL,
	[datestname] [varchar](200) NOT NULL,
	[seqno] [varchar](20) NULL,
	[testresult] [varchar](4000) NULL,
	[unit] [varchar](20) NULL,
	[hlflag] [varchar](10) NULL,
	[resultcomment] [varchar](4000) NULL,
	[reference] [varchar](500) NULL,
	[releasebyname] [varchar](30) NULL,
	[releasedate] [datetime] NULL,
	[authorizebyname] [varchar](30) NULL,
	[authorizedate] [datetime] NULL,
	[status] [char](1) NULL DEFAULT 0,
	[testmethod] [varchar](30) NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[reportremark] [varchar](4000) NULL,
	[panicflag] [varchar](30) NULL,
);
--END	



/****** Object:  Table [dbo].[DA_SoftVersion]    Script Date: 10/16/2012 14:53:27 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DA_SoftVersion]') AND type in (N'U'))
--BEGIN

CREATE TABLE [dbo].[DA_SoftVersion](
	[versionCode] [decimal](18, 1) NOT NULL PRIMARY KEY,
	[versionInfo] [nvarchar](4000) NULL,
	[updatedate] [datetime] NULL,
	[remark] [nvarchar](4000) NULL,
	[expansion] [nvarchar](4000) NULL,
	[ExceptionLog] [nvarchar](4000) NULL,
);

--END


/****** Object:  Table [dbo].[da_tablelastdate]    Script Date: 09/27/2012 15:56:30 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_tablelastdate]') AND type in (N'U'))
--BEGIN

CREATE TABLE [dbo].[da_tablelastdate](
	[tablelastdateid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tablename] [varchar](50) NULL,
	[lastdate] [datetime] NULL,
	[createdate] [datetime] NULL DEFAULT getdate(),
	[remark] [varchar](500) NULL,
);
--END	



/****** Object:  Table [dbo].[da_testmap]    Script Date: 09/27/2012 15:57:49 ******/
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[da_testmap]') AND type in (N'U'))
--BEGIN

CREATE TABLE [dbo].[da_testmap](
	[testmapid] [decimal](18, 0) IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[datestcode] [varchar](80) NULL,
	[datestname] [varchar](80) NULL,
	[customertestcode] [varchar](80) NULL,
	[customertestname] [varchar](80) NULL,
	[createtime] [datetime] NULL DEFAULT getdate(),
);
--END	

--基础数据创建
--创建管理员帐号admin 默认密码admin
IF NOT EXISTS (SELECT * FROM [da_dictuser] WHERE [usercode]='admin')
BEGIN

INSERT INTO [da_dictuser]([usercode],[username],[password],[remark],[isactive],[createdate])
     VALUES('admin','管理员','21232f297a57a5a743894a0e4a801fc3','管理员','1',getdate())

END;

--创建DA_TABLELASTDATE添加反审核查询最后时间
IF NOT EXISTS (SELECT * FROM [DA_TABLELASTDATE] WHERE [TABLENAME]='ExBarCode')
BEGIN
INSERT INTO DA_TABLELASTDATE
(TABLENAME,LASTDATE,CREATEDATE,REMARK)
VALUES('ExBarCode',getdate(),getdate(),'反审核查询最后时间')
END;

--创建DA_TABLELASTDATE日志上传最后时间
IF NOT EXISTS (SELECT * FROM [DA_TABLELASTDATE] WHERE [TABLENAME]='ErrorLog')
BEGIN
INSERT INTO DA_TABLELASTDATE
(TABLENAME,LASTDATE,CREATEDATE,REMARK)
VALUES('ErrorLog',getdate(),getdate(),'日志上传最后时间')
END;

--创建获取细菌表主键记录
IF NOT EXISTS (SELECT * FROM [da_dictmaxid] WHERE [TABLENAME]='SEQ_DA_MICORGRESULT')
BEGIN
insert into da_dictmaxid(tablename,idvalue,remark) 
values('SEQ_DA_MICORGRESULT','1','获取细菌表主键，tableName为Oracle中序列名')
END;