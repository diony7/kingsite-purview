using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;
using KingSite.Purview.Core.Repository;
using KingSite.BaseRepository;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_ApplicationRepository</c> is the implementation of <see cref="ISys_ApplicationRepository"/>.</summary>
    internal class Sys_ApplicationRepository : BaseProvider, ISys_ApplicationRepository {

        public Sys_ApplicationRepository() : base() { }

        public Sys_ApplicationRepository(string connectionStringName, DBType dbType) :base(connectionStringName,dbType) {
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_Application.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.Find"/></summary>
        public Sys_Application Find(Int32 id) {
            String stmtId = "Sys_Application.Find";
            Sys_Application result = SqlMapper.QueryForObject<Sys_Application>(stmtId, id);
            return result;
        }

        public Sys_Application FindByName(string applicationName) {
            String stmtId = "Sys_Application.FindByName";
            Sys_Application ap = new Sys_Application();
            ap.Name = applicationName;
            Sys_Application result = SqlMapper.QueryForObject<Sys_Application>(stmtId, ap);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.FindAll"/></summary>
        public IList<Sys_Application> FindAll() {
            String stmtId = "Sys_Application.FindAll";
            IList<Sys_Application> result = SqlMapper.QueryForList<Sys_Application>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.Insert"/></summary>
        public void Insert(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Application.Insert";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.Update"/></summary>
        public void Update(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Application.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_ApplicationRepository.Delete"/></summary>
        public void Delete(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Application.Delete";
            SqlMapper.Delete(stmtId, obj);
        }
    }

}
