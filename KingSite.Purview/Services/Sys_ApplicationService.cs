using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Repository;
using KingSite.Purview.Core.Service;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Services {
    /// <summary><c>Sys_ApplicationService</c> is the implementation of <see cref="ISys_ApplicationService"/>.</summary>
    internal class Sys_ApplicationService : ISys_ApplicationService {

        ISys_ApplicationRepository _repository;

        public Sys_ApplicationService()
            : this(new Sys_ApplicationRepository()) { }

        public Sys_ApplicationService(ISys_ApplicationRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.Find"/></summary>
        public Sys_Application Find(Int32 id) {
            Sys_Application result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.FindAll"/></summary>
        public IList<Sys_Application> FindAll() {
            IList<Sys_Application> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.Insert"/></summary>
        public void Insert(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.Update"/></summary>
        public void Update(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_ApplicationService.Delete"/></summary>
        public void Delete(Sys_Application obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }
}
