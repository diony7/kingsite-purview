using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.BaseRepository;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_ModuleRespository</c> is the implementation of <see cref="ISys_ModuleRepository"/>.</summary>
    internal class Sys_ModuleRepository : BaseProvider, ISys_ModuleRepository {

        public Sys_ModuleRepository() : base() { }

        public Sys_ModuleRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_Module.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.Find"/></summary>
        public Sys_Module Find(Int32 id) {
            String stmtId = "Sys_Module.Find";
            Sys_Module result = SqlMapper.QueryForObject<Sys_Module>(stmtId, id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.FindAll"/></summary>
        public IList<Sys_Module> FindAll() {
            String stmtId = "Sys_Module.FindAll";
            IList<Sys_Module> result = SqlMapper.QueryForList<Sys_Module>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.Insert"/></summary>
        public void Insert(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Module.Insert";
            SqlMapper.Insert(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.Update"/></summary>
        public void Update(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Module.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_ModuleRepository.Delete"/></summary>
        public void Delete(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Module.Delete";
            SqlMapper.Delete(stmtId, obj);
        }


    }
}
