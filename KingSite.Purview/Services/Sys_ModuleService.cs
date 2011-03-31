using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Core.Service;
using KingSite.Purview.Domain;
using KingSite.Purview.Repository;

namespace KingSite.Purview.Services {
    /// <summary><c>Sys_ModuleService</c> is the implementation of <see cref="ISys_ModuleService"/>.</summary>
    internal class Sys_ModuleService : ISys_ModuleService {

        ISys_ModuleRepository _repository;

        public Sys_ModuleService()
            : this(new Sys_ModuleRepository()) { }

        public Sys_ModuleService(ISys_ModuleRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_ModuleService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleService.Find"/></summary>
        public Sys_Module Find(Int32 id) {
            Sys_Module result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleService.FindAll"/></summary>
        public IList<Sys_Module> FindAll() {
            IList<Sys_Module> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_ModuleService.Insert"/></summary>
        public void Insert(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_ModuleService.Update"/></summary>
        public void Update(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_ModuleService.Delete"/></summary>
        public void Delete(Sys_Module obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }
}
