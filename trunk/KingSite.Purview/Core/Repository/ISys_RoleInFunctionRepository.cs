using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {

    /// <summary><c>ISys_RoleInFunctionRepository</c> is the DAO interface for <see cref="Sys_RoleInFunction"/>.</summary>
    internal interface ISys_RoleInFunctionRepository {

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

        IList<Sys_RoleInFunction> FindByRoleName(string applicationName, string roleName);

        IList<Sys_RoleInFunction> FindByUCA(string applicationName, string userName, string controllerName, string actionName);
    }
}
