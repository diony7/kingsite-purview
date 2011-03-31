using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Service {
    /// <summary><c>ISys_ApplicationService</c> is the Services interface for <see cref="Sys_Application"/>.</summary>
    internal interface ISys_ApplicationService {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_Application"/> instance by the primary key value.</summary>
        Sys_Application Find(Int32 id);

        /// <summary>Finds all Sys_Application instances.</summary>
        IList<Sys_Application> FindAll();

        /// <summary>Inserts a new Sys_Application instance into underlying database table.</summary>
        void Insert(Sys_Application obj);

        /// <summary>Update the underlying database record of a Sys_Application instance.</summary>
        void Update(Sys_Application obj);

        /// <summary>Delete the underlying database record of a Sys_Application instance.</summary>
        void Delete(Sys_Application obj);


    }
}
