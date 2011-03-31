using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Service {
    /// <summary><c>ISys_RoleInFunctionService</c> is the Services interface for <see cref="Sys_RoleInFunction"/>.</summary>
    internal interface ISys_RoleInFunctionService {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_RoleInFunction"/> instance by the primary key value.</summary>
        Sys_RoleInFunction Find(Int32 id);

        /// <summary>Finds all Sys_RoleInFunction instances.</summary>
        IList<Sys_RoleInFunction> FindAll();

        /// <summary>Inserts a new Sys_RoleInFunction instance into underlying database table.</summary>
        void Insert(Sys_RoleInFunction obj);

        /// <summary>Update the underlying database record of a Sys_RoleInFunction instance.</summary>
        void Update(Sys_RoleInFunction obj);

        /// <summary>Delete the underlying database record of a Sys_RoleInFunction instance.</summary>
        void Delete(Sys_RoleInFunction obj);


    }

}
