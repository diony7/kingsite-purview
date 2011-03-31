using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Service {
    /// <summary><c>ISys_ModuleService</c> is the Services interface for <see cref="Sys_Module"/>.</summary>
    internal interface ISys_ModuleService {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_Module"/> instance by the primary key value.</summary>
        Sys_Module Find(Int32 id);

        /// <summary>Finds all Sys_Module instances.</summary>
        IList<Sys_Module> FindAll();

        /// <summary>Inserts a new Sys_Module instance into underlying database table.</summary>
        void Insert(Sys_Module obj);

        /// <summary>Update the underlying database record of a Sys_Module instance.</summary>
        void Update(Sys_Module obj);

        /// <summary>Delete the underlying database record of a Sys_Module instance.</summary>
        void Delete(Sys_Module obj);


    }
}
