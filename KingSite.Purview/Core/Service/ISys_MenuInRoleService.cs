using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Service {
    /// <summary><c>ISys_MenuInRoleService</c> is the Services interface for <see cref="Sys_MenuInRole"/>.</summary>
    public partial interface ISys_MenuInRoleService {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_MenuInRole"/> instance by the primary key value.</summary>
        Sys_MenuInRole Find(Int32 id);

        /// <summary>Finds all Sys_MenuInRole instances.</summary>
        IList<Sys_MenuInRole> FindAll();

        /// <summary>Inserts a new Sys_MenuInRole instance into underlying database table.</summary>
        void Insert(Sys_MenuInRole obj);

        /// <summary>Update the underlying database record of a Sys_MenuInRole instance.</summary>
        void Update(Sys_MenuInRole obj);

        /// <summary>Delete the underlying database record of a Sys_MenuInRole instance.</summary>
        void Delete(Sys_MenuInRole obj);


    }
}
