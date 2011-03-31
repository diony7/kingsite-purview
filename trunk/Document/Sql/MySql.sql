SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

--
--  `sys_application`
--

DROP TABLE IF EXISTS `sys_application`;
CREATE TABLE IF NOT EXISTS `sys_application` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Sys_Application` (`Name`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
--  `sys_role`
--

DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE IF NOT EXISTS `sys_role` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ApplicationName` varchar(50) NOT NULL,
  `RoleName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Sys_Role` (`ApplicationName`,`RoleName`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

-- --------------------------------------------------------

--
--  `sys_user`
--

DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE IF NOT EXISTS `sys_user` (
  `Id` varchar(36) NOT NULL,
  `ApplicationName` varchar(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `DisplayName` varchar(20) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Comment` varchar(100) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` varchar(128) NOT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` smallint(6) NOT NULL,
  `LastActivityDate` datetime NOT NULL,
  `LastLoginDate` datetime NOT NULL,
  `LastPasswordChangedDate` datetime NOT NULL,
  `CreationDate` datetime NOT NULL,
  `IsLockedOut` smallint(6) NOT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `IsOnLine` smallint(6) NOT NULL,
  `FailedPasswordAttemptCount` int(11) DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(11) DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Sys_User` (`ApplicationName`,`Name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;


--
--  `sys_userinrole`
--

DROP TABLE IF EXISTS `sys_userinrole`;
CREATE TABLE IF NOT EXISTS `sys_userinrole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) NOT NULL,
  `RoleName` varchar(50) NOT NULL,
  `ApplicationName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Sys_UserInRole` (`UserName`,`RoleName`,`ApplicationName`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=15 ;


