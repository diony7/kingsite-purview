using System;
using System.Collections.Generic;

using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {

    /// <summary><c>ISys_FunctionRepository</c> is the DAO interface for <see cref="SysFunction"/>.</summary>
    internal interface ISys_FunctionRepository {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_Function"/> instance by the primary key value.</summary>
        Sys_Function Find(Int32 id);

        /// <summary>Finds all Sys_Function instances.</summary>
        IList<Sys_Function> FindAll();

        /// <summary>Inserts a new Sys_Function instance into underlying database table.</summary>
        void Insert(Sys_Function obj);

        /// <summary>Update the underlying database record of a Sys_Function instance.</summary>
        void Update(Sys_Function obj);

        /// <summary>Delete the underlying database record of a Sys_Function instance.</summary>
        void Delete(Sys_Function obj);

        IList<Sys_Function> FindByIds(string ids);
    }
}
