using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.BaseRepository;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_RoleRepository</c> is the implementation of <see cref="ISys_RoleRepository"/>.</summary>
    internal class Sys_RoleRepository : BaseProvider, ISys_RoleRepository {

        public Sys_RoleRepository() : base() { }

        public Sys_RoleRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        public int GetCount() {
            String stmtId = "Sys_Role.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        public Sys_Role Find(Int32 id) {
            String stmtId = "Sys_Role.Find";
            Sys_Role result = SqlMapper.QueryForObject<Sys_Role>(stmtId, id);
            return result;
        }

        public IList<Sys_Role> FindAll() {
            String stmtId = "Sys_Role.FindAll";
            IList<Sys_Role> result = SqlMapper.QueryForList<Sys_Role>(stmtId, null);
            return result;
        }

        public bool Insert(Sys_Role obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Role.Insert";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool Update(Sys_Role obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Role.Update";
            if (SqlMapper.Update(stmtId, obj) > 0) {
                return true;
            }
            else return false;
        }

        public bool Delete(int id) {
            String stmtId = "Sys_Role.Delete";
            if (SqlMapper.Update(stmtId, id) > 0) {
                return true;
            }
            else return false;
        }

        public bool Delete(string applicationName, string roleName) {
            String stmtId = "Sys_Role.DeleteByName";
            Sys_Role role = new Sys_Role();
            role.ApplicationName = applicationName;
            role.RoleName = roleName;
            if (SqlMapper.Update(stmtId, role) > 0) {
                return true;
            }
            else return false;
        }

        public IList<Sys_Role> GetAllRole(string applicationName) {
            String stmtId = "Sys_Role.GetAllRole";
            Sys_Role r = new Sys_Role();
            r.ApplicationName = applicationName;
            IList<Sys_Role> result = SqlMapper.QueryForList<Sys_Role>(stmtId, r);
            return result;
        }

        public Sys_Role Find(string applicationName, string roleName) {
            String stmtId = "Sys_Role.FindByName";
            Sys_Role r = new Sys_Role();
            r.ApplicationName = applicationName;
            r.RoleName = roleName;
            Sys_Role result = SqlMapper.QueryForObject<Sys_Role>(stmtId, r);
            return result;

        }


    }
}
