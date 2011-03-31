using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {

    /// <summary><c>ISys_ApplicationRepository</c> is the DAO interface for .</summary>
    internal interface ISys_ApplicationRepository {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_Application"/> instance by the primary key value.</summary>
        Sys_Application Find(Int32 id);

        /// <summary>Finds all Cart instances.</summary>
        IList<Sys_Application> FindAll();

        Sys_Application FindByName(string applicationName);

        /// <summary>Inserts a new Sys_Application instance into underlying database table.</summary>
        void Insert(Sys_Application obj);

        /// <summary>Update the underlying database record of a Sys_Application instance.</summary>
        void Update(Sys_Application obj);

        /// <summary>Delete the underlying database record of a Sys_Application instance.</summary>
        void Delete(Sys_Application obj);
    }
}
