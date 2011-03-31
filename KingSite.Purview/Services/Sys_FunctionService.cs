using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Repository;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;
using KingSite.Purview.Core.Service;

namespace KingSite.Purview.Services {

    /// <summary><c>Sys_FunctionService</c> is the implementation of <see cref="ISys_FunctionService"/>.</summary>
    internal class Sys_FunctionService : ISys_FunctionService {

        ISys_FunctionRepository _repository;

        public Sys_FunctionService()
            : this(new Sys_FunctionRepository()) { }

        public Sys_FunctionService(ISys_FunctionRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_FunctionService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionService.Find"/></summary>
        public Sys_Function Find(Int32 id) {
            Sys_Function result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionService.FindAll"/></summary>
        public IList<Sys_Function> FindAll() {
            IList<Sys_Function> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_FunctionService.Insert"/></summary>
        public void Insert(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_FunctionService.Update"/></summary>
        public void Update(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_FunctionService.Delete"/></summary>
        public void Delete(Sys_Function obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }
	
}
