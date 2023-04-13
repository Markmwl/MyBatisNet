-- Create table
create table T_USER
(
  vc_id       VARCHAR2(256) not null,
  vc_username VARCHAR2(256) not null,
  vc_userpass VARCHAR2(256) not null,
  vc_depname  VARCHAR2(256),
  vc_isadmin  VARCHAR2(1) default 0 not null,
  vc_cid      VARCHAR2(256) not null,
  d_cdate     DATE not null,
  vc_mid      VARCHAR2(256) not null,
  d_mdate     DATE not null,
  vc_isdel    VARCHAR2(1) default 0 not null
);
-- Add comments to the table 
comment on table T_USER
  is '用户表';
-- Add comments to the columns 
comment on column T_USER.vc_id
  is '主键';
comment on column T_USER.vc_username
  is '用户名';
comment on column T_USER.vc_userpass
  is '密码';
comment on column T_USER.vc_depname
  is '部门';
comment on column T_USER.vc_isadmin
  is '是否管理员';
comment on column T_USER.vc_cid
  is '创建者';
comment on column T_USER.d_cdate
  is '创建时间';
comment on column T_USER.vc_mid
  is '修改者';
comment on column T_USER.d_mdate
  is '修改时间';
comment on column T_USER.vc_isdel
  is '删除标识';
-- Create/Recreate primary, unique and foreign key constraints 
alter table T_USER  add constraint PK_T_USER_IOMP primary key (VC_ID);



insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('zhongxiaoxiao', '钟潇潇', 'zhongxiaoxiao', '交易', '0', 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('liuruijie', '刘睿杰', 'liuruijie', '交易', '0', 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('admin', '系统管理员', 'admin', '系统', '1', 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('test1', '测试员一', 'test1', '运营', '0', 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('wuxiatian', '吴夏天', 'wuxiatian', '运营', '0', 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), 'admin', to_date('01-01-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('zhuweixiang', '祝伟翔', '1111111', '交易', '0', 'admin', to_date('07-08-2017', 'dd-mm-yyyy'), 'admin', to_date('07-08-2017', 'dd-mm-yyyy'), '0');

insert into T_USER (VC_ID, VC_USERNAME, VC_USERPASS, VC_DEPNAME, VC_ISADMIN, VC_CID, D_CDATE, VC_MID, D_MDATE, VC_ISDEL)
values ('guoyamei', '郭亚梅', '1111111', '运营', '0', 'admin', to_date('07-08-2017', 'dd-mm-yyyy'), 'admin', to_date('07-08-2017', 'dd-mm-yyyy'), '0');