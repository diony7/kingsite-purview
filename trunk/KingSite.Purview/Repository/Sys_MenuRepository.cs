using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.BaseRepository;

namespace KingSite.Purview.Repository {

    /// <summary><c>Sys_MenuRepository</c> is the implementation of <see cref="ISys_MenuRepository"/>.</summary>
    public partial class Sys_MenuRepository : BaseProvider, ISys_MenuRepository {

        public Sys_MenuRepository() : base() { }

        public Sys_MenuRepository(string connectionStringName, DBType dbType)
            : base(connectionStringName, dbType) {
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.GetCount"/></summary>
        public int GetCount() {
            String stmtId = "Sys_Menu.GetCount";
            int result = SqlMapper.QueryForObject<int>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.Find"/></summary>
        public Sys_Menu Find(Int32 id) {
            String stmtId = "Sys_Menu.Find";
            Sys_Menu result = SqlMapper.QueryForObject<Sys_Menu>(stmtId, id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.FindAll"/></summary>
        public IList<Sys_Menu> FindAll() {
            String stmtId = "Sys_Menu.FindAll";
            IList<Sys_Menu> result = SqlMapper.QueryForList<Sys_Menu>(stmtId, null);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.Insert"/></summary>
        public void Insert(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Menu.Insert";
            SqlMapper.Insert(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.Update"/></summary>
        public void Update(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Menu.Update";
            SqlMapper.Update(stmtId, obj);
        }

        /// <summary>Implements <see cref="ISys_MenuRepository.Delete"/></summary>
        public void Delete(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "Sys_Menu.Delete";
            SqlMapper.Delete(stmtId, obj);
        }

        public IList<Sys_Menu> FindByIds(string ids) {
            String stmtId = "Sys_Menu.FindByIds";
            IList<Sys_Menu> result = SqlMapper.QueryForList<Sys_Menu>(stmtId, ids);
            return result;

        }
    }
}
