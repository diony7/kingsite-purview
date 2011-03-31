using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Core.Repository;
using KingSite.Purview.Core.Service;
using KingSite.Purview.Domain;
using KingSite.Purview.Repository;

namespace KingSite.Purview.Services {
    /// <summary><c>Sys_MenuService</c> is the implementation of <see cref="ISys_MenuService"/>.</summary>
    public partial class Sys_MenuService : ISys_MenuService {

        ISys_MenuRepository _repository;

        public Sys_MenuService()
            : this(new Sys_MenuRepository()) { }

        public Sys_MenuService(ISys_MenuRepository repository) {
            _repository = repository;
        }

        /// <summary>Implements <see cref="ISys_MenuService.GetCount"/></summary>
        public int GetCount() {
            int result = _repository.GetCount();
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuService.Find"/></summary>
        public Sys_Menu Find(Int32 id) {
            Sys_Menu result = _repository.Find(id);
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuService.FindAll"/></summary>
        public IList<Sys_Menu> FindAll() {
            IList<Sys_Menu> result = _repository.FindAll();
            return result;
        }

        /// <summary>Implements <see cref="ISys_MenuService.Insert"/></summary>
        public void Insert(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Insert(obj);
        }

        /// <summary>Implements <see cref="ISys_MenuService.Update"/></summary>
        public void Update(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Update(obj);
        }

        /// <summary>Implements <see cref="ISys_MenuService.Delete"/></summary>
        public void Delete(Sys_Menu obj) {
            if (obj == null) throw new ArgumentNullException("obj");
            _repository.Delete(obj);
        }


    }

}
