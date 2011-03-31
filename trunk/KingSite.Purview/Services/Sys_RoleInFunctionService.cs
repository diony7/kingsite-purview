using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Repository;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.Purview.Core.Service;

namespace KingSite.Purview.Services {
    /// <summary><c>Sys_RoleInFunctionService</c> is the implementation of <see cref="ISys_RoleInFunctionService"/>.</summary>
    internal class Sys_RoleInFunctionService : ISys_RoleInFunctionService {

        ISys_RoleInFunctionRepository _repository;

        public Sys_RoleInFunctionService()
            : this(new Sys_RoleInFunctionRepository()) { }

        public Sys_RoleInFunctionService(ISys_RoleInFunctionRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.Find"/></summary>
        public Sys_RoleInFunction Find(Int32 id) {
            Sys_RoleInFunction result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.FindAll"/></summary>
        public IList<Sys_RoleInFunction> FindAll() {
            IList<Sys_RoleInFunction> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.Insert"/></summary>
        public void Insert(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.Update"/></summary>
        public void Update(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_RoleInFunctionService.Delete"/></summary>
        public void Delete(Sys_RoleInFunction obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }

}
