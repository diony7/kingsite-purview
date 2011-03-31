--drop index IX_SYS_APPLICATION;
--drop table Sys_Application cascade constraints;

/*==============================================================*/
/* Table: Sys_Application                                       */
/*==============================================================*/
create table Sys_Application  (
   Id                   INTEGER                         not null,
   Name                 VARCHAR2(50)                    not null,
   Description          VARCHAR2(200),
   constraint PK_SYS_APPLICATION primary key (Id)
);

/*==============================================================*/
/* Index: IX_SYS_APPLICATION                                    */
/*==============================================================*/
create unique index IX_SYS_APPLICATION on Sys_Application (
   Name ASC
);


--drop index IX_Sys_Role;
--drop table Sys_Role cascade constraints;

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role  (
   Id                   INTEGER                         not null,
   ApplicationName      VARCHAR2(50)                    not null,
   RoleName             VARCHAR2(50)                    not null,
   constraint PK_SYS_ROLE primary key (Id)
);

/*==============================================================*/
/* Index: IX_Sys_Role                                           */
/*==============================================================*/
create unique index IX_Sys_Role on Sys_Role (
   ApplicationName ASC,
   RoleName ASC
);


--drop index IX_Sys_User;
--drop table Sys_User cascade constraints;

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User  (
   Id                   VARCHAR2(36)                    not null,
   ApplicationName      VARCHAR2(50)                    not null,
   Name                 VARCHAR2(50)                    not null,
   DisplayName          VARCHAR2(20)                    not null,
   Email                VARCHAR2(100)                   not null,
   U_Comment            VARCHAR2(100),
   Password             VARCHAR2(128)                   not null,
   PasswordKey          VARCHAR2(128)                   not null,
   PasswordQuestion     VARCHAR2(255),
   PasswordAnswer       VARCHAR2(255),
   IsApproved           SMALLINT                        not null,
   LastActivityDate     DATE                            not null,
   LastLoginDate        DATE                            not null,
   LastPasswordChangedDate DATE                            not null,
   CreationDate         DATE                            not null,
   IsLockedOut          SMALLINT                        not null,
   LastLockedOutDate    DATE,
   IsOnLine             SMALLINT                        not null,
   FailedPasswordAttemptCount INTEGER,
   FailedPasswordAttemptWindowSta DATE,
   FailedPasswordAnswerAttemptCou INTEGER,
   FailedPasswordAnswerAttemptWin DATE,
   constraint PK_SYS_USER primary key (Id)
);

/*==============================================================*/
/* Index: IX_Sys_User                                           */
/*==============================================================*/
create unique index IX_Sys_User on Sys_User (
   ApplicationName ASC,
   Name ASC
);


--drop index IX_Sys_UserInRole;
--drop table Sys_UserInRole cascade constraints;

/*==============================================================*/
/* Table: Sys_UserInRole                                        */
/*==============================================================*/
create table Sys_UserInRole  (
   Id                   INTEGER                         not null,
   UserName             VARCHAR2(50)                    not null,
   RoleName             VARCHAR2(50)                    not null,
   ApplicationName      VARCHAR2(50)                    not null,
   constraint PK_SYS_USERINROLE primary key (Id)
);

/*==============================================================*/
/* Index: IX_Sys_UserInRole                                     */
/*==============================================================*/
create unique index IX_Sys_UserInRole on Sys_UserInRole (
   UserName ASC,
   RoleName ASC,
   ApplicationName ASC
);

-- sequence SEQ_KSP
--drop sequence SEQ_KSP;

create sequence SEQ_KSP
minvalue 1
maxvalue 99999999
start with 10
increment by 1
cache 20;