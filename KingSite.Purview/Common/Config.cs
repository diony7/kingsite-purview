using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using KingSite.BaseRepository;

namespace KingSite.Purview.Common {
    internal class Config {
        public static string GetConnectionName() {
            if (ConfigurationManager.ConnectionStrings["KSPDB"] == null) {
                throw new ConfigurationErrorsException("需要KSPDB连接字符串");
            }
            else {
                return ConfigurationManager.ConnectionStrings["KSPDB"].Name;
            }
        }

        public static string GetApplicationName() {
            if (ConfigurationManager.AppSettings["KSPAPPName"] == null) {
                throw new ConfigurationErrorsException("需要KSPAPPName AppSetting配置节");
            }
            else {
                return ConfigurationManager.AppSettings["KSPAPPName"];
            }
        }

        public static DBType GetDBType() {
            if (ConfigurationManager.AppSettings["KSPDBType"] == null) {
                throw new ConfigurationErrorsException("需要KSPDBType AppSetting 配置节");
            }
            else {
                DBType _dbType;
                string name = ConfigurationManager.AppSettings["KSPDBType"];
                switch (name.ToLower()) {
                    case "sqlserver": _dbType = DBType.SqlServer; break;
                    case "mysql": _dbType = DBType.MySql; break;
                    case "oracle": _dbType = DBType.Oracle; break;
                    case "sqlite3": _dbType = DBType.SQLite3; break;
                    default: throw new Exception("kspdbtype format not supported. must be in (sqlserver/mysql/oracle/sqlite3)");
                }
                return _dbType;
            }
        }
    }



}
