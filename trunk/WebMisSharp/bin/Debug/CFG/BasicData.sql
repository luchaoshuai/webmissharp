if exists (select * from sysobjects where id = OBJECT_ID('[WMS_FAVORITES]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_FAVORITES]

CREATE TABLE [WMS_FAVORITES] (
[Fid] [int]  IDENTITY (1, 1)  NOT NULL,
[Funid] [int]  NOT NULL,
[UserId] [varchar]  (20) NOT NULL,
[CreateDate] [datetime]  NULL)

ALTER TABLE [WMS_FAVORITES] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_FAVORITES] PRIMARY KEY  NONCLUSTERED ( [Funid],[UserId] )
SET IDENTITY_INSERT [WMS_FAVORITES] ON


SET IDENTITY_INSERT [WMS_FAVORITES] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[WMS_NOTICE]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_NOTICE]

CREATE TABLE [WMS_NOTICE] (
[nid] [int]  IDENTITY (1, 1)  NOT NULL,
[ntitle] [nvarchar]  (255) NULL,
[ncontent] [text]  NULL,
[ndate] [datetime]  NULL,
[nowner] [nvarchar]  (50) NULL,
[norigin] [nvarchar]  (50) NULL,
[nreceiver] [varchar]  (50) NULL)

ALTER TABLE [WMS_NOTICE] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_NOTICE] PRIMARY KEY  NONCLUSTERED ( [nid] )
SET IDENTITY_INSERT [WMS_NOTICE] ON


SET IDENTITY_INSERT [WMS_NOTICE] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[WMS_ROLEFUN]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_ROLEFUN]

CREATE TABLE [WMS_ROLEFUN] (
[pid] [int]  IDENTITY (1, 1)  NOT NULL,
[roleid] [int]  NOT NULL,
[funid] [int]  NOT NULL)

ALTER TABLE [WMS_ROLEFUN] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_ROLEFUN] PRIMARY KEY  NONCLUSTERED ( [pid] )
SET IDENTITY_INSERT [WMS_ROLEFUN] ON

INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 1,1,1000)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 2,1,1229)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 3,1,1230)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 4,1,1231)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 5,1,1232)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 6,1,2000)
INSERT [WMS_ROLEFUN] ([pid],[roleid],[funid]) VALUES ( 7,1,2001)

SET IDENTITY_INSERT [WMS_ROLEFUN] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[WMS_ROLES]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_ROLES]

CREATE TABLE [WMS_ROLES] (
[roleid] [int]  IDENTITY (1, 1)  NOT NULL,
[rolename] [nvarchar]  (30) NOT NULL,
[remark] [nvarchar]  (100) NULL)

ALTER TABLE [WMS_ROLES] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_ROLES] PRIMARY KEY  NONCLUSTERED ( [roleid] )
SET IDENTITY_INSERT [WMS_ROLES] ON

INSERT [WMS_ROLES] ([roleid],[rolename],[remark]) VALUES ( 1,N'超级管理员',N'具有最高权限')

SET IDENTITY_INSERT [WMS_ROLES] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[WMS_USERFUN]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_USERFUN]

CREATE TABLE [WMS_USERFUN] (
[funid] [int]  NOT NULL,
[funno] [varchar]  (200) NOT NULL,
[funname] [varchar]  (100) NOT NULL,
[fatherid] [int]  NULL)

ALTER TABLE [WMS_USERFUN] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_USERFUN] PRIMARY KEY  NONCLUSTERED ( [funid] )
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 1000,N'sysMgr',N'系统管理',0)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 1229,N'/Admin/Core/Notice.aspx',N'通知公告',1000)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 1230,N'/Admin/Core/LogAndSQL.aspx',N'SQL日志',1000)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 1231,N'/Admin/Core/UserMgr.aspx',N'用户管理',1000)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 1232,N'/Admin/Core/RolesMgr.aspx',N'功能权限',1000)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 2000,N'FreeNodeMgr',N'游离功能',0)
INSERT [WMS_USERFUN] ([funid],[funno],[funname],[fatherid]) VALUES ( 2001,N'/Admin/Core/FunsMgr.aspx',N'功能节点',2000)
if exists (select * from sysobjects where id = OBJECT_ID('[WMS_USERINFO]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [WMS_USERINFO];

CREATE TABLE [WMS_USERINFO] (
[userid] [int]  IDENTITY (1, 1)  NOT NULL,
[username] [nvarchar]  (100) NOT NULL,
[cn_name] [varchar]  (50) NULL,
[userdept] [varchar]  (20) NULL,
[password] [nvarchar]  (50) NOT NULL,
[telephone] [nvarchar]  (20) NULL,
[usersex] [nvarchar]  (4) NULL,
[address] [nvarchar]  (100) NULL,
[email] [nvarchar]  (100) NULL,
[logintime] [datetime]  NULL,
[createtime] [datetime]  NULL,
[roleid] [int]  NOT NULL);

ALTER TABLE [WMS_USERINFO] WITH NOCHECK ADD  CONSTRAINT [PK_WMS_USERINFO] PRIMARY KEY  NONCLUSTERED ( [username] )
SET IDENTITY_INSERT [WMS_USERINFO] ON

INSERT [WMS_USERINFO] ([userid],[username],[cn_name],[userdept],[password],[telephone],[usersex],[address],[email],[logintime],[createtime],[roleid]) VALUES ( 1,N'admin',N'陈杰',N'云极',N'I7CCJ46J;94I:9IFFE=9EF=8=7GHE45I',N'15988381281',N'男',N'山东日照',N'ovenjackchain@gmail.com',N'2012/4/29 21:47:09',N'2012/4/30 0:00:00',1)

SET IDENTITY_INSERT [WMS_USERINFO] OFF


