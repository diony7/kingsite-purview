using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {
    /// <summary><c>ISys_UserInRoleRepository</c> is the DAO interface for .</summary>
    internal interface ISys_UserInRoleRepository {
        
        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_User"/> instance by the primary key value.</summary>
        Sys_UserInRole Find(Int32 id);

        /// <summary>Finds all Cart instances.</summary>
        IList<Sys_UserInRole> FindAll();

        /// <summary>Inserts a new Sys_Application instance into underlying database table.</summary>
        bool Insert(Sys_UserInRole obj);

        /// <summary>Update the underlying database record of a Sys_Application instance.</summary>
        bool Update(Sys_UserInRole obj);

        /// <summary>Delete the underlying database record of a Sys_Application instance.</summary>
        bool Delete(int id);

        bool AddUsersToRoles(string applicationName, string[] usernames, string[] rolenames);

        string[] FindUsersInRole(string applicationName, string roleName, string usernameToMatch);

        IList<Sys_UserInRole> GetRolesForUser(string applicationName, string userName);

        IList<Sys_UserInRole> GetUsersInRole(string applicationName, string roleName);

        bool IsUserInRole(string applicationName, string userName, string roleName);

        bool RemoveUsersFromRoles(string applicationName, string[] usernames, string[] rolenames);
    }

}
