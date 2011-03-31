using System;
using System.Collections.Generic;
using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {

    internal interface ISys_RoleRepository {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="RoleInfo"/> instance by the primary key value.</summary>
        Sys_Role Find(Int32 id);

        /// <summary>Finds all RoleInfo instances.</summary>
        IList<Sys_Role> FindAll();

        /// <summary>Inserts a new RoleInfo instance into underlying database table.</summary>
        bool Insert(Sys_Role obj);

        /// <summary>Update the underlying database record of a RoleInfo instance.</summary>
        bool Update(Sys_Role obj);

        /// <summary>Delete the underlying database record of a RoleInfo instance.</summary>
        bool Delete(int id);

        bool Delete(string applicationName, string roleName);

        IList<Sys_Role> GetAllRole(string applicationName);

        Sys_Role Find(string applicationName, string roleName);
    }
}
