using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.BaseRepository;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_MenuInRoleRespository</c> is the implementation of <see cref="ISys_MenuInRoleRepository"/>.</summary>
    internal class Sys_MenuInRoleRepository : BaseProvider, ISys_MenuInRoleRepository {

        public Sys_MenuInRoleRepository() : base() { }

        public Sys_MenuInRoleRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_MenuInRole.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.Find"/></summary>
        public Sys_MenuInRole Find(Int32 id) {
            String stmtId = "Sys_MenuInRole.Find";
            Sys_MenuInRole result = SqlMapper.QueryForObject<Sys_MenuInRole>(stmtId, id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.FindAll"/></summary>
        public IList<Sys_MenuInRole> FindAll() {
            String stmtId = "Sys_MenuInRole.FindAll";
            IList<Sys_MenuInRole> result = SqlMapper.QueryForList<Sys_MenuInRole>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.Insert"/></summary>
        public void Insert(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_MenuInRole.Insert";
            SqlMapper.Insert(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.Update"/></summary>
        public void Update(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_MenuInRole.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleRepository.Delete"/></summary>
        public void Delete(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_MenuInRole.Delete";
            SqlMapper.Delete(stmtId, obj);
        }

        public IList<Sys_MenuInRole> FindByRoleId(Int32 roleId) {
            String stmtId = "Sys_MenuInRole.FindByRoleId";
            IList<Sys_MenuInRole> result = SqlMapper.QueryForList<Sys_MenuInRole>(stmtId, roleId);
            return result;
        }

        public IList<Sys_MenuInRole> FindByRoleName(string roleName) {
            String stmtId = "Sys_MenuInRole.FindByRoleName";
            IList<Sys_MenuInRole> result = SqlMapper.QueryForList<Sys_MenuInRole>(stmtId, roleName);
            return result;

        }


    }
}
