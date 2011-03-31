using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.BaseRepository;
using KingSite.Purview.Domain;
using System.Collections;

namespace KingSite.Purview.Repository {
    /// <summary><c>Sys_RoleInFunctionRespository</c> is the implementation of <see cref="ISys_RoleInFunctionRepository"/>.</summary>
    internal class Sys_RoleInFunctionRepository : BaseProvider, ISys_RoleInFunctionRepository {

        public Sys_RoleInFunctionRepository() : base() { }

        public Sys_RoleInFunctionRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_RoleInFunction.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.Find"/></summary>
        public Sys_RoleInFunction Find(Int32 id) {
            String stmtId = "Sys_RoleInFunction.Find";
            Sys_RoleInFunction result = SqlMapper.QueryForObject<Sys_RoleInFunction>(stmtId, id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.FindAll"/></summary>
        public IList<Sys_RoleInFunction> FindAll() {
            String stmtId = "Sys_RoleInFunction.FindAll";
            IList<Sys_RoleInFunction> result = SqlMapper.QueryForList<Sys_RoleInFunction>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.Insert"/></summary>
        public void Insert(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_RoleInFunction.Insert";
            SqlMapper.Insert(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.Update"/></summary>
        public void Update(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_RoleInFunction.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionRepository.Delete"/></summary>
        public void Delete(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_RoleInFunction.Delete";
            SqlMapper.Delete(stmtId, obj);
        }

        public IList<Sys_RoleInFunction> FindByRoleName(string applicationName, string roleName) {
            String stmtId = "Sys_RoleInFunction.FindByRoleName";
            Hashtable ht = new Hashtable();
            ht.Add("ApplicationName", applicationName);
            ht.Add("RoleName", roleName);
            IList<Sys_RoleInFunction> result = SqlMapper.QueryForList<Sys_RoleInFunction>(stmtId, ht);
            return result;
        }

        public IList<Sys_RoleInFunction> FindByUCA(string applicationName, string userName, string controllerName, string actionName) {
            String stmtId = "Sys_RoleInFunction.FindByUCA";
            Hashtable ht = new Hashtable();
            ht.Add("ApplicationName", applicationName);
            ht.Add("UserName", userName);
            ht.Add("ControllerName", controllerName);
            ht.Add("ActionName", actionName);
            IList<Sys_RoleInFunction> result = SqlMapper.QueryForList<Sys_RoleInFunction>(stmtId, ht);
            return result;
        }
    }
}
