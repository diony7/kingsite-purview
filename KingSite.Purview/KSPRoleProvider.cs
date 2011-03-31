using System;
using System.Collections.Generic;

using System.Text;
using System.Web.Security;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Configuration.Provider;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Repository;
using KingSite.BaseRepository;
using KingSite.Purview.Domain;
using KingSite.Purview.Common;

namespace KingSite.Purview {

    public sealed class KSPRoleProvider : RoleProvider {

        ISys_RoleRepository _roleRepository;
        ISys_UserInRoleRepository _urRepository;

        #region 属性
        private string _ApplicationName;
        public override string ApplicationName {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        private string _ConnectionStringName;
        public string ConnectionStringName {
            get { return _ConnectionStringName; }
            set { _ConnectionStringName = value; }
        }

        private bool _WriteExceptionsToEventLog;
        public bool WriteExceptionsToEventLog {
            get { return _WriteExceptionsToEventLog; }
            set { _WriteExceptionsToEventLog = value; }
        }

        private DBType _KSPDBType;
        public DBType KSPDBType {
            get { return _KSPDBType; }
            set { _KSPDBType = value; }
        }
        #endregion
        //
        // System.Configuration.Provider.ProviderBase.Initialize Method
        //

        public override void Initialize(string name, NameValueCollection config) {

            //
            // Initialize values from web.config.
            //

            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "KSP RoleProvider";

            if (String.IsNullOrEmpty(config["description"])) {
                config.Remove("description");
                config.Add("description", "KSP RoleProvider for sqlserver/mysql/oracle");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            _ApplicationName = Config.GetApplicationName();
            _KSPDBType = Config.GetDBType();
            _ConnectionStringName = Config.GetConnectionName();

            if (config["writeExceptionsToEventLog"] != null) {
                if (config["writeExceptionsToEventLog"].ToUpper() == "TRUE") {
                    _WriteExceptionsToEventLog = true;
                }
            }

            InitRepostory();
        }

        private void InitRepostory() {
            _roleRepository = new Sys_RoleRepository(ConnectionStringName, KSPDBType);
            _urRepository = new Sys_UserInRoleRepository(ConnectionStringName, KSPDBType);
        }


        public override void AddUsersToRoles(string[] usernames, string[] rolenames) {
            foreach (string rolename in rolenames) {
                if (!RoleExists(rolename)) {
                    throw new ProviderException("Role name not found.");
                }
            }

            foreach (string username in usernames) {
                if (username.IndexOf(',') > 0) {
                    throw new ArgumentException("User names cannot contain commas.");
                }

                foreach (string rolename in rolenames) {
                    if (IsUserInRole(username, rolename)) {
                        throw new ProviderException("User is already in role.");
                    }
                }
            }

            _urRepository.AddUsersToRoles(ApplicationName, usernames, rolenames);
        }

        public override void CreateRole(string rolename) {
            if (rolename.IndexOf(',') > 0) {
                throw new ArgumentException("Role names cannot contain commas.");
            }

            if (RoleExists(rolename)) {
                throw new ProviderException("Role name already exists.");
            }
            
            Sys_Role role = new Sys_Role();
            role.ApplicationName = ApplicationName;
            role.RoleName = rolename;
            _roleRepository.Insert(role);
        }

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole) {
            if (!RoleExists(rolename)) {
                throw new ProviderException("Role does not exist.");
            }

            if (throwOnPopulatedRole && GetUsersInRole(rolename).Length > 0) {
                throw new ProviderException("Cannot delete a populated role.");
            }
            bool result = _roleRepository.Delete(ApplicationName, rolename);
            return result;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch) {
            return _urRepository.FindUsersInRole(ApplicationName, roleName, usernameToMatch);
        }

        public override string[] GetAllRoles() {
            string tmpRoleNames = "";
            IList<Sys_Role> list = _roleRepository.GetAllRole(ApplicationName);
            foreach (Sys_Role r in list) {
                tmpRoleNames += r.RoleName + ",";
            }

            if (tmpRoleNames.Length > 0) {
                // Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');
            }

            return new string[0];
        }

        public override string[] GetRolesForUser(string username) {
            string tmpRoleNames = "";
            IList<Sys_UserInRole> list = _urRepository.GetRolesForUser(ApplicationName, username);
            foreach (Sys_UserInRole ur in list) {
                tmpRoleNames += ur.RoleName + ",";
            }

            if (tmpRoleNames.Length > 0) {
                // Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');
            }

            return new string[0];
        }

        public override string[] GetUsersInRole(string roleName) {
            string tmpUserNames = "";
            IList<Sys_UserInRole> list = _urRepository.GetUsersInRole(ApplicationName, roleName);
            foreach (Sys_UserInRole ur in list) {
                tmpUserNames += ur.UserName + ",";
            }

            if (tmpUserNames.Length > 0) {
                // Remove trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1);
                return tmpUserNames.Split(',');
            }

            return new string[0];
        }

        public override bool IsUserInRole(string username, string roleName) {
            return _urRepository.IsUserInRole(ApplicationName, username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames) {
            foreach (string rolename in rolenames) {
                if (!RoleExists(rolename)) {
                    throw new ProviderException("Role name not found.");
                }
            }

            foreach (string username in usernames) {
                foreach (string rolename in rolenames) {
                    if (!IsUserInRole(username, rolename)) {
                        throw new ProviderException("User is not in role.");
                    }
                }
            }

            _urRepository.RemoveUsersFromRoles(ApplicationName, usernames, rolenames);            
        }

        public override bool RoleExists(string roleName) {
            bool exists = false;
            Sys_Role  r = _roleRepository.Find(ApplicationName, roleName);
            if (r != null) {
                exists = true;
            }

            return exists;
        }
    }
}
