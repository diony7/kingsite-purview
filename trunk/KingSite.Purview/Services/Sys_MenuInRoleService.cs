using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Core.Service;
using KingSite.Purview.Domain;
using KingSite.Purview.Repository;

namespace KingSite.Purview.Services {
    /// <summary><c>Sys_MenuInRoleService</c> is the implementation of <see cref="ISys_MenuInRoleService"/>.</summary>
    public partial class Sys_MenuInRoleService : ISys_MenuInRoleService {

        ISys_MenuInRoleRepository _repository;

        public Sys_MenuInRoleService()
            : this(new Sys_MenuInRoleRepository()) { }

        public Sys_MenuInRoleService(ISys_MenuInRoleRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.Find"/></summary>
        public Sys_MenuInRole Find(Int32 id) {
            Sys_MenuInRole result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.FindAll"/></summary>
        public IList<Sys_MenuInRole> FindAll() {
            IList<Sys_MenuInRole> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.Insert"/></summary>
        public void Insert(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.Update"/></summary>
        public void Update(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_MenuInRoleService.Delete"/></summary>
        public void Delete(Sys_MenuInRole obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }
}
