using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.BaseRepository;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_UserInRoleRepository</c> is the implementation of <see cref="ISys_UserInRoleRepository"/>.</summary>
    internal class Sys_UserInRoleRepository : BaseProvider, ISys_UserInRoleRepository {

        public Sys_UserInRoleRepository() : base() { }

        public Sys_UserInRoleRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        public int GetCount() {
            String stmtId = "Sys_UserInRole.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        public Sys_UserInRole Find(Int32 id) {
            String stmtId = "Sys_UserInRole.Find";
            Sys_UserInRole result = SqlMapper.QueryForObject<Sys_UserInRole>(stmtId, id);
            return result;
        }

        public IList<Sys_UserInRole> FindAll() {
            String stmtId = "Sys_UserInRole.FindAll";
            IList<Sys_UserInRole> result = SqlMapper.QueryForList<Sys_UserInRole>(stmtId, null);
            return result;
        }

        public bool Insert(Sys_UserInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_UserInRole.Insert";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool Update(Sys_UserInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_UserInRole.Update";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool Delete(int id) {
            String stmtId = "Sys_UserInRole.Delete";
            if (SqlMapper.Update(stmtId, id) > 0) {
                return true;
            }
            else return false;
        }

        public bool Delete(Sys_UserInRole ur) {
            String stmtId = "Sys_UserInRole.DeleteByName";
            if (SqlMapper.Update(stmtId, ur) > 0) {
                return true;
            }
            else return false;
        }

        public bool AddUsersToRoles(string applicationName, string[] usernames, string[] rolenames) {
            bool b = false;
            try {
                SqlMapper.BeginTransaction();
                foreach (string username in usernames) {
                    foreach (string rolename in rolenames) {
                        Sys_UserInRole ur = new Sys_UserInRole();
                        ur.ApplicationName = applicationName;
                        ur.UserName = username;
                        ur.RoleName = rolename;
                        Insert(ur);
                    }
                }
                SqlMapper.CommitTransaction();
                b = true;
            }
            catch (Exception ex) {
                SqlMapper.RollBackTransaction();
                throw ex;
            }
            return b;
        }

        public string[] FindUsersInRole(string applicationName, string roleName, string usernameToMatch) {
            String stmtId = "Sys_UserInRole.FindUsersInRole";
            Sys_UserInRole ur = new Sys_UserInRole();
            ur.ApplicationName = applicationName;
            ur.RoleName = roleName;
            ur.UserName = usernameToMatch;
            IList<Sys_UserInRole> list = SqlMapper.QueryForList<Sys_UserInRole>(stmtId, ur);
            
            if (list.Count > 0) {
                string[] result  = new string[list.Count];
                int i = 0;
                foreach (Sys_UserInRole t in list) {
                    result[i] = t.UserName;
                    i++;
                }
                return result;
            }
            else { return new string[0]; }
        }

        public IList<Sys_UserInRole> GetRolesForUser(string applicationName, string userName) {
            String stmtId = "Sys_UserInRole.GetRolesForUser";
            Sys_UserInRole ur = new Sys_UserInRole();
            ur.ApplicationName = applicationName;
            ur.UserName = userName;
            IList<Sys_UserInRole> result = SqlMapper.QueryForList<Sys_UserInRole>(stmtId, ur);
            return result;
        }

        public IList<Sys_UserInRole> GetUsersInRole(string applicationName, string roleName) {
            String stmtId = "Sys_UserInRole.GetUsersInRole";
            Sys_UserInRole ur = new Sys_UserInRole();
            ur.ApplicationName = applicationName;
            ur.RoleName = roleName;
            IList<Sys_UserInRole> result = SqlMapper.QueryForList<Sys_UserInRole>(stmtId, ur);
            return result;
        }

        public bool IsUserInRole(string applicationName, string userName, string roleName) {
            String stmtId = "Sys_UserInRole.IsUserInRole";
            Sys_UserInRole ur = new Sys_UserInRole();
            ur.ApplicationName = applicationName;
            ur.RoleName = roleName;
            ur.UserName = userName;
            int result = SqlMapper.QueryForObject<int>(stmtId, ur);
            if (result > 0) {
                return true;
            }
            else return false;
        }

        public bool RemoveUsersFromRoles(string applicationName, string[] usernames, string[] rolenames) {
            bool b = false;
            try {
                SqlMapper.BeginTransaction();
                foreach (string username in usernames) {
                    foreach (string rolename in rolenames) {
                        Sys_UserInRole ur = new Sys_UserInRole();
                        ur.ApplicationName = applicationName;
                        ur.UserName = username;
                        ur.RoleName = rolename;
                        Delete(ur);
                    }
                }
                SqlMapper.CommitTransaction();
                b = true;
            }
            catch (Exception ex) {
                SqlMapper.RollBackTransaction();
                throw ex;
            }
            return b;
        }
    }
}
