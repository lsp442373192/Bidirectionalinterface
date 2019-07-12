--没有脚本则留空


--开始建表
-- Create table DA_CONFIG
declare
  num number;
begin
  select count(1) into num from all_tables where TABLE_NAME='DA_CONFIG';
  if (num<1)   then 
execute immediate 'create table DA_CONFIG
(
  DA_CONFIGID NUMBER(10) not null,
  DBVERSION   VARCHAR2(200),
  HOSPNAME    VARCHAR2(200) not null,
  CONVETA4    VARCHAR2(200),
  ADDRESS     VARCHAR2(200),
  USERNAME    VARCHAR2(200),
  PASSWORD    VARCHAR2(200),
  INTERVAL    VARCHAR2(200),
  DOWNREPORTS VARCHAR2(200),
  USEHOSPCODE VARCHAR2(200),
  SITECODE    VARCHAR2(50),
  MODEL       VARCHAR2(50)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_CONFIG
  add constraint PK_DA_CONFIG primary key (DA_CONFIGID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_CONFIG创建成功!');
else dbms_output.put_line('表DA_CONFIG已经存在!');
end   if;
end;
/

-- Create table DA_DICTTESTITEM
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_DICTTESTITEM'; 
      if  (num<1)  then 
  
execute immediate 'create table DA_DICTTESTITEM
(
  DATESTITEMID NUMBER(10) not null,
  DATESTCODE   VARCHAR2(30) not null,
  DATESTNAME   VARCHAR2(500),
  ENGLISHNAME  VARCHAR2(200),
  ENGSHORTNAME VARCHAR2(100),
  ISGROUP      CHAR(1) not null,
  TESTMETHOD   VARCHAR2(80),
  TESTTYPE     VARCHAR2(80),
  CREATETIME   DATE default SYSDATE,
  FASTCODE     VARCHAR2(80)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_DICTTESTITEM
  add constraint PK_DA_DICTTESTITEM primary key (DATESTITEMID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_DICTTESTITEM创建成功!');
else dbms_output.put_line('表DA_DICTTESTITEM已经存在!');
end   if; 
end; 

/

-- Create table DA_DICTUSER
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_DICTUSER'; 
      if   num<1   then 
  
execute immediate 'create table DA_DICTUSER
(
  DICTUSERID NUMBER(10) not null,
  USERCODE   VARCHAR2(50),
  USERNAME   VARCHAR2(50),
  PASSWORD   VARCHAR2(50),
  REMARK     VARCHAR2(500),
  ISACTIVE   CHAR(1) default (1),
  CREATEDATE DATE default SYSDATE
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_DICTUSER
  add constraint PK_DA_DICTUSER primary key (DICTUSERID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_DICTUSER创建成功!');
else dbms_output.put_line('表DA_DICTUSER已经存在!');
end   if; 
end; 

/

-- Create table DA_ERRORLOG
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_ERRORLOG'; 
      if   num<1   then 
  
execute immediate 'create table DA_ERRORLOG
(
  ERRORLOGID NUMBER(10) not null,
  DICTUSERID NUMBER(10) not null,
  USERCODE   VARCHAR2(50),
  USERNAME   NVARCHAR2(50),
  CREATEDATE DATE default SYSDATE,
  OPCONTENT  VARCHAR2(4000),
  USERTYPE   CHAR(1) default ''0''
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_ERRORLOG
  add constraint PK_DA_ERRORLOG primary key (ERRORLOGID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_ERRORLOG创建成功!');
else dbms_output.put_line('表DA_ERRORLOG已经存在!');
end   if; 
end; 

/

-- Create table DA_LIS_PICTURE
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_LIS_PICTURE'; 
      if   num<1   then 
  
execute immediate 'create table DA_LIS_PICTURE
(
  LIS_PICTUREID    NUMBER(10) not null,
  REQUESTCODE      VARCHAR2(20),
  HOSPSAMPLENUMBER VARCHAR2(20),
  HOSPSAMPLEID     VARCHAR2(20),
  INDEXNO          NUMBER(5),
  DESCRIPTION      VARCHAR2(200),
  IMAGEDATA        BLOB,
  CREATEDATE       DATE default SYSDATE
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_LIS_PICTURE
  add constraint PK_DA_LIS_PICTURE primary key (LIS_PICTUREID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_LIS_PICTURE创建成功!');
else dbms_output.put_line('表DA_LIS_PICTURE已经存在!');
end   if; 
end; 

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_MICANTIRESULT'; 
      if   num<1   then 
  
execute immediate 'create table DA_MICANTIRESULT
(
  MICANTIRESULTID  NUMBER(10) not null,
  HOSPSAMPLENUMBER VARCHAR2(20),
  HOSPSAMPLEID     VARCHAR2(20),
  REQUESTCODE      VARCHAR2(20) not null,
  MICORGRESULTID   NUMBER(10) not null,
  ANTICODE         VARCHAR2(100),
  ANTINAME         VARCHAR2(100),
  ENGANTINAME      VARCHAR2(200),
  DISPLAYORDER     NUMBER(10) default (0),
  RESULTVALUE      VARCHAR2(50),
  TESTRESULT       VARCHAR2(50),
  SRANGE           NUMBER(18,2) default (0),
  RRANGE           NUMBER(18,2) default (0),
  CREATEDATE       DATE default SYSDATE
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_MICANTIRESULT
  add constraint PK_DA_MICANTIRESULT primary key (MICANTIRESULTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_MICANTIRESULT创建成功!');
else dbms_output.put_line('表DA_MICANTIRESULT已经存在!');
end   if; 
end; 

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_MICORGRESULT'; 
      if   num<1   then 
  
execute immediate 'create table DA_MICORGRESULT
(
  MICORGRESULTID   NUMBER(10) not null,
  REQUESTCODE      VARCHAR2(20) not null,
  HOSPSAMPLEID     VARCHAR2(20),
  HOSPSAMPLENUMBER VARCHAR2(20),
  CREATEDATE       DATE default SYSDATE,
  ENGORGNAME       VARCHAR2(200),
  ORGANISMCODE     VARCHAR2(50),
  ORGANISMNAME     VARCHAR2(200),
  TIPS             VARCHAR2(200),
  QUANTITY         VARCHAR2(200),
  QUANTITYCOMMENT  VARCHAR2(500),
  DISPLAYORDER     NUMBER(10) default (0),
  REPORTOPTION     CHAR(1) default (0)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_MICORGRESULT
  add constraint PK_DA_MICORGRESULT primary key (MICORGRESULTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_MICORGRESULT创建成功!');
else dbms_output.put_line('表DA_MICORGRESULT已经存在!');
end   if; 
end; 

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_OPERATIONLOG'; 
      if   num<1   then 
        
execute immediate 'create table DA_OPERATIONLOG
(
  OPERATIONLOGID   NUMBER(10) not null,
  REQUESTCODE      VARCHAR2(20),
  HOSPSAMPLEID     VARCHAR2(20) not null,
  HOSPSAMPLENUMBER VARCHAR2(20),
  DICTUSERID       NUMBER(10) not null,
  USERCODE         VARCHAR2(50),
  USERNAME         NVARCHAR2(50),
  OPTYPE           VARCHAR2(50),
  CREATEDATE       DATE default SYSDATE,
  OPCONTENT        VARCHAR2(4000),
  USERTYPE         CHAR(1) default ''0''
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_OPERATIONLOG
  add constraint PK_DA_OPERATIONLOG primary key (OPERATIONLOGID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_OPERATIONLOG创建成功!');
else dbms_output.put_line('表DA_OPERATIONLOG已经存在!');
end   if; 
end; 

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_OUTSPECIMEN'; 
      if   num<1   then 
        
execute immediate 'create table DA_OUTSPECIMEN
(
  OUTSPECIMENID     NUMBER(10) not null,
  REQUESTCODE       VARCHAR2(20),
  HOSPSAMPLEID      VARCHAR2(20) not null,
  HOSPSAMPLENUMBER  VARCHAR2(20),
  PATIENTNUMBER     VARCHAR2(30),
  BEDNUMBER         VARCHAR2(30),
  SAMPLINGDATE      DATE,
  PATIENTSOURCE     VARCHAR2(50),
  PATIENTNAME       VARCHAR2(100),
  SEX               CHAR(1),
  CACULATEAGE       NUMBER(10),
  PATIENTTEL        VARCHAR2(30),
  LOCATION          VARCHAR2(30),
  PATIENTID         VARCHAR2(20),
  DOCTOR            VARCHAR2(30),
  DOCTORTEL         VARCHAR2(30),
  BIRTHDAY          DATE,
  AGE               NUMBER(10),
  AGEUNIT           CHAR(1),
  SAMSTATE          VARCHAR2(30),
  DIAGNOSTICATION   VARCHAR2(500),
  CUSTOMERTESTCODES VARCHAR2(500),
  CUSTOMERTESTNAMES VARCHAR2(500),
  DATESTCODES       VARCHAR2(500),
  DATESTNAMES       VARCHAR2(500),
  STATUS            CHAR(1),
  REMARK            VARCHAR2(200),
  BABYCOUNT         VARCHAR2(50),
  LMP               VARCHAR2(50),
  LMPDATE           VARCHAR2(50),
  UNINEVOLUMN       VARCHAR2(50),
  WEIGHT            VARCHAR2(50),
  HEIGHT            VARCHAR2(50),
  BULTRASONIC       VARCHAR2(50),
  PREGNANT          VARCHAR2(50),
  ENTERBY           VARCHAR2(50),
  ENTERBYDATE       DATE,
  LASTUPDATEDATE    DATE,
  CREATEDATE        DATE default SYSDATE,
  USERTYPE          CHAR(1) default ''0'',
  BODYSTYLE         VARCHAR2(50)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_OUTSPECIMEN
  add constraint PK_DA_OUTSPECIMEN primary key (OUTSPECIMENID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_OUTSPECIMEN创建成功!');
else dbms_output.put_line('表DA_OUTSPECIMEN已经存在!');
END IF  ;
END;


/


-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_OUTSPECIMENTEST'; 
      if   num<1   then 
        
execute immediate 'create table DA_OUTSPECIMENTEST
(
  OUTSPECIMENTESTID NUMBER(10) not null,
  REQUESTCODE       VARCHAR2(20),
  HOSPSAMPLEID      VARCHAR2(20) not null,
  HOSPSAMPLENUMBER  VARCHAR2(20),
  CUSTOMERTESTCODE  VARCHAR2(500),
  CUSTOMERTESTNAME  VARCHAR2(500),
  DATESTCODE        VARCHAR2(500),
  DATESTNAME        VARCHAR2(500),
  CREATEDATE        DATE default SYSDATE,
  STATUS      CHAR(1) 
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_OUTSPECIMENTEST
  add constraint PK_DA_OUTSPECIMENTEST primary key (OUTSPECIMENTESTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_OUTSPECIMENTEST创建成功!');
else dbms_output.put_line('表DA_OUTSPECIMENTEST已经存在!');
END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_PATHOLOGYRESULT'; 
      if   num<1   then 
        
execute immediate 'create table DA_PATHOLOGYRESULT
(
  PATHOLOGYRESULTID NUMBER(10) not null,
  REQUESTCODE       VARCHAR2(20),
  HOSPSAMPLENUMBER  VARCHAR2(20),
  HOSPSAMPLEID      VARCHAR2(20) not null,
  TESTID            NUMBER(10),
  PARENTID          NUMBER(10),
  TREELEVEL         NUMBER(10),
  ITEMNAME          VARCHAR2(50),
  RESULT            VARCHAR2(200),
  DISPLAYORDER      NUMBER(10),
  CREATEDATE        DATE default SYSDATE
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_PATHOLOGYRESULT
  add constraint PK_DA_PATHOLOGYRESULT primary key (PATHOLOGYRESULTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_PATHOLOGYRESULT创建成功!');
else dbms_output.put_line('表DA_PATHOLOGYRESULT已经存在!');
END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_REPORT'; 
      if   num<1   then 
        
execute immediate 'create table DA_REPORT
(
  REPORTID         NUMBER(10) not null,
  REQUESTCODE      VARCHAR2(50) not null,
  HOSPSAMPLENUMBER VARCHAR2(50),
  HOSPSAMPLEID     VARCHAR2(50),
  SPECIMENREPORTID NUMBER(10) not null,
  REPORTDATA       BLOB,
  CREATEDATE       DATE default SYSDATE,
  PRINTCOUNT       NUMBER(5),
  PRINTTIME        DATE,
  REPORTTYPE       VARCHAR2(50),
  STATUS           CHAR(1)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_REPORT
  add constraint PK_DA_REPORT unique (REPORTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_REPORT创建成功!');
else dbms_output.put_line('表DA_REPORT已经存在!');
END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_RESULT'; 
      if   num<1   then 
        
execute immediate 'create table DA_RESULT
(
  RESULTID          NUMBER(10) not null,
  REQUESTCODE       VARCHAR2(20) not null,
  HOSPSAMPLEID      VARCHAR2(20),
  HOSPSAMPLENUMBER  VARCHAR2(20),
  TESTTYPE          VARCHAR2(80),
  CUSTOMERGROUPCODE VARCHAR2(100),
  CUSTOMERGROUPNAME VARCHAR2(200),
  CUSTOMERTESTCODE  VARCHAR2(100),
  CUSTOMERTESTNAME  VARCHAR2(200),
  DAGROUPCODE       VARCHAR2(100) not null,
  DAGROUPNAME       VARCHAR2(200) not null,
  DATESTCODE        VARCHAR2(100) not null,
  DATESTNAME        VARCHAR2(200) not null,
  SEQNO             VARCHAR2(20),
  TESTRESULT        VARCHAR2(4000),
  UNIT              VARCHAR2(20),
  HLFLAG            VARCHAR2(10),
  RESULTCOMMENT     VARCHAR2(4000),
  REFERENCE         VARCHAR2(60),
  RELEASEBYNAME     VARCHAR2(30),
  RELEASEDATE       DATE,
  AUTHORIZEBYNAME   VARCHAR2(30),
  AUTHORIZEDATE     DATE,
  STATUS            CHAR(1) default ''0'',
  TESTMETHOD        VARCHAR2(30),
  CREATEDATE        DATE default SYSDATE,
  REPORTREMARK      VARCHAR2(4000),
  PANICFLAG         VARCHAR2(30)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_RESULT
  add constraint PK_DA_RESULT primary key (RESULTID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_RESULT创建成功!');
else dbms_output.put_line('表DA_RESULT已经存在!');
      END IF;
END;

/


-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_SOFTVERSION'; 
      if   num<1   then 
        
execute immediate 'create table DA_SOFTVERSION
(
  VERSIONCODE  NUMBER(10,1) not null,
  VERSIONINFO  VARCHAR2(400),
  UPDATEDATE   DATE default SYSDATE,
  REMARK       VARCHAR2(4000),
  EXPANSION    VARCHAR2(4000),
  EXCEPTIONLOG VARCHAR2(4000)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_SOFTVERSION
  add constraint PK_DA_SOFTVERSION primary key (VERSIONCODE)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_TABLELASTDATE创建成功!');
else dbms_output.put_line('表DA_TABLELASTDATE已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_TABLELASTDATE'; 
      if   num<1   then 
        
execute immediate 'create table DA_TABLELASTDATE
(
  TABLELASTDATEID NUMBER(10),
  TABLENAME       VARCHAR2(50),
  LASTDATE        DATE,
  CREATEDATE      DATE default SYSDATE,
  REMARK          VARCHAR2(500)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_TABLELASTDATE
  add constraint PK_TABLELASTDATEID unique (TABLELASTDATEID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_TABLELASTDATE创建成功!');
else dbms_output.put_line('表DA_TABLELASTDATE已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'DA_TESTMAP'; 
      if   num<1   then 
        
execute immediate 'create table DA_TESTMAP
(
  TESTMAPID        NUMBER(10) not null,
  DATESTCODE       VARCHAR2(80),
  DATESTNAME       VARCHAR2(80),
  CUSTOMERTESTCODE VARCHAR2(80),
  CUSTOMERTESTNAME VARCHAR2(80),
  CREATETIME       DATE default SYSDATE
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate primary, unique and foreign key constraints 
execute immediate 'alter table DA_TESTMAP
  add constraint PK_DA_TESTMAP primary key (TESTMAPID)
  using index 
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
dbms_output.put_line('表DA_TESTMAP创建成功!');
else dbms_output.put_line('表DA_TESTMAP已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'PBCATCOL'; 
      if   num<1   then 
        
execute immediate 'create table PBCATCOL
(
  PBC_TNAM VARCHAR2(30) not null,
  PBC_TID  INTEGER,
  PBC_OWNR VARCHAR2(30) not null,
  PBC_CNAM VARCHAR2(30) not null,
  PBC_CID  INTEGER,
  PBC_LABL VARCHAR2(254),
  PBC_LPOS INTEGER,
  PBC_HDR  VARCHAR2(254),
  PBC_HPOS INTEGER,
  PBC_JTFY INTEGER,
  PBC_MASK VARCHAR2(31),
  PBC_CASE INTEGER,
  PBC_HGHT INTEGER,
  PBC_WDTH INTEGER,
  PBC_PTRN VARCHAR2(31),
  PBC_BMAP CHAR(1),
  PBC_INIT VARCHAR2(254),
  PBC_CMNT VARCHAR2(254),
  PBC_EDIT VARCHAR2(31),
  PBC_TAG  VARCHAR2(254)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate indexes 
execute immediate 'create unique index PBSYSCATCOLDICT_IDX on PBCATCOL (PBC_TNAM, PBC_OWNR, PBC_CNAM)
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
-- Grant/Revoke object privileges 
execute immediate 'grant select, insert, update, delete on PBCATCOL to PUBLIC';

dbms_output.put_line('表PBCATCOL创建成功!');
else dbms_output.put_line('表PBCATCOL已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'PBCATEDT'; 
      if   num<1   then 
        
execute immediate 'create table PBCATEDT
(
  PBE_NAME VARCHAR2(30),
  PBE_EDIT VARCHAR2(254),
  PBE_TYPE INTEGER,
  PBE_CNTR INTEGER,
  PBE_SEQN INTEGER,
  PBE_FLAG INTEGER,
  PBE_WORK VARCHAR2(32)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate indexes 
execute immediate 'create unique index PBSYSPBE_IDX on PBCATEDT (PBE_NAME, PBE_SEQN)
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
-- Grant/Revoke object privileges 
execute immediate 'grant select, insert, update, delete on PBCATEDT to PUBLIC';
dbms_output.put_line('表PBCATEDT创建成功!');
else dbms_output.put_line('表PBCATEDT已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'PBCATFMT'; 
      if   num<1   then 
        
execute immediate 'create table PBCATFMT
(
  PBF_NAME VARCHAR2(30),
  PBF_FRMT VARCHAR2(254),
  PBF_TYPE INTEGER not null,
  PBF_CNTR INTEGER
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate indexes 
execute immediate 'create unique index PBSYSCATFRMTS_IDX on PBCATFMT (PBF_NAME)
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
-- Grant/Revoke object privileges 
execute immediate 'grant select, insert, update, delete on PBCATFMT to PUBLIC';
dbms_output.put_line('表PBCATFMT创建成功!');
else dbms_output.put_line('表PBCATFMT已经存在!');
      END IF;
END;

/

-- Create table
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'PBCATTBL'; 
      if   num<1   then 
        
execute immediate 'create table PBCATTBL
(
  PBT_TNAM VARCHAR2(30) not null,
  PBT_TID  INTEGER,
  PBT_OWNR VARCHAR2(30) not null,
  PBD_FHGT INTEGER,
  PBD_FWGT INTEGER,
  PBD_FITL CHAR(1),
  PBD_FUNL CHAR(1),
  PBD_FCHR INTEGER,
  PBD_FPTC INTEGER,
  PBD_FFCE VARCHAR2(18),
  PBH_FHGT INTEGER,
  PBH_FWGT INTEGER,
  PBH_FITL CHAR(1),
  PBH_FUNL CHAR(1),
  PBH_FCHR INTEGER,
  PBH_FPTC INTEGER,
  PBH_FFCE VARCHAR2(18),
  PBL_FHGT INTEGER,
  PBL_FWGT INTEGER,
  PBL_FITL CHAR(1),
  PBL_FUNL CHAR(1),
  PBL_FCHR INTEGER,
  PBL_FPTC INTEGER,
  PBL_FFCE VARCHAR2(18),
  PBT_CMNT VARCHAR2(254)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate indexes 
execute immediate 'create unique index PBSYSCATPBT_IDX on PBCATTBL (PBT_TNAM, PBT_OWNR)
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
-- Grant/Revoke object privileges 
execute immediate 'grant select, insert, update, delete on PBCATTBL to PUBLIC';
dbms_output.put_line('表PBCATTBL创建成功!');
else dbms_output.put_line('表PBCATTBL已经存在!');
      END IF;
END;

/

-- Create table PBCATVLD
declare 
      num   number; 
begin 
      select count(1) into num from all_tables where TABLE_NAME = 'PBCATVLD'; 
      if   num<1   then 
        
execute immediate 'create table PBCATVLD
(
  PBV_NAME VARCHAR2(30),
  PBV_VALD VARCHAR2(254),
  PBV_TYPE INTEGER,
  PBV_CNTR INTEGER,
  PBV_MSG  VARCHAR2(254)
)
tablespace LIS_DATA
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  )';
-- Create/Recreate indexes 
execute immediate 'create unique index PBSYSCATVLDS_IDX on PBCATVLD (PBV_NAME)
  tablespace LIS_DATA
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  )';
-- Grant/Revoke object privileges 
execute immediate 'grant select, insert, update, delete on PBCATVLD to PUBLIC';
dbms_output.put_line('表PBCATVLD创建成功!');
else dbms_output.put_line('表PBCATVLD已经存在!');
END  IF;
END;

/

--创建序列
-- Create sequence  SEQ_DA_CONFIG
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_CONFIG'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_CONFIG
minvalue 0
maxvalue 999999999999999999999999999
start with 2
increment by 1
nocache';

END  IF;
END;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_DATABLELASTDATE'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_DATABLELASTDATE
minvalue 0
maxvalue 999999999999999999999999999
start with 111
increment by 1
nocache';

END  IF;
END;

/

-- Create sequence SEQ_DA_DICTTESTITEM
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_DICTTESTITEM'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_DICTTESTITEM
minvalue 1
maxvalue 999999999999999999999999999
start with 67081
increment by 1
cache 20';

END  IF;
END;
/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_DICTUSER'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_DICTUSER
minvalue 1
maxvalue 999999999999999999999999999
start with 41
increment by 1
cache 20';

END  IF;
END;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_LIS_PICTURE'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_LIS_PICTURE
minvalue 0
maxvalue 999999999999999999999999999
start with 23
increment by 1
nocache';

END  IF;
END;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_MICANTIRESULT'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_MICANTIRESULT
minvalue 0
maxvalue 999999999999999999999999999
start with 2
increment by 1
nocache';

END  IF;
END;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_MICORGRESULT'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_MICORGRESULT
minvalue 0
maxvalue 999999999999999999999999999
start with 4
increment by 1
nocache';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_OPERATIONLOG'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_OPERATIONLOG
minvalue 1
maxvalue 999999999999999999999999999
start with 421
increment by 1
cache 20';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_OUTSPECIMEN'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_OUTSPECIMEN
minvalue 1
maxvalue 999999999999999999999999999
start with 281
increment by 1
cache 20';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_OUTSPECIMENTEST'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_OUTSPECIMENTEST
minvalue 1
maxvalue 999999999999999999999999999
start with 181
increment by 1
cache 20';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_PATHOLOGYRESULT'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_PATHOLOGYRESULT
minvalue 1
maxvalue 999999999999999999999999999
start with 121
increment by 1
cache 20';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_REPORT'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_REPORT
minvalue 0
maxvalue 999999999999999999999999999
start with 2
increment by 1
nocache';

end if;
end;

/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_RESULT'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_RESULT
minvalue 1
maxvalue 999999999999999999999999999
start with 181
increment by 1
cache 20';

end if;
end;


/

-- Create sequence 
declare 
      num   number; 
begin 
      select count(1) into num from All_Sequences where Sequence_name= 'SEQ_DA_TESTMAP'; 
      if   num<1   then 
      
execute immediate 'create sequence SEQ_DA_TESTMAP
minvalue 1
maxvalue 999999999999999999999999999
start with 125
increment by 1
cache 20';

end if;
end;

/
--基础数据创建
--创建管理员帐号admin 默认密码admin
declare 
      num   number; 
begin 
      select count(1) into num from da_dictuser where usercode= 'admin'; 
      if   num<1   then 
      execute immediate 'INSERT INTO da_dictuser(dictuserid,usercode,username,password,remark,isactive,createdate)
      VALUES(SEQ_DA_DICTUSER.Nextval,''admin'',''管理员'',''21232f297a57a5a743894a0e4a801fc3'',''管理员'',''1'',sysdate)';
      END IF;
END;

/
--创建DA_TABLELASTDATE添加反审核查询最后时间
declare 
      num   number; 
begin 
      select count(1) into num from DA_TABLELASTDATE where TABLENAME = 'ExBarCode'; 
      if   num<1   then 
execute immediate 'INSERT INTO DA_TABLELASTDATE
(TABLENAME,LASTDATE,CREATEDATE,REMARK)
VALUES(''ExBarCode'',sysdate,sysdate,''反审核查询最后时间'')';
end if;
end;

/
--创建DA_TABLELASTDATE日志上传最后时间
declare 
      num   number; 
begin 
      select count(1) into num from DA_TABLELASTDATE where TABLENAME = 'ExBarCode'; 
      if   num<1   then 
execute immediate 'INSERT INTO DA_TABLELASTDATE
(TABLENAME,LASTDATE,CREATEDATE,REMARK)
VALUES(''ErrorLog'',sysdate,sysdate,''日志上传最后时间'')';
end if;
end;

/