if exists (select 1
            from  sysindexes
           where  id    = object_id('Sys_Application')
            and   name  = 'IX_Sys_Application'
            and   indid > 0
            and   indid < 255)
   drop index Sys_Application.IX_Sys_Application
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Application')
            and   type = 'U')
   drop table Sys_Application
go

/*==============================================================*/
/* Table: Sys_Application                                       */
/*==============================================================*/
create table Sys_Application (
   Id                   int                  identity,
   Name                 varchar(50)          not null,
   Description          varchar(200)         null,
   constraint PK_SYS_APPLICATION primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IX_Sys_Application                                    */
/*==============================================================*/
create unique index IX_Sys_Application on Sys_Application (
Name ASC
)
go



if exists (select 1
            from  sysindexes
           where  id    = object_id('Sys_Role')
            and   name  = 'IX_Sys_Role'
            and   indid > 0
            and   indid < 255)
   drop index Sys_Role.IX_Sys_Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Role')
            and   type = 'U')
   drop table Sys_Role
go

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role (
   Id                   int                  identity,
   ApplicationName      varchar(50)          not null,
   RoleName             varchar(50)          not null,
   constraint PK_SYS_ROLE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IX_Sys_Role                                           */
/*==============================================================*/
create unique index IX_Sys_Role on Sys_Role (
ApplicationName ASC,
RoleName ASC
)
go


if exists (select 1
            from  sysindexes
           where  id    = object_id('Sys_User')
            and   name  = 'IX_Sys_User'
            and   indid > 0
            and   indid < 255)
   drop index Sys_User.IX_Sys_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_User')
            and   type = 'U')
   drop table Sys_User
go

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User (
   Id                   varchar(36)          not null,
   ApplicationName      varchar(50)          not null,
   Name                 varchar(50)          not null,
   DisplayName          varchar(20)          not null,
   Email                varchar(100)         not null,
   Comment              varchar(100)         null,
   Password             varchar(128)         not null,
   PasswordKey          varchar(128)         not null,
   PasswordQuestion     varchar(255)         null,
   PasswordAnswer       varchar(255)         null,
   IsApproved           smallint             not null,
   LastActivityDate     datetime             not null,
   LastLoginDate        datetime             not null,
   LastPasswordChangedDate datetime             not null,
   CreationDate         datetime             not null,
   IsLockedOut          smallint             not null,
   LastLockedOutDate    datetime             null,
   IsOnLine             smallint             not null,
   FailedPasswordAttemptCount int                  null,
   FailedPasswordAttemptWindowStart datetime             null,
   FailedPasswordAnswerAttemptCount int                  null,
   FailedPasswordAnswerAttemptWindowStart datetime             null,
   constraint PK_SYS_USER primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IX_Sys_User                                           */
/*==============================================================*/
create unique index IX_Sys_User on Sys_User (
ApplicationName ASC,
Name ASC
)
go


if exists (select 1
            from  sysindexes
           where  id    = object_id('Sys_UserInRole')
            and   name  = 'IX_Sys_UserInRole'
            and   indid > 0
            and   indid < 255)
   drop index Sys_UserInRole.IX_Sys_UserInRole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_UserInRole')
            and   type = 'U')
   drop table Sys_UserInRole
go

/*==============================================================*/
/* Table: Sys_UserInRole                                        */
/*==============================================================*/
create table Sys_UserInRole (
   Id                   int                  identity,
   UserName             varchar(50)          not null,
   RoleName             varchar(50)          not null,
   ApplicationName      varchar(50)          not null,
   constraint PK_SYS_USERINROLE primary key nonclustered (Id)
)
go

/*==============================================================*/
/* Index: IX_Sys_UserInRole                                     */
/*==============================================================*/
create unique index IX_Sys_UserInRole on Sys_UserInRole (
UserName ASC,
RoleName ASC,
ApplicationName ASC
)
go



