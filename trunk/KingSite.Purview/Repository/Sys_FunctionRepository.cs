using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.BaseRepository;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_FunctionRepository</c> is the implementation of <see cref="ISys_FunctionRepository"/>.</summary>
    internal class Sys_FunctionRepository : BaseProvider, ISys_FunctionRepository {

        public Sys_FunctionRepository() : base() { }

        public Sys_FunctionRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_Function.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.Find"/></summary>
        public Sys_Function Find(Int32 id) {
            String stmtId = "Sys_Function.Find";
            Sys_Function result = SqlMapper.QueryForObject<Sys_Function>(stmtId, id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.FindAll"/></summary>
        public IList<Sys_Function> FindAll() {
            String stmtId = "Sys_Function.FindAll";
            IList<Sys_Function> result = SqlMapper.QueryForList<Sys_Function>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.Insert"/></summary>
        public void Insert(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Function.Insert";
            SqlMapper.Insert(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.Update"/></summary>
        public void Update(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Function.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_FunctionRespository.Delete"/></summary>
        public void Delete(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Function.Delete";
            SqlMapper.Delete(stmtId, obj);
        }

        public IList<Sys_Function> FindByIds(string ids) {
            String stmtId = "Sys_Function.FindByIds";
            IList<Sys_Function> result = SqlMapper.QueryForList<Sys_Function>(stmtId, ids);
            return result;
        }
    }
}
